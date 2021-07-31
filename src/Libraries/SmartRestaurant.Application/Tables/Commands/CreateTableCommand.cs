using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Tables.Commands
{
    public class CreateTableCommand : IRequest<Created>
    {
        public Guid Id { get; set; }
        public int TableNumber { get; set; }
        public Guid ZoneId { get; set; }
        public Zone Zone { get; set; }
        public int Capacity { get; set; }
        public short TableState { get; set; }
    }

    public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
        public CreateTableCommandValidator()
        {
            RuleFor(v => v.TableNumber)
                .GreaterThan(0);
            RuleFor(v => v.Capacity)
                .GreaterThan(0);
            RuleFor(v => v.ZoneId)
                .NotEmpty()
                .Must(v => v != Guid.Empty);
        }
    }
}