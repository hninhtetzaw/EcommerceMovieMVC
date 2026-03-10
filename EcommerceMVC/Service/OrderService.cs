using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models.CartDtos;
using EcommerceMVC.Models.OrderDtos;
using Mysqlx.Crud;

namespace EcommerceMVC.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderItemsRepository _orderItemsRepo;
        public OrderService(IOrderRepository orderRepository,IOrderItemsRepository orderItemsRepository)
        {
            _orderRepo = orderRepository;
            _orderItemsRepo = orderItemsRepository;
        }

        public List<ResponseOrderList> GetOrderLists()
        {
            var lists = _orderRepo.GetOrders();

            var result = new List<ResponseOrderList>();

            foreach(var order in lists)
            {
                var item = new ResponseOrderList
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status
                };
                result.Add(item);

            }

            //var result = lists.Select(order => new ResponseOrderList
            //{
            //    Id = order.Id,
            //    UserId = order.UserId,
            //    OrderDate = order.OrderDate,
            //    TotalAmount = order.TotalAmount,
            //    Status = order.Status
            //}).ToList();
            
            return result;
        }
        public ResponseCreateOrder CreateOrder(string userId, List<ResponseCartItem> request)
        {
            //dto to domain

            var order = new TblOrder
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = request.Sum(x=> x.Total),
                Status = "Pending",
                TblOrderItems = new List<TblOrderItem>()

            };
            var result = _orderRepo.CreateOrder(order);

            //dto to domain
            var orderItems = new List<TblOrderItem>();

            foreach (var item in request)
            {
                var orderItem = new TblOrderItem 
                { 
                    Id = Guid.NewGuid().ToString(),
                    OrderId = result.Id,
                    MovieId = item.Id,
                    Quantity = item.Quantity,
                    Price = item.Price,

                };
                orderItems.Add(orderItem);


            }
            var orderItemsResult = _orderItemsRepo.CreateOrderItems(orderItems);

            var response = new ResponseCreateOrder
            {
                Success = true,
                Message = "Order created successfully"
            };

            return response;



        }
   
        public List<ResponseViewOrderHistory> OrderHistory(string userId)
        {
            var orderLists = _orderRepo.OrderHistory(userId);

            var response = new List<ResponseViewOrderHistory>();

            foreach (var order in orderLists)
            {
                var item = new ResponseViewOrderHistory
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status,
                };
                response.Add(item);
            }

            return response;
        }
    }
}
