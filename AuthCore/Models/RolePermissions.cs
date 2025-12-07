using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ShoppyWeb.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppyWeb.Models
{
    public class RolePermissions : BaseModel
    {
        public string RoleId { get; set; }

        [ValidateNever]
        [ForeignKey("RoleId")]
        public IdentityRole Roles { get; set; }

        public Guid PermissionId { get; set; }

        [ValidateNever]
        [ForeignKey("PermissionId")]
        public Permissions Permission { get; set; }

    }
}
