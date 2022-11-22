using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sturtup_identityServer6.Model
{
    public class AppUser : IdentityUser
    {
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
