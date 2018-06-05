using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;


namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        public ActionResult CreateCustomer(NewCustomerViewModel viewModel)
        {
            _context.Customers.Add(viewModel.Customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult NewCustomer()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            NewCustomerViewModel viewmodel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewmodel);
        }


        // GET: Customers
        [Route("customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }


        [Route("customers/CustomerDetails/{id}")]
        public ActionResult CustomerDetails(int? id)
        {
            if (!id.HasValue)
            {
                return new RedirectResult("/customers");
            }
            else
            {
                Customer FoundCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (FoundCustomer != null)
                {
                    return View(FoundCustomer);
                }
                else
                {
                    return new RedirectResult("/customers");
                }

            }
        }
    }
}