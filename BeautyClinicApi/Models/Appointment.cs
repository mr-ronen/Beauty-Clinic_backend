namespace BeautyClinicApi.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Status { get; set; } = string.Empty;
        public int AppointmentNumber { get; set; }

        public User User { get; set; } = new User();
        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
