using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Varnos.Models;

namespace Varnos.Controllers
{
    public class ItemPointMapController : Controller
    {
        private readonly varnosContext _context;

        public ItemPointMapController(varnosContext context)
        {
            _context = context;
        }

        // GET: ItemPointMaps
        public async Task<IActionResult> Index()
        {
            var varnosContext = _context.ItemPointMap
                .Include(i => i.FkItemidItemNavigation)
                .Include(i => i.FkPointidPointNavigation)
                .Include(i => i.FkPointidPointNavigation.FkRegionidRegionNavigation)
                .Include(i => i.FkPointidPointNavigation.FkUseridUserNavigation);
            var totalQuantity = _context.ItemPointMap.ToList().Select(i => i.Quantity).Sum();
            HttpContext.Session.SetString("totalQuantity", totalQuantity.ToString());
            return View(await varnosContext.ToListAsync());
        }
        
        public async Task<IActionResult> Create(double lat, double lng)
        {
            TempData["lat"] = lat;
            TempData["lng"] = lng;
            AddSelectListToViewData();
            return View();
        }

        private async void AddSelectListToViewData()
        {
            ViewData["FkItemidItem"] = new SelectList(await _context.Items.ToListAsync(), nameof(Items.IdItem), nameof(Items.Name), _context.Items.First());
            ViewData["FkPointidPoint"] = new SelectList(await _context.Points.ToListAsync(), nameof(Points.IdPoint), nameof(Points.IdPoint));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("FkItemidItem,FkPointidPoint,Quantity")] ItemPointMap itemPointMap)
        {
            if (!ModelState.IsValid)
            {
                AddSelectListToViewData();
                return View(itemPointMap);
            }
            try
            {
                Points point = new Points();
                point.Latitude = (decimal)(double)TempData["lat"];
                point.Longitude = (decimal)(double)TempData["lng"];
                point.FkUseridUser = HttpContext.Session.GetInt32("userId") ?? -1;
                point.FkRegionidRegion = HttpContext.Session.GetInt32("regionId") ?? -1;
                point.Date = DateTime.Now;
                int pointId = _context.Add(point).Entity.IdPoint;
                await _context.SaveChangesAsync();

                itemPointMap.FkPointidPoint = pointId;
                itemPointMap.FkPointidPointNavigation = point;
                _context.Add(itemPointMap);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}