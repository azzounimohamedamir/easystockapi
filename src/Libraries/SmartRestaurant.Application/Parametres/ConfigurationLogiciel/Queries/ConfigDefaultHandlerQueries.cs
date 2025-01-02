using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Stock.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Parametres.ConfigurationLogiciel.Queries
{
    public class ConfigDefaultHandlerQueries :
        IRequestHandler<GetDefaultConfigQuery,Domain.Entities.DefaultConfigLog>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ConfigDefaultHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<Domain.Entities.DefaultConfigLog> Handle(GetDefaultConfigQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDefaultConfigQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var config = _context.DefaultConfigLogs.FirstOrDefault();

            if (config != null)
            {
                return config;
            }
            else
            {
                return null;
            }

           
        }

       
            }
        }
    