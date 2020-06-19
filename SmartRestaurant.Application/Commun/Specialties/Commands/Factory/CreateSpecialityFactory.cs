using SmartRestaurant.Domain.Commun;
using System;

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
                Id = Guid.NewGuid(),
                Name = name,
                Alias = alias,
                Description = description,
                IsDisabled = isDisabled,

            };
        }
    }
}
