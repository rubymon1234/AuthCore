using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using ShoppyWeb.Models.Common;

namespace ShoppyWeb.Models
{
    public class Product : BaseModel
    {
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Range(0, 5, ErrorMessage = "Rating Should be from 0 to 5 only")] //Range
        public int Ratings { get; set; }

        public Guid CatagoryId { get; set; }

        [ValidateNever]
        [ForeignKey("CatagoryId")]
        public ProductCatagory ProductCatagory { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; } = new List<ProductImages>();

    }
}
