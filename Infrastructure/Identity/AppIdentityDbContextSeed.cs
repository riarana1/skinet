using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager) {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob Smith",
                    Email = "bsmith@awesomesoft.com",
                    UserName = "bsmith@awesomesoft.com",
                    Address = new Address
                    {
                        FirstName = "Bob",
                        LastName = "Smith",
                        Street = "17th Street",
                        City = "New York",
                        State = "NY",
                        Zipcode = "90210"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}