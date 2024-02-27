using Microsoft.AspNetCore.Identity;

namespace ECommmerceSite.Models.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
