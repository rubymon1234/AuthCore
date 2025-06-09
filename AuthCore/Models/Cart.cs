using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using ShoppyWeb.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppyWeb.Models
{
    public class Cart : BaseModel
    {
        [Required]
        public string UserId { get; set; }

        [ValidateNever]
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public int IsActive { get; set; } = 1; // 1 -Active , 0 - InActive
    }
}
