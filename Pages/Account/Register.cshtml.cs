using HRsystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;

namespace HRsystem.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [BindProperty]
        [Required]
        public string ID { get; set; }=default!;
        [BindProperty]
        [Required]
        public string Password { get; set; } = default!;


        //[HttpPost]
        public async Task<IActionResult> Register(AccountInfo model)
        {
            if (ModelState.IsValid)
            {
                var id = new IdentityUser { UserName = model.Id.ToString() };
                var result = await userManager.CreateAsync(id, model.Password);

                if (result.Succeeded)
                {
                    return Redirect("/Index");
                    //return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
