namespace ShoppyWeb.ViewModel
{
    public class CreatePermissionViewModel
    {
        public int? Id { get; set; } 
        public string DisplayName { get; set; }
        public string PermissionName { get; set; }
        public string Discription { get; set; } = string.Empty;

        public string Scenario { get; set; }
    }
}
