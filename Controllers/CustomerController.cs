using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Sapnil.Models;
using PagedList.Core;

namespace Sapnil.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SapnilContext _context;

        public CustomerController(SapnilContext context)
        {
            _context = context;
        }

        // GET: CustomerControl
        [Authorize]
        public IActionResult Index(string keyword=null, int page=1, int pageSize = 4)
        {
          IQueryable<Customer> customers = null;
          if(string.IsNullOrEmpty(keyword))
           {
            customers = _context.Customers.OrderByDescending(d => d.InvoiceDate).Include(i => i.Product).Include(i => i.Payment);
           PagedList<Customer> model = new PagedList<Customer>(customers, page, pageSize);
           Console.WriteLine("Working");
           return View(model);
           }
           int invoiceNo;
           bool success = Int32.TryParse(keyword.Trim(), out invoiceNo);
           if(!success) invoiceNo =0;
           customers = _context.Customers.Where(m => m.Name.Contains(keyword.Trim()) || m.CellNo == keyword.Trim() || m.InvoiceNo == invoiceNo).OrderByDescending(d => d.InvoiceDate).Include(i => i.Product).Include(i => i.Payment);
           PagedList<Customer> mdl = new PagedList<Customer>(customers,page, pageSize);
          return View(mdl);
        }

        // GET: CustomerControl/Details/5
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

        // GET: CustomerControl/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerControl/Create
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

        // GET: CustomerControl/Edit/5
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

        // POST: CustomerControl/Edit/5
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

        // GET: CustomerControl/Delete/5
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

        // POST: CustomerControl/Delete/5
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

              var clients = _context.Customers.Where(d => d.DeliveryDate >= from && d.DeliveryDate <= to)
              .OrderBy(d => d.DeliveryDate).Include(p => p.Product).Include(p => p.Payment).ToList();
              return View(clients);
           } 
/*            var customers = _context.Customers.OrderByDescending(d => d.InvoiceDate).Include(i => i.Product).Include(i => i.Payment);
           PagedList<Customer> model = new PagedList<Customer>(customers, page, pageSize);
           Console.WriteLine("Working");
           return View(model); */
           return RedirectToAction(nameof(Index));
           
        }
    }
}
