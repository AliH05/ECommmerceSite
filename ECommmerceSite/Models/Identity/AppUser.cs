﻿using Microsoft.AspNetCore.Identity;

namespace ECommmerceSite.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public int CompanyId { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public double UserRewardPoints { get; set; }
        public bool HasCreditCard { get; set; }
    }
}
