using Microsoft.AspNetCore.Identity;

namespace SubwayApp.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
