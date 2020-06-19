using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Commun.Specialites.Commands.Factory
{
    public interface IUpdateSpecialityFactory
    {
        Speciality Create(
            Speciality source,
            string name,
            string alias,
            string description,
            bool isDesabled);
    }
    public class UpdateSpecialityFactory : IUpdateSpecialityFactory
    {
        public Speciality Create(
            Speciality source,
            string name,
            string alias,
            string description,
            bool isDesabled)
        {
            source.Name = name;
            source.Alias = alias;
            source.Description = description;
            source.IsDisabled = isDesabled;
            return source;
        }
    }
}
