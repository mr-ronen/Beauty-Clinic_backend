using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BeautyClinicApi.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
       
        public string FullName { get; set; }
        public string Role { get; set; }

        public byte[]? ProfilePhoto { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
