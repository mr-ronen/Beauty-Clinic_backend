namespace BeautyClinicApi.DTOs
{
    public class UpdateUserRoleDto
    {
        public int UserId { get; set; }
        public string? NewRole { get; set; }
        public UpdateUserRoleDto()
        {
            NewRole = "Client"; 
        }
    }
}

