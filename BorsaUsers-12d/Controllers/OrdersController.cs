using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BorsaUsers_12d.Data;
using Microsoft.AspNetCore.Identity;
using BorsaUsers_12d.Models;

namespace BorsaUsers_12d.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BorsaDbContext _context;
        private readonly UserManager<Customer> _userManager;
        //private readonly SignInManager<User> _sigInManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public OrdersController(BorsaDbContext context,
                                UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var borsaDbContext = _context.Orders.Include(o => o.Customers).Include(o => o.Products);
            return View(await borsaDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customers)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            //OrderVM currentOrder = new OrderVM();
            ////currentOrder.CustomerId = _userManager.GetUserId(User);
            //currentOrder.Products = _context.Products.Select(x => new SelectListItem
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString(),
            //    Selected = (x.Id == currentOrder.ProductId)
            //}
            //).ToList();
            //>>>> ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id");
            ViewBag.ProductId = new SelectList(_context.Products, "Id", "Name");

            //ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
            //return View(currentOrder);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.CustomerId = _userManager.GetUserId(User);
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", order.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", order.ProductId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            //>>> ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", order.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", order.ProductId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                //ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", order.CustomerId);
                ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", order.ProductId);
                return View(order);
            }
            //The MODEL IS VALID
            try
            {
                order.CustomerId = _userManager.GetUserId(User);
                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.Id))
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

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customers)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'BorsaDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
