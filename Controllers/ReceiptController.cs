using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sapnil.Models;

namespace Sapnil.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly SapnilContext _context;
        public ReceiptController(SapnilContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
         var customer = _context.Customers.OrderByDescending(p => p.InvoiceDate).Include(p => p.Product).Include(p => p.Payment).FirstOrDefault();
            
        return View(customer);
        }

        public IActionResult Test()
        {
            var customer = _context.Customers.OrderByDescending(p => p.InvoiceDate).Include(p => p.Product).Include(p=>p.Payment).FirstOrDefault();
            return View(customer);
        }
    }
}