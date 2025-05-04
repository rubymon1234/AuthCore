using AuthCore.Models.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthCore.Models
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
