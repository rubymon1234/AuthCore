using ShoppyWeb.Models;

namespace ShoppyWeb.ViewModel
{
    public class ProductDetailsVm
    {
        public Guid pId { get; set; }

        public string pName { get; set; }
        public string pCode { get; set; }
        public string ImageUrl { get; set; }

        public int Price { get; set; }
        public string CatagoryName { get; set; }
        public int Quantity { get; set; } = 1;

    }
}
