using Duende.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sturtup_identityServer6
{
    public static class ConfigIdentity
    {
        public const string Admin = "Admin";
        public const string Employee = "Employee";

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("StartupApi", "Api Sturtup")
            };

        public static IEnumerable<Client> clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "Sturtup",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("Rhfcy".Sha256())
                    },
                    AllowedScopes =
                    {
                        "StartupApi" 
                    }
                    
                }
            };
    }
}
