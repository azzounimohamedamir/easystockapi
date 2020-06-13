using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}