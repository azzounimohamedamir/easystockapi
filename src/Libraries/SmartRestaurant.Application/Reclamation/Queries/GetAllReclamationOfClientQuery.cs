using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Reclamation.Queries
{
  
        public class GetAllReclamationOfClientQuery : IPagedListQuery<ReclamationDto>
        {

            public int Page { get; set; }
            public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }

    }
    
}
