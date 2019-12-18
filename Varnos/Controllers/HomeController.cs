using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varnos.Models;

namespace Varnos.Controllers
{
    public class HomeController : Controller
    {
        private readonly varnosContext _context;

        public HomeController(varnosContext context)
        {
            _context = context;
        }

        // GET: Home
        public ActionResult Index()
        {
            MockUser();
            string markers = "[";
            foreach (Points point in _context.Points
                .Include(i => i.FkUseridUserNavigation)
                .Include(i => i.ItemPointMap)
                .ThenInclude(map => map.FkItemidItemNavigation).ToList())
            {
                markers += "{";
                ItemPointMap itemPointMap = point.ItemPointMap.First(i => i.FkPointidPoint == point.IdPoint);
                Users user = point.FkUseridUserNavigation;
                string itemName = itemPointMap.FkItemidItemNavigation.Name;
                int itemQuantity = itemPointMap.Quantity ?? default(int);
                markers += string.Format("'title': '{0}',", itemName);
                markers += string.Format("'lat': '{0}',", point.Latitude);
                markers += string.Format("'lng': '{0}',", point.Longitude);
                string description = "<h3>" + itemName + "</h3>";
                description += "<p><b>Quantity:</b> " + itemQuantity + "</p>";
                description += "<p><b>Date:</b> " + String.Format("{0:dd MMM yyyy}", point.Date) + "</p>";
                description += "<p><b>Created by:</b> " + user.Nickname + "</p>";
                markers += string.Format("'description': '{0}'", description);
                markers += "},";
            }
            markers += "];";
            ViewBag.Markers = markers;
            return View(_context.Regions.First());
        }

        private void MockUser()
        {
            HttpContext.Session.SetInt32("userId", 1);
            HttpContext.Session.SetInt32("regionId", 1);
        }
    }
}