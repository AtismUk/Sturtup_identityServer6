using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Sturtup_identityServer6.DbContextIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sturtup_identityServer6.Model.DbInitializer
{
    public class Intilializer : IDIntilializer
    {
        private readonly DbContextApp _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _role;

        public Intilializer(DbContextApp db, UserManager<AppUser> userManager, RoleManager<IdentityRole> role)
        {
            _db = db;
            _userManager = userManager;
            _role = role;
        }

        public void Intializer()
        {
            if (_role.FindByNameAsync(ConfigIdentity.Admin).Result == null)
            {
                _role.CreateAsync(new IdentityRole(ConfigIdentity.Admin)).GetAwaiter().GetResult();
                _role.CreateAsync(new IdentityRole(ConfigIdentity.Employee)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            AppUser AdminUser = new()
            {
                UserName = "Anton",
                LastName = "Chaschin",
                Role = "Principal developer",
                Email = "fangun133@gmail.com",
                PhoneNumber = "79141209639",
                EmailConfirmed = true
            };
            _userManager.CreateAsync(AdminUser, "228Atisme*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(AdminUser, ConfigIdentity.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(AdminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, AdminUser.UserName + " " + AdminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, AdminUser.UserName),
                new Claim(JwtClaimTypes.FamilyName, AdminUser.Role),
                new Claim(JwtClaimTypes.Role, ConfigIdentity.Admin)
            }).Result;

            AppUser EmployeeUser = new()
            {
                UserName = "Gleb",
                LastName = "Zelenskiy",
                Role = "Admin",
                Email = "gdfre@gmail.com",
                PhoneNumber = "79145639769",
                EmailConfirmed = true
            };
            _userManager.CreateAsync(EmployeeUser, "228Atisme228*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(EmployeeUser, ConfigIdentity.Employee).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(EmployeeUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, EmployeeUser .UserName + " " + EmployeeUser .LastName),
                new Claim(JwtClaimTypes.GivenName, EmployeeUser .UserName),
                new Claim(JwtClaimTypes.FamilyName, EmployeeUser .Role),
                new Claim(JwtClaimTypes.Role, ConfigIdentity.Admin)
            }).Result;
        }
    }
}
