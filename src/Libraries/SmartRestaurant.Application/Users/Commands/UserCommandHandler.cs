using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities.User;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Users.Commands
{
    public class UserCommandHandler :
    IRequestHandler<AuthenticateUserCommand, UserDto>,
    IRequestHandler<CreateUserCommand, Guid>,
    IRequestHandler<UpdateUserCommand, Guid>,
    IRequestHandler<DeleteUserCommand>
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            return await _userService.Create(user, request.Password, cancellationToken);
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            return await _userService.Update(user, request.Password, cancellationToken);
        }

        public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _userService.Delete(request.UserId, cancellationToken);
            return Task.Run(() =>
            {
                return Unit.Value;
            });
        }

        public async Task<UserDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userService.Authenticate(request.Email, request.Password);
            return _mapper.Map<UserDto>(user);
        }
    }
}