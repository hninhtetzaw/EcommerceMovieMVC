using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using Mysqlx.Crud;

namespace EcommerceMVC.Repository
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly MoviedbContext _db;
        public OrderItemsRepository(MoviedbContext db)
        {
            _db = db;
        }
        public List<TblOrderItem> CreateOrderItems(List<TblOrderItem> orderItems)
        {
            _db.TblOrderItems.AddRange(orderItems);
            _db.SaveChanges();
            return orderItems;
        }
    }
}
