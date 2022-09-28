
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

        public HotelsController(IApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Accessoires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotels>>> GetAccessoires()
        {
            return await _context.hotels.ToListAsync();
        }

    }
}
