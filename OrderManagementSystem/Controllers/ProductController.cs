using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        IServiceRepository<Product, int> productRepo;

        public ProductController(IServiceRepository<Product, int> productRepo)
        {
            this.productRepo = productRepo;
        }

        public IActionResult Index()
        {
            ResponseStatus<Product> response = productRepo.GetRecords();
            return View(response.Records);
        }
    }
}
