using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeautyClinicApi.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Username { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 6)]   
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
       
        public string FullName { get; set; }
        [DefaultValue("Client")]
        public string Role { get; set; } = "Client";

        public byte[]? ProfilePhoto { get; set; } = null;

        public Cart Cart { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
