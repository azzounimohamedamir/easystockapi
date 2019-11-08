using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models
{
    public interface IGalleryModel
    {
        string Id { get; set; }
        bool IsDisabled { get; set; }
        string Alias { get; set; }
        string Name { get; set; }
        string Description { get; set; }        
    }
}