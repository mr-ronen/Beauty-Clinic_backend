namespace BeautyClinicApi.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Status { get; set; }
        public int AppointmentNumber { get; set; }

         public UserDTO User { get; set; }
         public List<ServiceDTO> Services { get; set; }
    }
}
