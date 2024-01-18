using System.ComponentModel.DataAnnotations;


    namespace BeautyClinicApi.DTOs
    {
        public class LogInDTO
        {
            [Required]
            public string Username { get; set; }
            [Required]

            public string Password { get; set; }
            


        }
    }

