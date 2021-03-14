namespace BusinessLogicLayer.DTO.Results
{
    public class RequestResultDTO
    {
        public bool IsSuccessful { get; set; } = true;
        public string[] Errors { get; set; } = new string[0];
    }
}
