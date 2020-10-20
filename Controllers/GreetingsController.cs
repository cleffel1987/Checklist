using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using CheckList.Data;
using CheckList.Models;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CheckList.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GreetingsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ILogger<GreetingsController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public GreetingsController(ApplicationDbContext DB, ILogger<GreetingsController> logger, UserManager<ApplicationUser> userManager)
        {
            db = DB;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<JsonResult> Welcome()
        {
            string salutation = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                var x = DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

                ApplicationUser applicationUser = await _userManager.FindByIdAsync(userId);
                string userName = applicationUser?.UserName; // will give the user's Name
                if (userName.Contains('@'))
                {
                    var newUN = userName.Split('@');
                    userName = newUN == null || newUN.Count() == 0 ? string.Empty : newUN.FirstOrDefault().ToString();
                }
                if (x!=null && x.Equals("PM", StringComparison.CurrentCultureIgnoreCase))
                {
                    salutation = "Good Afternoon, " + userName;
                }
                else
                {
                    salutation = "Good Morning, " + userName;

                }
            }
            else
            {
                salutation = "Welcome!";
            }
            return new JsonResult(salutation);
        }
    }
}
