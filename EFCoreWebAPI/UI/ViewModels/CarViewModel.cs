namespace UI.ViewModels
{
    public class CarViewModel
    {
        public int id { get; set; }
        public string brand { get; set; }
        public decimal price { get; set; }
        public decimal pricePerHour { get; set; }
        public int carTypeId { get; set; }
        public int? year { get; set; }
        public string imagePath { get; set; }
        public string description { get; set; }
    }
}
