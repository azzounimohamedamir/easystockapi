using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Services
{
    public class ServiceStateConfiguration : IEntityTypeConfiguration<ServiceState>
    {
        public void Configure(EntityTypeBuilder<ServiceState> b)
        {
            b.HasKey(a => new { a.ServiceId,a.State });
            b.HasOne(a => a.Service)
                .WithMany(r => r.ServiceStatus)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
