using EcommerceMVC.Data;
using EcommerceMVC.Models.CartDtos;

namespace EcommerceMVC.Interfaces.IRepositories
{
    public interface IOrderItemsRepository
    {
        List<TblOrderItem> CreateOrderItems(List<TblOrderItem> orderItems);

    }
}
