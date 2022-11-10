using Common;
using DataAccess.Data;
using HiddenVilla_Server.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HiddenVilla_Server.Service
{
    public class DbInitializer : IDbInitiliazer
    {
        //Initialize first user user roles in db

        private readonly AppDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public DbInitializer(AppDbContext db, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                //pokud jsou nejake cekajici migrace
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

            }
            catch (Exception)
            {
                throw;
            }

            //pokud je role admin vytvorena, nic nedelej, ukonci metodu Initialize
            if (_db.Roles.Any(x => x.Name == SD.Role_Admin)) return;

            //vytvor tri role
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();

            //vytvor usera
            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "efeuereis@gmail.com",
                Email = "efeuereis@gmail.com",
                EmailConfirmed = true

            }, "Admin123*").GetAwaiter().GetResult();

            IdentityUser? user = _db.Users.FirstOrDefault(x => x.Email == "efeuereis@gmail.com");
            
            if (user is not null)
            {
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }

        }
    }
}
        