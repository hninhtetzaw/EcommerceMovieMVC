using System.Security.Claims;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models.CartDtos;
using EcommerceMVC.Models.OrderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService service)
        {
            _orderService = service;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var results = _orderService.GetOrderLists();
            return View(results);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            string cartJson = HttpContext.Session.GetString("Cart");

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cartItems = JsonConvert.DeserializeObject<List<ResponseCartItem>>(cartJson);

            //cartItem to createOrder            //var requestOrderList = new List<RequestCreateOrder>();

            //foreach(var item in cartObj)
            //{
            //    var order = new RequestCreateOrder
            //    {
            //        Id = item.Id,
            //        MovieName = item.MovieName,
            //        Price = item.Price,
            //        Total = item.Total,
            //        Quantity = item.Quantity
            //    };
            //    requestOrderList.Add(order);                
            //}



            var result = _orderService.CreateOrder(userId, cartItems);

            HttpContext.Session.Remove("Cart");
            HttpContext.Session.Remove("Quantity");


            return RedirectToAction("Checkout","Cart");


        }

        [HttpGet]
        public IActionResult OrderHistory()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var results = _orderService.OrderHistory(userId);

            return View(results);
        }
    }
}
