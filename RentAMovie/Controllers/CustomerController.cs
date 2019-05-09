using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentAMovie.Models;
using System.Data.Entity;
using RentAMovie.ViewModel;

namespace RentAMovie.Controllers
{[RequireHttps]
    public class CustomerController : Controller
    {
        private  ApplicationDbContext dbContext = null;

        public List<MembershipType> MembershipTypes { get; private set; }

        public CustomerController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> Customers = dbContext.Customers.Include(m=>m.MembershipType).ToList();
           return View(Customers);
        }
        
        

        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.Include(m=>m.MembershipType).SingleOrDefault(c => c.id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);

        }
        [HttpGet]
        public ActionResult Create()
        {
            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel();
            Customer customer = new Customer();
            var membershipTypes = dbContext.MembershipTypes.ToList();
            viewModel.Customer = customer;
            viewModel.MembershipTypes = membershipTypes;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();//store in db
                return RedirectToAction("Index", "Customer");
            }
            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel();
            Customer customer1 = new Customer();
            var membershipTypes = dbContext.MembershipTypes.ToList();
            viewModel.Customer = customer1;
            viewModel.MembershipTypes = membershipTypes;
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Edit_Customer(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.id == id);
            var memTypes = dbContext.MembershipTypes.ToList();
            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel()
            {
                Customer = customer,
                MembershipTypes = memTypes

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit_Customer(Customer customer)
        {
            var customerTbl = dbContext.Customers.SingleOrDefault(c => c.id == customer.id);
                if(customerTbl==null)
            {
                return HttpNotFound();
            }

            else

            {
                customerTbl.name = customer.name;
                customerTbl.DateOfBirth = customer.DateOfBirth;
                customerTbl.MembershipTypeId = customer.MembershipTypeId;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Customer");
        }
        public List<Customer>GetCustomers()
        {
            List<Customer> customer = new List<Customer>
            {
                new Customer{ id=1,name="Bitre",DateOfBirth=Convert.ToDateTime("27-09-1996")},
                new Customer{ id=2,name="Dilbar",DateOfBirth=Convert.ToDateTime("19-10-1996")},
                new Customer{ id=3,name="Lucky",DateOfBirth=Convert.ToDateTime("24-10-1996")}
            };
            return customer;
        }
    }
}