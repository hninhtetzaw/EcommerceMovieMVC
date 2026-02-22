using EcommerceMVC.Models.CartDtos;
using EcommerceMVC.Models.OrderDtos;

namespace EcommerceMVC.Interfaces.IServices
{
    public interface IOrderService
    {
        List<ResponseCreateOrder> GetOrderLists();
        ResponseCreateOrder CreateOrder(string userId , List<ResponseCartItem> request);
    }
}
