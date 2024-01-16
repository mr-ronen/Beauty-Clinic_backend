namespace BeautyClinicApi.Models
{
    public class OrderDetailProduct
    {
        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
