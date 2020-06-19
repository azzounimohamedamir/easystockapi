using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Datatables
{
    public class DatatablesQueryModel<T>
    {
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }
        [JsonProperty("recordsFilterd")]
        public int RecordsFilterd { get; set; }
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
    }
}
