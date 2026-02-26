namespace EcommerceMVC.Models.OrderDtos
{
    public class ResponseViewOrderHistory
    {
        public string OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }

    }
}
