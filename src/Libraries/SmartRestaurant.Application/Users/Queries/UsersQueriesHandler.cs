using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.Users.Queries
{
    public class UsersQueriesHandler :

        IRequestHandler<GetEmployeesWithinOrganizationQuery, PagedListDto<EmployeDto>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityContext _identityContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public UsersQueriesHandler(IApplicationDbContext context, IMapper mapper, IIdentityContext identityContext,
            IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _identityContext = identityContext;
            _userService = userService;
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

    

     





        #region Get FoodBusinessManagers within organization
        public async Task<PagedListDto<EmployeDto>> Handle(
            GetEmployeesWithinOrganizationQuery request, CancellationToken cancellationToken)
        {
            await ChecksHelper
                .CheckValidation_ThrowExceptionIfQueryIsInvalid<GetEmployeesWithinOrganizationQueryValidator,
                    GetEmployeesWithinOrganizationQuery>(request, cancellationToken).ConfigureAwait(false);
            var foodBusinessAdministratorId =
                ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            await ChecksHelper
                .CheckUserExistence_ThrowExceptionIfUserNotFound(_identityContext, foodBusinessAdministratorId)
                .ConfigureAwait(false);

            var listOfUsersIds = GetUsersIdsByFoodBusinessAdministratorId(foodBusinessAdministratorId);
            var pagedUsersList = GetPagedUsersByRolesAndUsersIds(Roles.FoodBusinessManager.ToString(), listOfUsersIds,
                request.Page, request.PageSize);

            var userList = await pagedUsersList.Data.ToListAsync(cancellationToken).ConfigureAwait(false);
            var foodBusinessManagersDto = _mapper.Map<List<EmployeDto>>(userList);

            await AppendRolesToListOfFoodBusinessManagers(pagedUsersList, foodBusinessManagersDto)
                .ConfigureAwait(false);
           
            return ConstructPagedFoodBusinessManagers(pagedUsersList, foodBusinessManagersDto);
        }

        private List<string> GetUsersIdsByFoodBusinessAdministratorId(string foodBusinessAdministratorId)
        {
            return _identityContext.ApplicationUser
               
                .Select(foodBusinesses => foodBusinesses.Id)
                .ToList();
        }

        private PagedResultBase<ApplicationUser> GetPagedUsersByRolesAndUsersIds(string role,
            List<string> listOfUsersIds, int page, int pageSize)
        {
            return _identityContext.UserRoles.Include(u => u.Role)
                .Where(u => listOfUsersIds.Contains(u.User.Id))
                .Select(u => u.User)
                .GetPaged(page, pageSize);
        }

        private static PagedListDto<EmployeDto> ConstructPagedFoodBusinessManagers(
            PagedResultBase<ApplicationUser> pagedUsersList, List<EmployeDto> foodBusinessEmployeesDto)
        {
            return new PagedListDto<EmployeDto>(pagedUsersList.CurrentPage,
                pagedUsersList.PageCount, pagedUsersList.PageSize, pagedUsersList.RowCount, foodBusinessEmployeesDto);
        }

        private async Task AppendRolesToListOfFoodBusinessManagers(PagedResultBase<ApplicationUser> pagedUsersList,
            List<EmployeDto> data)
        {
            foreach (var user in pagedUsersList.Data)
            {
                var userRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                var foodBusinessManager = data.FirstOrDefault(FoodBusinessManager => FoodBusinessManager.Id == user.Id);
                foodBusinessManager.Roles = (List<string>)userRoles;
            }
        }

       
        #endregion







      

     

       


    }
}