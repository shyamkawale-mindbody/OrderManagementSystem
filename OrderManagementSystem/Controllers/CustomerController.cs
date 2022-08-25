using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        IServiceRepository<Customer, int> custRepo;

        public CustomerController(IServiceRepository<Customer, int> custRepo)
        {
            this.custRepo = custRepo;
        }

        public IActionResult Index()
        {
            ResponseStatus<Customer> response = custRepo.GetRecords();
            return View(response.Records);
        }

        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }


        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                ResponseStatus<Customer> response = custRepo.CreateRecord(customer);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(customer);
            }
        }
    }
}
