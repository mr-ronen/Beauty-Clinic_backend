using BeautyClinicApi.Models;

namespace BeautyClinicApi.DTOs
{
    public class OrderDetailDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public OrderDTO Order { get; set; }
        public ProductDTO Product { get; set; }
    }
}