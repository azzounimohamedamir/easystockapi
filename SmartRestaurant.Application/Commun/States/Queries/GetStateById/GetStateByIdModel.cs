using System.Collections.Generic;
using SmartRestaurant.Application.Commun.Select;

namespace SmartRestaurant.Application.Commun.States.Queries.GetStateById
{
    public class GetStateByIdModel 
    {
        public string Id { get; set; }
        public string CountryId { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Alias { get; set; }
        public string CountryName { get; set; }
        public string CountryIsoCode { get; set; }
       // public List<SelectItemModel> Countries { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}