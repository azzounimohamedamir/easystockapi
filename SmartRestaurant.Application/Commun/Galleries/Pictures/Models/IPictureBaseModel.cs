namespace SmartRestaurant.Application.Commun.Galleries.Pictures.Models
{
    public interface IPictureModel
    {
        string Id { get; set; }
        string Alias { get; set; }
        string Description { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
        string Url { get; set; }

    }
}