namespace SmartRestaurant.Application.Commun.Galleries.Pictures.Models
{
    public class PictureModel : IPictureModel
    {
        public string Id { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
