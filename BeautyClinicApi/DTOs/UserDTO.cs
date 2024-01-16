namespace BeautyClinicApi.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public byte[] ProfilePhoto { get; set; }

        public ICollection<OrderDTO>? Orders { get; set; }
        public ICollection<AppointmentDTO>? Appointments { get; set; }
    }
}