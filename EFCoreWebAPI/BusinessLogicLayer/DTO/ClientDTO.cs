namespace BusinessLogicLayer.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int ClientTypeId { get; set; }
        public byte[] Photo { get; set; }
    }
}