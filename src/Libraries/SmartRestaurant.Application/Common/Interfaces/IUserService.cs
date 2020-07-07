using SmartRestaurant.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> Authenticate(string Email, string password);
        Task<List<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(Guid id);
        Task<Guid> Create(ApplicationUser user, string password, CancellationToken cancellationToken);
        Task<Guid> Update(ApplicationUser user, string password, CancellationToken cancellationToken);
        void Delete(Guid id, CancellationToken cancellationToken);
    }
}