using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        IBasketService basketService;
        IOrderService orderService;

        public BasketController(IBasketService basketService, IOrderService orderService)
        {
            this.basketService = basketService;
            this.orderService = orderService;
        }

        public ActionResult Index()
        {
            var model = basketService.GetBasketItem(this.HttpContext);
            return View(model);
        }


        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);
            return PartialView(basketSummary);
        }

        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var basketItems = basketService.GetBasketItem(this.HttpContext);
            order.OrderStatus = "Order Created";

            // Prosses Payment

            order.OrderStatus = "Payment Processed";
            orderService.CreateOrder(order, basketItems);
            basketService.ClearBasket(this.HttpContext);
            return RedirectToAction("Thankyou", new { OrderId = order.Id });
        }
        
        public ActionResult Thankyou(string OrderId)
        {
            ViewBag.orderId = OrderId;
            return View();
        }
    }
}