using BeautyClinicApi.Models;

namespace BeautyClinicApi.DTOs
{
    public class ServiceDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }

        public ICollection<AppointmentDTO> Appointments { get; set; }

    }
}