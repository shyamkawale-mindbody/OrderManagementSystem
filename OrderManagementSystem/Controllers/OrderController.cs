using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        IServiceRepository<Order, int> orderRepo;

        public OrderController(IServiceRepository<Order, int> orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public IActionResult Index()
        {
            ResponseStatus<Order> response = orderRepo.GetRecords();
            return View(response.Records);
        }
    }
}
