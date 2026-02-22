using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Models.OrderDtos;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MoviedbContext _db;
        public OrderRepository(MoviedbContext db) 
        {
            _db= db;
        }
        public List<TblOrder> GetOrders()
        {
            return null;
        }
        public TblOrder CreateOrder(TblOrder orders)
        {
            _db.TblOrders.Add(orders);
            _db.SaveChanges();
            return orders;
        }
    }
}
