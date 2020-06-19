using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Commun.Specialites.Commands.Factory
{
    public interface ICreateSpecialityFactory
    {
        Speciality Create(             
            string name, 
            string alias,
            string description,
            bool isDisabled);
    }
    public class CreateSpecialityFactory : ICreateSpecialityFactory
    {
        public Speciality Create(            
            string name, 
            string alias, 
            string description,
            bool isDisabled)
        {
            return new Speciality
            {
                Id= Guid.NewGuid(),                
                Name=name,
                Alias=alias,
                Description=description,
                IsDisabled=isDisabled,
                
            };
        }
    }
}
