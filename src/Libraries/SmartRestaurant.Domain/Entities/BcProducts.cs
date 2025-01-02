using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class BcProducts
{
    [Key]
    public Guid Id { get; set; }
    public string Image { get; set; }
    public string Designation { get; set; }
    public decimal Qte { get; set; }
    public decimal MontantHT { get; set; }
    public decimal MontantTVA { get; set; }
    public decimal MontantTTC { get; set; }
    public decimal Puv { get; set; }

    // Navigation property to BonCommandeClient
    public Guid BcId { get; set; }
    [ForeignKey("BcId")]
    public BonCommandeClient BonCommandeClient { get; set; }

    // Foreign key for Stock
    public Guid SelectedStockId { get; set; }
    [ForeignKey("SelectedStockId")]
    public Stock SelectedStock { get; set; }
}


}
