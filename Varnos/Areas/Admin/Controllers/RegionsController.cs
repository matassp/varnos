using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Varnos.Models;

namespace Varnos.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class RegionsController : Controller
    {
        private readonly varnosContext _context;

        public RegionsController(varnosContext context)
        {
            _context = context;
        }

        // GET: Admin/Regions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regions.ToListAsync());
        }
    }
}
