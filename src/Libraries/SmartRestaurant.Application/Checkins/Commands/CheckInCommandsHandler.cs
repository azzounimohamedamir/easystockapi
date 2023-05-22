using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Checkins.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;
using System.Collections.Generic;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using Org.BouncyCastle.Asn1.Ocsp;
using SmartRestaurant.Application.Common.Enums;

namespace SmartRestaurant.Application.Checkins.Commands
{
	public class CheckInCommandsHandler :
		IRequestHandler<CreateCheckInCommand, Created>,
		IRequestHandler<UpdateCheckInAssignRoomCommand, NoContent>,
		IRequestHandler<ActivateCheckinCommand, NoContent>



	{
		private readonly IApplicationDbContext _context;
		private readonly IIdentityContext _identityContext;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		private readonly IOdooRepository _saleOrderRepository;
        private readonly IFirebaseRepository _fireBase;

        public CheckInCommandsHandler(IUserService userService, IApplicationDbContext context, IIdentityContext identityContext,IOdooRepository saleOrderRepository, IFirebaseRepository fireBase,
            IMapper mapper)
		{
			_context = context;
			_identityContext = identityContext;
			_mapper = mapper;
			_userService = userService;
			_saleOrderRepository = saleOrderRepository;
            _fireBase = fireBase;
        }



		public async Task<Created> Handle(CreateCheckInCommand request,
			CancellationToken cancellationToken)
		{

			bool isExistDraft= CheckOfAlreadyExistingDraft(request.hotelId);

			if(!isExistDraft)
			{
				var validator = new CreateCheckInCommandValidator();
				var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
				if (!result.IsValid) throw new ValidationException(result);
				var checkin = _mapper.Map<Domain.Entities.CheckIn>(request);
				_context.CheckIns.Add(checkin);
				await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
			}
			

			return default;

		}



		public bool CheckOfAlreadyExistingDraft(Guid hotelid)
		{
			bool isExist = _context.CheckIns.Where(a=>a.hotelId==hotelid).Any(checkin => checkin.ClientId == null);
			return isExist;

		}

		public async Task<NoContent> Handle(UpdateCheckInAssignRoomCommand request, CancellationToken cancellationToken)
		{
         if(request.Startdate < DateTime.Today)
			{
               
                throw new ConflictException("Sorry,Startdate must be a date after or equal today");
            }
            var checkin = await _context.CheckIns
				.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
				.ConfigureAwait(false);
			if (checkin == null)
				throw new NotFoundException(nameof(CheckIn), request.Id);
			var roomtoBook = _context.Rooms.Where(a => a.Id == request.RoomId).FirstOrDefault();
			var hotel = _context.Hotels.Where(a => a.Id == checkin.hotelId).FirstOrDefault();// get hotel
			roomtoBook.IsBooked = true;
			roomtoBook.ClientEmail = checkin.Email;

            roomtoBook.StartDayOfCheckin = request.Startdate?? DateTime.Now;
            roomtoBook.DurationOfCheckin = request.LengthOfStay??1;
            roomtoBook.Cleaned = false;
			roomtoBook.DateCheckout = roomtoBook.StartDayOfCheckin.AddDays(roomtoBook.DurationOfCheckin);
			if (checkin.ClientId != null)
			{
				roomtoBook.ClientId = Guid.Parse(checkin.ClientId);
			}
			_mapper.Map(request, checkin);
			_context.Rooms.Update(roomtoBook);
			_context.CheckIns.Update(checkin);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
			// create order chekin in odoo

			// read product hotel if existe else create one
			
			if (hotel.Odoo != null)
			{
				long productId = await CreateOdooProductOfTypeChekin(hotel, roomtoBook); // get order chekin id 
			long clientId = await CreateOdooClient(checkin, hotel); // get odoo client id
			await CreateOrderInOdoo(checkin, clientId, roomtoBook, productId); // create order in odoo
			}



















			if (checkin.ClientId != "null")
			{
				await addClientNotifications(checkin.ClientId.ToString(), "You have booked a room", cancellationToken);
			}
            return default;
		}

		public async Task<NoContent> Handle(ActivateCheckinCommand request, CancellationToken cancellationToken)
		{
			var userconnected = _userService.GetUserId();
			var AppuserInfo=_identityContext.ApplicationUser.Where(user=>user.Id==userconnected).FirstOrDefault();
			var checkin = await _context.CheckIns
				.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)			
				.ConfigureAwait(false);
			if (checkin == null)
				throw new NotFoundException(nameof(CheckIn), request.Id);

			checkin.ClientId = AppuserInfo.Id;
			checkin.FullName = AppuserInfo.FullName;
			checkin.Email = AppuserInfo.Email;
			checkin.PhoneNumber = AppuserInfo.PhoneNumber;
			checkin.IsActivate = true;
        

            var hotel = _context.Hotels.Where(a => a.Id == checkin.hotelId).FirstOrDefault();// get hotel

			if(checkin.RoomId != Guid.Empty)
			{
				var roomtoBook = _context.Rooms.Where(a => a.Id == checkin.RoomId).FirstOrDefault();

				roomtoBook.IsBooked = true;
				roomtoBook.Cleaned = false;
				roomtoBook.ClientEmail = AppuserInfo.Email;
				roomtoBook.ClientId = Guid.Parse(AppuserInfo.Id);
				roomtoBook.StartDayOfCheckin = checkin.Startdate;
				roomtoBook.DurationOfCheckin = checkin.LengthOfStay;
                roomtoBook.DateCheckout = roomtoBook.StartDayOfCheckin.AddDays(roomtoBook.DurationOfCheckin);
                _context.Rooms.Update(roomtoBook);
			}
			
			_context.CheckIns.Update(checkin);       
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
			return default;
		}



		private async Task CreateOrderInOdoo(CheckIn checkIn , long clientId , Room room , long productId)
		{
	   
   

				Dictionary<string, object> saleOrderDict = new Dictionary<string, object>
				{
					{ "name", "H"+checkIn.Id.ToString() },
					{ "partner_id", clientId }
				
				};

				var saleOrderId = await _saleOrderRepository.CreateAsync(
					"sale.order",
					saleOrderDict
				);
			var chekinOrder = new Dictionary<string, object>
					{
						{ "order_id", saleOrderId },
					 
						{ "product_id", productId },
						{ "price_unit", room.Price },
						{ "product_uom_qty", checkIn.LengthOfStay },
						 {"tax_id", null},


					};
			await _saleOrderRepository.CreateAsync("sale.order.line", chekinOrder);
            await UpdateOrderStateInOdoo("H"+checkIn.Id.ToString(), "sale.order", "sale");// set odoo order " bon de commande "



        }

        private async Task<long> UpdateOrderStateInOdoo(string orderId, string model, string state)
        {
            var result = await _saleOrderRepository.Search<List<int>>(model, "name", orderId, 1);
            long Id = 0;
            if (result != null && result.Count > 0)
            {
                Id = result[0];
                var data = new Dictionary<string, object>
            {
                { "state", state}

            };
                await _saleOrderRepository.UpdateAsync(model, Id, data);
                return Id;
            }
            else
            {
                return 0;
            }

        }











        private async Task<long> CreateOdooClient(CheckIn checkIn , Hotel hotel)
		{
			await _saleOrderRepository.Authenticate(hotel.Odoo);
			

			long odooId=0;

			var result = await _saleOrderRepository.Search<List<int>>(
					"res.partner",
					"email",
					checkIn.Email,
					1
				);
		

			if (result != null && result.Count > 0)
			{
				odooId = result[0];
			}
			else
			{

				var data = new Dictionary<string, object>
			{
				{ "name", checkIn.FullName},
				{ "phone", checkIn.PhoneNumber},
		   
				{ "email",  checkIn.Email }
			  
				};

	  
			  
				odooId = await _saleOrderRepository.CreateAsync("res.partner", data);
			}
		   

			return odooId;
		}

		private async Task<long> CreateOdooProductOfTypeChekin(SmartRestaurant.Domain.Entities.Hotel hotel,Room  room)
		{
			var odooId = (long)0;
			if (hotel.Odoo != null)
			{
				var loggedIn = await _saleOrderRepository.Authenticate(hotel.Odoo);
				
		
				
				if (loggedIn)
				{
					
						var result = await _saleOrderRepository.Search<List<int>>(
								"product.template",
								"name",
							   "Room/" + room.Id.ToString(),
								1
							);
			
		if (result != null && result.Count > 0)
			{
				odooId = result[0];
			}
			else
			{

					long categoryId = await getProductServiceId();
					var data = new Dictionary<string, object>
					{
						{ "name","Room/"+room.Id.ToString()},
						{ "detailed_type", "service"},
						{ "pos_categ_id", categoryId},
						{ "available_in_pos", 1},
						{ "taxes_id",null }
					};


					odooId = await _saleOrderRepository.CreateAsync("product.template", data);
			}
				}
			}
			return odooId;
		}

		private async Task<long> getProductServiceId()
		{
	   
			var result = await _saleOrderRepository.Search<List<int>>("pos.category", "name", "service", 1);
			long categoryId = 0;
			if (result != null && result.Count > 0)
			{
				categoryId = result[0];
			}
			else
			{
				var categoryData = new Dictionary<string, object>
				{
					{ "name", "service"}
				};
				categoryId = await _saleOrderRepository.CreateAsync("pos.category", categoryData);
			}

			return categoryId;
		}








































        private async Task addClientNotifications(string clientId, string message, CancellationToken cancellationToken)
        {
            clientId = clientId.ToUpper();
            var clientNotificationDto = new ClientNotificationDto() { Type = ClientNotificationType.HotelCheckin, Message = message, Read = false, CreatedAt = DateTime.Now };

            var pathNotification = clientId + "/Notifications";
            await _fireBase.AddUserCollectionAsync(pathNotification, clientNotificationDto, cancellationToken);

        }


    }
}