using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Update;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Create
{
    public static class TableFactory
    {
        public static Table ToEntity(this CreateTableModel model)
        {
            return new Table
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Name = model.Name,
                Description = model.Description,
                IsDisabled = model.IsDisabled,
                AreaId = model.AreaId.ToGuid(),
            };
        }
        public static void ToEntity(this UpdateTableModel model, ref Table table)
        {

            table.Id = model.Id.ToGuid();
            table.Alias = model.Alias;
            table.Name = model.Name;
            table.Description = model.Description;
            table.IsDisabled = model.IsDisabled;
            table.AreaId = model.AreaId.ToGuid();
        }
    }
}
