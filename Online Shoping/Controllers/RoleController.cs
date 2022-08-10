using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace mvctestproject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string rolename)
        {
            if(rolename !=null)
            {
                IdentityRole role = new IdentityRole();
                role.Name = rolename;
                IdentityResult result=await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewData["errors"] = result.Errors;
                }
            }
            ViewData["role"] = rolename;
            return View();
        }


    }
}
