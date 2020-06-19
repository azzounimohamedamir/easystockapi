namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models
{
    public interface IGalleryPictureModel
    {
        bool IsDisabled { get; set; }
        string Alias { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ImageUrl { get; set; }
        bool IsTheCover { get; set; }
    }
}
