using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.Reservations.Queries
{
    public class UsersQueriesHandler :
        IRequestHandler<GetFoodBusinessEmployeesQuery, PagedListDto<FoodBusinessEmployeesDtos>>,
        IRequestHandler<GetFoodBusinessManagersWithinOrganizationQuery, PagedListDto<FoodBusinessEmployeesDtos>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityContext _identityContext;
        private readonly IApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersQueriesHandler(IApplicationDbContext context, IMapper mapper, IIdentityContext identityContext, 
            IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _identityContext = identityContext;
            _userService = userService;
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<FoodBusinessEmployeesDtos>> Handle(GetFoodBusinessEmployeesQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFoodBusinessEmployeesValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) 
                throw new Common.Exceptions.ValidationException(result);

            var roles = _userService.GetRoles();
            if(roles == null)
                throw new InvalidOperationException("User role shouldn't be null or  empty");

            var foodBusinesses = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId)).ConfigureAwait(false);
            if (foodBusinesses == null) 
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var usersIdsList = _context.FoodBusinessUsers
            .Where(foodBusinessUsers => foodBusinessUsers.FoodBusinessId == Guid.Parse(request.FoodBusinessId))
            .Select(foodBusinessUsers => foodBusinessUsers.ApplicationUserId).ToList();

            PagedResultBase<ApplicationUser> pagedUsersList = null;
            if (roles.Contains(Roles.FoodBusinessAdministrator.ToString()))
            {
                pagedUsersList = _identityContext.UserRoles.Include(u => u.Role)
                .Where(u => u.Role.Name == Roles.FoodBusinessManager.ToString() && usersIdsList.Contains(u.User.Id))
                .Select(u => u.User)
                .GetPaged(request.Page, request.PageSize);
            }
            else if (roles.Contains(Roles.FoodBusinessManager.ToString()))
            {
                var employeesRoles = new List<string> { Roles.Cashier.ToString(), Roles.Waiter.ToString(), Roles.Chef.ToString() };
                pagedUsersList = _identityContext.UserRoles.Include(u => u.Role)
               .Where(u => employeesRoles.Contains(u.Role.Name) && usersIdsList.Contains(u.User.Id))
               .Select(u => u.User)
               .GetPaged(request.Page, request.PageSize);
            }

            var data = _mapper.Map<List<FoodBusinessEmployeesDtos>>(await pagedUsersList.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));

            foreach (var user in pagedUsersList.Data)
            {
                var userRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                var foodBusinessEmployees = data.FirstOrDefault(FoodBusinessEmployees => FoodBusinessEmployees.Id == user.Id);
                foodBusinessEmployees.Roles = (List<string>) userRoles;
            }

            var pagedFoodBusinessEmployees = new PagedListDto<FoodBusinessEmployeesDtos>(pagedUsersList.CurrentPage, 
                pagedUsersList.PageCount, pagedUsersList.PageSize, pagedUsersList.RowCount, data);
            return pagedFoodBusinessEmployees;
        }

        public async Task<PagedListDto<FoodBusinessEmployeesDtos>> Handle(GetFoodBusinessManagersWithinOrganizationQuery request, CancellationToken cancellationToken)
        {
            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid<GetFoodBusinessManagersWithinOrganizationValidator, GetFoodBusinessManagersWithinOrganizationQuery>(request, cancellationToken).ConfigureAwait(false);
            string foodBusinessAdministratorId = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            await ChecksHelper.CheckUserExistence_ThrowExceptionIfUserNotFound(_identityContext, foodBusinessAdministratorId).ConfigureAwait(false);

            var listOfUsersIds = GetUsersIdsByFoodBusinessAdministratorId(foodBusinessAdministratorId);
            var pagedUsersList = GetPagedUsersByRolesAndUsersIds(Roles.FoodBusinessManager.ToString(), listOfUsersIds, request.Page, request.PageSize);

            var userList = await pagedUsersList.Data.ToListAsync(cancellationToken).ConfigureAwait(false);
            var foodBusinessEmployeesDto = _mapper.Map<List<FoodBusinessEmployeesDtos>>(userList);

            await AppendRolesToListOfFoodBusinessEmployees(pagedUsersList, foodBusinessEmployeesDto).ConfigureAwait(false);
            return ConstructPagedFoodBusinessEmployees(pagedUsersList, foodBusinessEmployeesDto);
        }

        private List<string> GetUsersIdsByFoodBusinessAdministratorId(string foodBusinessAdministratorId)
        {
            return _context.FoodBusinessUsers.Include(foodBusinessUsers => foodBusinessUsers.FoodBusiness)
              .Where(foodBusinessUsers => foodBusinessUsers.FoodBusiness.FoodBusinessAdministratorId == foodBusinessAdministratorId)
              .Select(foodBusinesses => foodBusinesses.ApplicationUserId)
              .ToList();
        }

        private PagedResultBase<ApplicationUser> GetPagedUsersByRolesAndUsersIds(string role, List<string> listOfUsersIds, int page, int pageSize)
        {
            return _identityContext.UserRoles.Include(u => u.Role)
                       .Where(u => u.Role.Name == role && listOfUsersIds.Contains(u.User.Id))
                       .Select(u => u.User)
                       .GetPaged(page,pageSize);
        }

        private static PagedListDto<FoodBusinessEmployeesDtos> ConstructPagedFoodBusinessEmployees(PagedResultBase<ApplicationUser> pagedUsersList, List<FoodBusinessEmployeesDtos> foodBusinessEmployeesDto)
        {
            return new PagedListDto<FoodBusinessEmployeesDtos>(pagedUsersList.CurrentPage,
                pagedUsersList.PageCount, pagedUsersList.PageSize, pagedUsersList.RowCount, foodBusinessEmployeesDto);
        }

        private async Task AppendRolesToListOfFoodBusinessEmployees(PagedResultBase<ApplicationUser> pagedUsersList, List<FoodBusinessEmployeesDtos> data)
        {
            foreach (var user in pagedUsersList.Data)
            {
                var userRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                var foodBusinessManager = data.FirstOrDefault(FoodBusinessEmployees => FoodBusinessEmployees.Id == user.Id);
                foodBusinessManager.Roles = (List<string>)userRoles;
            }
        } 
    }
}