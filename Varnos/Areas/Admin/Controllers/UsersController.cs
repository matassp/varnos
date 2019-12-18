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
    public class UsersController : Controller
    {
        private readonly varnosContext _context;

        public UsersController(varnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var varnosContext = _context.Users.Include(u => u.FkRegionidRegionNavigation);
            return View(await varnosContext.ToListAsync());
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.IdUser == id);
        }
    }
}
