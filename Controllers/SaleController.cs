using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Sapnil.Models;


namespace Sapnil.Controllers
{
    public class SaleController : Controller
    {
        private readonly SapnilContext _context;
        private readonly ILogger<SaleController> _logger;

        public SaleController(SapnilContext context, ILogger<SaleController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Sale
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: Sale/Details/5
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

        // GET: Sale/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name,CellNo,Address,DeliveryDate,FrameName,FrameQty,FramePrice,PowerLense,PowerLenseQty,PowerLensePrice,ContactLense,ContactLenseQty,ContactLensePrice,LeftEyeSph,LeftEyeCyl,LeftEyeAxis,LeftEyeAdd,RightEyeSph,RightEyeCyl,RightEyeAxis,RightEyeAdd,FocalOption,DeliveryStatus,TotalAmmount,DiscountAmount,NetAmount,PaidAmount,DueAmount,EntryDate,Ipd")]
             ProductVM productVM)
        {
             var exp = ExpirationDate();
            // _logger.LogDebug("exp :"+ exp);

             if( exp == false)
             {
                 ModelState.AddModelError("","Trial Period Expired!!! Contact 01721505978 for renewal.");
                 return View();
             }
            if (ModelState.IsValid)
            {
                if(productVM.FramePrice == null && productVM.PowerLensePrice == null && productVM.ContactLensePrice == null)
                {
                    ModelState.AddModelError("","You must purchase at least one product");
                    return View(productVM);
                }
                Product product = new Product(){
                    FrameName = productVM.FrameName,FrameQty = productVM.FrameQty,FramePrice = productVM.FramePrice,PowerLense =productVM.PowerLense,
                    PowerLenseQty = productVM.PowerLenseQty,PowerLensePrice = productVM.PowerLensePrice,ContactLense = productVM.ContactLense,
                    ContactLenseQty = productVM.ContactLenseQty,ContactLensePrice = productVM.ContactLensePrice,LeftEyeSph = productVM.LeftEyeSph,
                    LeftEyeCyl = productVM.LeftEyeCyl,LeftEyeAxis = productVM.LeftEyeAxis,LeftEyeAdd = productVM.LeftEyeAdd,RightEyeSph = productVM.RightEyeSph,
                    RightEyeCyl = productVM.RightEyeCyl,RightEyeAxis = productVM.RightEyeAxis,RightEyeAdd = productVM.RightEyeAdd,FocalOption = productVM.FocalOption,DeliveryStatus = productVM.DeliveryStatus, Ipd = productVM.Ipd
                };
                Payment payment = new Payment{
                    TotalAmmount = productVM.TotalAmmount,DiscountAmount = productVM.DiscountAmount,NetAmount = productVM.NetAmount,
                    PaidAmount = productVM.PaidAmount,DueAmount = productVM.DueAmount, EntryDate = DateTime.Now
                };
                Customer customer = new Customer {
                    Name = productVM.Name,CellNo =productVM.CellNo,DeliveryDate = productVM.DeliveryDate,Product = product,
                    Payment = payment,InvoiceNo = InvoiceNo(),InvoiceDate = DateTime.Now,Address = productVM.Address
                };
    
                
                _context.Add(customer);
                await _context.SaveChangesAsync();
               /*  PurchasedItemVM item1 = new PurchasedItemVM(){
                    ItemName = product.FrameName, ItemQty = product.FrameQty,Itemprice = product.FramePrice
                };
                PurchasedItemVM item2 = new PurchasedItemVM{
                    ItemName =  Enum.GetName(typeof(LenseCategory),(int)product.PowerLense),ItemQty = product.PowerLenseQty,
                    Itemprice = product.PowerLensePrice
                };
                PurchasedItemVM item3 = new PurchasedItemVM{
                    ItemName = Enum.GetName(typeof(ContactLenseCategory),(int)product.ContactLense),ItemQty = product.ContactLenseQty,
                    Itemprice = product.ContactLensePrice
                };

                IList<PurchasedItemVM> list = new List<PurchasedItemVM>();
                list.Add(item1);
                list.Add(item2);
                list.Add(item3);


                

                ReceiptVM rv = new ReceiptVM{
                    InvoiceNo = customer.InvoiceNo,Name = customer.Name,CellNo = customer.CellNo,Address = customer.Address,
                    InvoiceDate = customer.InvoiceDate, DeliveryDate = customer.DeliveryDate,PurchasedItems = list
                }; */
                    
                
                
                
                return RedirectToAction(nameof(Index),"Receipt");
            }
            return View(productVM);
        }

        // GET: Sale/Edit/5
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

        // POST: Sale/Edit/5
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

        // GET: Sale/Delete/5
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

        // POST: Sale/Delete/5
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

        private uint InvoiceNo ()
        {
            var lastRecord = _context.Customers.FirstOrDefault(d => d.InvoiceDate == _context.Customers.Max(x=>x.InvoiceDate));
             uint invoiceNo;
            if(lastRecord == null) 
            {  
                invoiceNo = 100;
            }else {
                 invoiceNo = lastRecord.InvoiceNo +1;
            }
            
            return invoiceNo;
        }

        private bool ExpirationDate()
        {
            var d = DateTime.Parse("2020-02-08");
           // var expDate = d.AddDays(150);
           // 07/05/2020
            var expDate = d.AddDays(150);
            if(DateTime.Now <= expDate)
            {
                _logger.LogDebug("ok");
                return true;
            }
            else 
            {
                _logger.LogDebug("false");
                return false;
                
            }
        }

    }
}
