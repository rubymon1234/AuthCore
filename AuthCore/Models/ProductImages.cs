using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ShoppyWeb.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppyWeb.Models
{
    public class ProductImages : BaseModel
    {
        [Required]
        [Display(Name = "Product Url")]
        public string url { get; set; }

        public Guid ProductId { get; set; }

        [ValidateNever]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
