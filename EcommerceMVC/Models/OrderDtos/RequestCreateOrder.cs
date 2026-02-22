namespace EcommerceMVC.Models.OrderDtos
{
    public class RequestCreateOrder
    {
        public string Id { get; set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
