using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sturtup_identityServer6.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sturtup_identityServer6.DbContextIdentity
{
    public class DbContextApp : IdentityDbContext<AppUser>
    {
        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
        {

        }
    }
}
