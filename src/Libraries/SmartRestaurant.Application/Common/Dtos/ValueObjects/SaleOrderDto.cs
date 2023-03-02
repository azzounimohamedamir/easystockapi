
using System.Collections.Generic;
using System;
namespace SmartRestaurant.Application.Common.Dtos.ValueObjects
{
public class SaleOrderDto
{
public string Name { get; set; }
    public List<SaleOrderLineDto> OrderLines { get; set; }
    public int PartnerId { get; set; }
    public int SalesPersonId { get; set; }
    // add more fields as needed
}
public class SaleOrderLineDto
{
    public int ProductId { get; set; }
    public double Quantity { get; set; }
    public double PriceUnit { get; set; }
}
}