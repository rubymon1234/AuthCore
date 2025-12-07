using ShoppyWeb.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoppyWeb.Models
{
    public class Permissions : BaseModel
    {
        [Display(Name = "Display Name")]
        public string DispalyName { get; set; }
        [Display(Name = "Permission Name")]
        public string PermissionName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;
    }
}
