using SmartRestaurant.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string Email, string password);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<Guid> Create(User user, string password, CancellationToken cancellationToken);
        Task<Guid> Update(User user, string password = null, CancellationToken cancellationToken);
        void Delete(Guid id, CancellationToken cancellationToken);
    }
}