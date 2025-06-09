using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ShoppyWeb.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppyWeb.Models
{
    public class CartDetails : BaseModel
    {
        [Required]
        public string UserId { get; set; }

        [ValidateNever]
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        
        [Required]
        public Guid CartId { get; set; }
        [ValidateNever]
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        [Required]
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public string PaymentStatus { get; set; }

        public string Status {  get; set; }

        [Required]
        public Guid ProductId { get; set; }
        [ValidateNever]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
