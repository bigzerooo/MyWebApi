namespace UI.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerHour { get; set; }
        public int CarTypeId { get; set; }
        public int? Year { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
