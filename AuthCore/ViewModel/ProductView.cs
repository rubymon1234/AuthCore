namespace AuthCore.ViewModel
{
    public class ProductView
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Ratings { get; set; }
        public DateTime CreatedOn { get; set; }

        public string imageurl { get; set; }
    }
}
