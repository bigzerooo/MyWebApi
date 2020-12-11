namespace BusinessLogicLayer.DTO.Identity
{
    public class MyUserLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}