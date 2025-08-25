namespace ShoppyWeb.ViewModel
{
    public class CartDetailsViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        
    }
}
