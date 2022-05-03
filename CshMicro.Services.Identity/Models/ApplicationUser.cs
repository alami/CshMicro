using Microsoft.AspNetCore.Identity;

namespace CshMicro.Services.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
