using System.ComponentModel.DataAnnotations;

namespace BeautyClinicApi.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string FullName { get; set; }
        
        public string Role { get; set; }
        public byte[] ProfilePhoto { get; set; }

      
    }
}