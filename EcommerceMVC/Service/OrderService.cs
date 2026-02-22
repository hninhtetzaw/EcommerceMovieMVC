using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models.CartDtos;
using EcommerceMVC.Models.OrderDtos;

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

        public List<ResponseCreateOrder> GetOrderLists()
        {
            return null;
        }
        public ResponseCreateOrder CreateOrder(string userId, List<ResponseCartItem> request)
        {
            //dto to domain

            var order = new TblOrder
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = request.First().Total,
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
    }
}
