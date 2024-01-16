namespace BeautyClinicApi.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
