using System.Linq;
using System.Web.Mvc;
using BootcampDistributedSystems.Handlers.PlaceOrder;
using BootcampDistributedSystems.Helpers;
using BootcampDistributedSystems.Models;

namespace BootcampDistributedSystems.Controllers
{
    public class Demo3Controller
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
            //Verify Command
            //Out of scope

            BusHelper.Send(new Messages.PlaceOrderDemo3Command
            {
                CustomerName = command.CustomerName,
                CustomerEmail = command.CustomerEmail,
                OrderLines = command.OrderLines.Select(ol => new Messages.PlaceOrderDemo3Command.OrderLine
                {
                    Quantity = ol.Quantity,
                    Product = new Messages.PlaceOrderDemo3Command.Product
                    {
                        Code = ol.Product.Code,
                        Description = ol.Product.Description,
                        Price = ol.Product.Price
                    }
                })
            });
            return RedirectToAction("Index", "Success");
        }
    }
}