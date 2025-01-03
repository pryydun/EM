using Microsoft.AspNetCore.Identity;

namespace EM.WebApp.Data
{

    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string? Name { get; set; }

        public string? ProfilePicture { get; set; }
    }
}