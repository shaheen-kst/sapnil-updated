using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sapnil.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using PagedList.Core;

namespace Sapnil.Controllers
{
    public class SumController : Controller
    {
        private readonly SapnilContext _context;
        private readonly ILogger<SumController> _logger;

        public SumController(SapnilContext context, ILogger<SumController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Sum
         [Authorize]
       public IActionResult Index( string name=null, int page=1, int pageSize = 4)
        {
           var customers = _context.Customers.OrderByDescending(d => d.InvoiceDate).Include(i => i.Product).Include(i => i.Payment);
           PagedList<Customer> model = new PagedList<Customer>(customers, page, pageSize);
           Console.WriteLine("Working");
           return View(model);
        }

        // GET: Sum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Sum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceNo,Name,CellNo,Address,InvoiceDate,DeliveryDate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Sum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Sum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceNo,Name,CellNo,Address,InvoiceDate,DeliveryDate")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Sum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Sum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
       
       [Authorize]
       public IActionResult Search (DateTime? from, DateTime? to, int page=1, int pageSize=4)
        {
           if(from !=null && to !=null )
            {
             DateTime  f = (DateTime) from;
               DateTime t = (DateTime) to;
               string fro = f.ToString("yyyy-MM-dd");
               string end =  t.ToString("yyyy-MM-dd");
               ViewBag.from = fro; ViewBag.To = end;
               DateTime mTo =(DateTime) to;
               var hTo = mTo.AddHours(23).AddMinutes(59).AddSeconds(59);
               _logger.LogDebug(hTo.ToString());

               var clients = _context.Customers.Where(d => d.InvoiceDate >= from && d.InvoiceDate <= hTo)
              .OrderBy(d => d.DeliveryDate).Include(p => p.Product).Include(p => p.Payment).ToList(); 

                var net = _context.Payments.Where(e => e.EntryDate >= from && e.EntryDate <= hTo).ToList();
               ViewBag.clients = clients; 
              return View(net);
           } 
          
           return View();
           
        }
    }
}
