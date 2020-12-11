namespace BusinessLogicLayer.DTO.Identity
{
    public class MyUserChangePasswordDTO
    {
        public int Id { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}