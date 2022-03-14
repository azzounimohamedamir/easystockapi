using System.Collections.Generic;
using Newtonsoft.Json;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class PagedListDto<TDto> where TDto : class
    {
        public PagedListDto(int currentPage, int pageCount, int pageSize, int rowCount, List<TDto> data)
        {
            CurrentPage = currentPage;
            PageCount = pageCount;
            PageSize = pageSize;
            RowCount = rowCount;
            Data = data;
        }

        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; protected internal set; }

        [JsonProperty(PropertyName = "perPage")]
        public int PageCount { get; protected internal set; }

        public int PageSize { get; protected internal set; }

        [JsonProperty(PropertyName = "total")] public int RowCount { get; protected internal set; }

        [JsonProperty(PropertyName = "data")] public List<TDto> Data { get; protected internal set; }
    }
}