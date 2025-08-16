using jwtTokenAut.Data;
using jwtTokenAut.Models;
using Microsoft.AspNetCore.Identity;

namespace jwtTokenAut.Services
{
    public class KilnInfoServices: IKilnInfoServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _schoolContext;
        public KilnInfoServices(ApplicationDbContext _context, UserManager<ApplicationUser> userManager)
        {

            _schoolContext = _context;
            userManager = userManager;
        }

        public async Task<(int, string)> kilnPostData(KilnInfo model, string role)
        {
            //var userExists = await userManager.FindByNameAsync(model.Username);
            //if (userExists != null)
            //    return (0, "User already exists");

            KilnInfo user = new()
            {
                KilnName = model.KilnName,
                Id = Guid.NewGuid().ToString(),

            };
            _schoolContext.KilnInfos.Add(user);

            await _schoolContext.SaveChangesAsync();

            return (1, "User created successfully!");
        }

    }
}
