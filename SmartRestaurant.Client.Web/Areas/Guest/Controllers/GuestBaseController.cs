using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartRestaurant.Client.Web.Areas.Guest.Controllers
{
    [Area("Guest")]
    [Authorize(Roles = "Guest")]
    public class GuestBaseController : Controller
    {
        
    }
}