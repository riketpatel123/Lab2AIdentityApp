// I, Riket patel, 000730183, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Lab1BWebAPi.Data;
using Lab1BWebAPi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab1BWebAPi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _roleManager = RoleManager;
        }
        [HttpGet]
        public async Task<IActionResult> SeedRoles()
        {
            ApplicationUser user1 = new ApplicationUser { Email = "jay@gmail.com", UserName = "jay@gmail.com", FirstName = "Jay", LastName = "A", BirthDate = DateTime.Now, Company = "IBM", Position = "Software Developer",};
            ApplicationUser user2 = new ApplicationUser { Email = "james@yahoo.com", UserName = "james@yahoo.com", FirstName = "James", LastName = "Brown", BirthDate = DateTime.Now, Company = "GOOGLE", Position = "Software Engineer",};

            IdentityResult result = await _userManager.CreateAsync(user1, "Mohawk!1");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _userManager.CreateAsync(user2, "Mohawk!1");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _roleManager.CreateAsync(new IdentityRole("Supervisor"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new Roles" });

            result = await _roleManager.CreateAsync(new IdentityRole("Employee"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new Roles" });

            result = await _userManager.AddToRoleAsync(user1, "Supervisor");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });

            result = await _userManager.AddToRoleAsync(user2, "Employee");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });

            return RedirectToAction("Index", "Home");
        }

    }
}