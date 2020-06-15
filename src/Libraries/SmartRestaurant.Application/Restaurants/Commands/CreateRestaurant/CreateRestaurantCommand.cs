using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Models.Globalization;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Restaurants.Commands.CreateRestaurant
{
    public class UpdateRestaurantCommand : IRequest<Guid>
    {
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

    public class CreateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateRestaurantCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Restaurant>(request);
            _context.Restaurants.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.RestaurantId;
        }
    }
}
