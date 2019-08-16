using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Interfaces
{
    public interface ISmartRestaurantDatabaseService
    {
        #region Food
        /// <summary>
        /// Table des aliments
        /// </summary>
        DbSet<Food> Foods { get; set; }
        /// <summary>
        /// Table des catégories d'aliments
        /// </summary>
        DbSet<FoodCategory> FoodCategories { get; set; }
        /// <summary>
        /// Table de composition d'aliment Left=Aliment; Right=Aliment et la quantité de chaque partie left,right
        /// </summary>
        DbSet<FoodComposition> FoodCompositions { get; set; }
        #endregion


        DbSet<Picture> Pictures { get; set; }

        DbSet<Country> Countries { get; set; }

        DbSet<Currency> Currencies { get; set; }

        DbSet<State> States { get; set; }
        DbSet<City> Cities{ get; set; }
        void Save();
    }
}
