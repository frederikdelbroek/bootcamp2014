using System.Web.Mvc;
using BootcampDistributedSystems.Handlers.PlaceOrder;
using BootcampDistributedSystems.Models;

namespace BootcampDistributedSystems.Controllers
{
    public class Demo1Controller
        : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new OrderViewModel());
        }

        [HttpPost]
        public ActionResult PlaceOrder(PlaceOrderCommand command)
        {
            var handler = new PlaceOrderHandler();
            handler.Handle(command);
            return RedirectToAction("Index", "Success");
        }
    }
}