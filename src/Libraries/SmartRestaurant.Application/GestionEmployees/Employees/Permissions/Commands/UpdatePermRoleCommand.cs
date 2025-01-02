using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Common.Enums;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Commands
{
    public class UpdatePermRoleCommand : UpdateCommand
    {
        public string Role { get; set; }
        public bool Gds { get; set; }
        public bool Stocks { get; set; }
        public bool StockAlerte { get; set; }
        public bool Unites { get; set; }
        public bool Familles { get; set; }
        public bool Marques { get; set; }
        public bool Inventaires { get; set; }
        public bool Gdv { get; set; }
        public bool Vc { get; set; }
        public bool Bl { get; set; }
        public bool Fac { get; set; }
        public bool Facpro { get; set; }
        public bool Bcv { get; set; }
        public bool RegClients { get; set; }
        public bool FacAvoir { get; set; }
        public bool RetoursProdClient { get; set; }
        public bool CreancesAss { get; set; }
        public bool Gda { get; set; }
        public bool Ba { get; set; }
        public bool Bca { get; set; }
        public bool RegFour { get; set; }
        public bool RetoursProdFour { get; set; }
        public bool Gde { get; set; }
        public bool Clients { get; set; }
        public bool Fournisseurs { get; set; }
        public bool Inviter { get; set; }

    }

    public class UpdatePermRoleCommandValidator : AbstractValidator<UpdatePermRoleCommand>
    {
        public UpdatePermRoleCommandValidator()
        {
            RuleFor(m => m.Role).NotEmpty();
          
        }
    }
}