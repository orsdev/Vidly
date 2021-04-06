using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        /*
             *  links the database server to the data model class
         */
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customers = new Customers(),
                MembershipTypes = membershipTypes
            };

            return View("AddCustomer", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customers customers)
        {
            if(customers.Id == 0)
            {
                _context.Customers.Add(customers);
            }else
            {
                var DbCustomer = _context.Customers.SingleOrDefault(c => c.Id == customers.Id);

                if(DbCustomer == null)
                {
                    return HttpNotFound();
                }

                DbCustomer.Name = customers.Name;
                DbCustomer.DOB = customers.DOB;
                DbCustomer.IsSubscribedToNewsletter = customers.IsSubscribedToNewsletter;
                DbCustomer.MembershipTypeId = customers.MembershipTypeId;
            }
          
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
            
        }

        public ActionResult Edit(int id)
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customers == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customers = customers,
                MembershipTypes = membershipTypes
            };

            return View("AddCustomer", viewModel);
        }
    }
}