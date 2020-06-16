using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Users.Queries
{
    public class UserQueriesHandler : IRequestHandler<GetUsersListQuery, List<UserDto>>, IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserQueriesHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<UserDto>>(await _userService.GetAllAsync());
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _userService.GetByIdAsync(request.RestaurantId));
        }
    }
}