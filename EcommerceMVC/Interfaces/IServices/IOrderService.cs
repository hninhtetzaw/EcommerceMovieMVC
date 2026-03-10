using EcommerceMVC.Models.CartDtos;
using EcommerceMVC.Models.OrderDtos;

namespace EcommerceMVC.Interfaces.IServices
{
    public interface IOrderService
    {
        List<ResponseOrderList> GetOrderLists();
        ResponseCreateOrder CreateOrder(string userId , List<ResponseCartItem> request);
        List<ResponseViewOrderHistory> OrderHistory(string userId);
    
    }
}
