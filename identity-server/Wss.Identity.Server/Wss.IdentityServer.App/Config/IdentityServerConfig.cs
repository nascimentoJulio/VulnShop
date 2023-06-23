using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Wss.IdentityServer.App.Config
{
    public class IdentityServerConfig
    {
        public static List<TestUser> TestUsers =>
           new List<TestUser>
           {
                new TestUser
                {
                     SubjectId = "1144",
                     Username = "macoratti",
                     Password = "numsey",
                     Claims =
                     {
                        new Claim(JwtClaimTypes.Name, "Macoratti Net"), 
                        new Claim(JwtClaimTypes.GivenName, "Macoratti"),
                        new Claim(JwtClaimTypes.FamilyName, "Net"),
                        new Claim(JwtClaimTypes.Email, "marcola@gmail.com"),
                        new Claim(JwtClaimTypes.WebSite, "http://macoratti.net"),
                     }
              }
       };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
               new IdentityResources.Email(),
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
               new ApiResource("myApi")
               {
                   Scopes = new List<string>{ "myApi.read","myApi.write" },
                   ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
               }
            };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read" },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    Claims = TestUsers.First().Claims.Select(x => new ClientClaim{ Type = x.Type, Value = x.Value}).ToList(),
                    AlwaysSendClientClaims = true,
                },
            };
    }
}
