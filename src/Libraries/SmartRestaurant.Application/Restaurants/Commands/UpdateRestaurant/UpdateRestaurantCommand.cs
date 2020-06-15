using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Models.Globalization;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand : IRequest<Guid>
    {
        public Guid RestaurantId { get; set; }
        public string NameArabic { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Description { get; set; }
        public float AverageRating { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFreindly { get; set; }
        public bool OffersTakeout { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public string Tags { get; set; }
        public string Website { get; set; }

    }
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        public UpdateRestaurantCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Restaurants.FindAsync(request.RestaurantId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId);
            }

            entity = new Restaurant()
            {
                AcceptsCreditCards = request.AcceptsCreditCards,
                AcceptTakeout = request.AcceptTakeout,
                AverageRating = request.AverageRating,
                Description = request.Description,
                HasCarParking = request.HasCarParking,
                IsHandicapFreindly = request.IsHandicapFreindly,
                NameArabic = request.NameArabic,
                NameEnglish = request.NameEnglish,
                NameFrench = request.NameFrench,
                OffersTakeout = request.OffersTakeout,
                Tags = request.Tags,
                Website = request.Website,
                PhoneNumber= new PhoneNumber()
                {
                    CountryCode = request.PhoneNumber.CountryCode,
                    Number = request.PhoneNumber.Number
                },
                Address = new Address()
                {
                    City = request.Address.City,
                    StreetAddress = request.Address.StreetAddress,
                    GeoPosition = new GeoPosition()
                    {
                        Latitude = request.Address.GeoPosition.Latitude,
                        Longitude = request.Address.GeoPosition.Longitude
                    }
                }

            };
            _context.Restaurants.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.RestaurantId;
        }
    }
}
