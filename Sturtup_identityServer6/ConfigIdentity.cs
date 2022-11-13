using Duende.IdentityServer;
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

        public static IEnumerable<IdentityResource> identityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
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
                    ClientId = "sturtup",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets =
                    {
                        new Secret("Rhfcy".Sha256())
                    },
                    RedirectUris = { "http://localhost:5068/signin-oidc/" },
                    PostLogoutRedirectUris = { "http://localhost:5068/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        "StartupApi",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    }
                    
                }
            };
    }
}
