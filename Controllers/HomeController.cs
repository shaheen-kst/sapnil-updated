using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sapnil.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sapnil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SapnilContext _context;

        public HomeController(ILogger<HomeController> logger, SapnilContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult LastSale( string cell)
        {
            var lastSale = _context.Customers.Where(c => c.CellNo == cell).OrderByDescending(d => d.InvoiceDate).Include(p =>p.Product).Include(p => p.Payment).FirstOrDefault();
            var jResult = JsonConvert.SerializeObject(lastSale,Formatting.None,
                                new JsonSerializerSettings()
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });
            /* var options = new JsonSerializerOptions{
                MaxDepth = 20
            };
            var j = System.Text.Json.JsonSerializer.Serialize<Customer>(lastSale,options); */
            return Json(jResult);
        }
      /*   public JsonResult Details(int id){

          //  var p = _context.Products.Where(e => e.Id == id).SingleOrDefault();
           var p = _context.Products.SingleOrDefault(e => e.Id == id);
            if(p !=null)
            { 
                return Json(p);
            }
            return Json(null);
        } */
        public IActionResult Details(int id)
        {
            _logger.LogDebug("id value :"+id);
             var p = _context.Products.SingleOrDefault(e => e.Id == id);
           _logger.LogDebug("object value :"+p.ToString());
            if(p !=null)
            { 
                return PartialView(p);
              
            } 
            return PartialView(p);
        }
        public IActionResult PaymentDetails(int id)
        {
             var p = _context.Payments.SingleOrDefault(e => e.Id == id);
            if(p !=null)
            { 
                return PartialView(p);
              
            } 
            return PartialView(p);
        }

        public JsonResult test(int id)
        {
            var t = _context.Products.Where(e =>e.Id == id).ToList();
            return Json(t);
        }

    }
}
