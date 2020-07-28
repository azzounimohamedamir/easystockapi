using System;
using MediatR;

namespace SmartRestaurant.Application.Suppliers.Commands
{
    public class DeleteSupplierCommand : IRequest
    {
        public Guid SupplierId { get; set; }
    }
}
