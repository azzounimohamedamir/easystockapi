using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Enumerations;
using System;

namespace SmartRestaurant.Domain
{
    public class Template : BaseEntity<Guid>
    {
        public EnumTemplateType Type { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //TODO: ajoute coloumn Body ?? ERRoR 
        //  public User CreatedBy { get; set; }
    }
}
