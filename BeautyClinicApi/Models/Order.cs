namespace BeautyClinicApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public int OrderNumber { get; set; }


        // Add a property for a single OrderDetail
        public OrderDetail OrderDetail { get; set; }
    }
}
