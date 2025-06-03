using ShoppyWeb.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoppyWeb.Models
{
    public class ProductCatagory : BaseModel 
    {
        [Required]
        [Display(Name = "Product Catagory")]
        public string Name { get; set; }

        public int IsActive { get; set; } = 1; // 1 -Active , 0 - InActive
    }
}
