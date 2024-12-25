using Microsoft.AspNetCore.Identity;

namespace EM.WebApp.Components.Pages.ViewModel
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;  
    }
}
