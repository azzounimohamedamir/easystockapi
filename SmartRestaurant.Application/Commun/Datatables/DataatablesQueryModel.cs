using System.Collections.Generic;
using Newtonsoft.Json;

namespace SmartRestaurant.Application.Commun.Datatables
{
    public class DataatablesQueryModel <T>
    {
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }
        [JsonProperty("recordsFilterd")]
        public int RecordsFilterd { get; set; }
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
    }
}
