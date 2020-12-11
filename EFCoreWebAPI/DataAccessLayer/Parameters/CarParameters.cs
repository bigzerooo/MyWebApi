namespace DataAccessLayer.Parameters
{
    public class CarParameters : QueryStringParameters
    {
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = decimal.MaxValue;
        public bool ValidPriceRange => MaxPrice >= MinPrice && MinPrice >= 0;
        public string Brand { get; set; }
    }
}