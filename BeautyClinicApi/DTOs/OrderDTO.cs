using BeautyClinicApi.Models;

namespace BeautyClinicApi.DTOs
{
    public class OrderDTO
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public int OrderNumber { get; set; }

        public UserDTO User { get; set; }
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
