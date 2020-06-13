using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Services.Models
{
    public class ServiceModel
    {
        public string Id { get; set; }
        public string ServiceName { get; set; }
        public string RestaurantId { get; set; }
        //DateService StartDate, EndDate, StartTime, EndTime
        public List<SectionModel> Sections { get; set; }
        public bool IsClosed { get; set; }
        public string Alias { get;  set; }
        public string SlugUrl { get;  set; }
    }
}
