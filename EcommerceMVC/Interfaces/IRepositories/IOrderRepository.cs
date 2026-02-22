using EcommerceMVC.Data;
using EcommerceMVC.Models.OrderDtos;

namespace EcommerceMVC.Interfaces.IRepositories
{
    public interface IOrderRepository
    {
        List<TblOrder> GetOrders();
        TblOrder CreateOrder(TblOrder request);
        
    }
}
