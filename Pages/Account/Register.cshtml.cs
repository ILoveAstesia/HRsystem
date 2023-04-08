using HRsystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace HRsystem.Pages.Account
{
    public class RegisterModel : PageModel
    {
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly HRsystem.Data.HRsystemContext _context;
        public RegisterModel(/*UserManager<IdentityUser> userManager,*/HRsystem.Data.HRsystemContext context)
        {
            //_userManager = userManager;
            _context = context;
        }
        [BindProperty]
        [Required]
        public string inputID { get; set; }=default!;
        [BindProperty]
        [Required]
        public string inputPassword { get; set; } = default!;

        public string information { get; set; } = default!;
        //[HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                information += "Your account information is not validate: ";
                return Page();
            }

            //var user = new IdentityUser { Id = inputID.ToString() };
            //var result = await _userManager.CreateAsync(user, inputPassword);

            //if (result.Succeeded)
            //{
            //    return Redirect("./Index");
            //    //return RedirectToAction("Index", "Home");
            //}

            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(string.Empty, error.Description);
            //}
            
            //if(duplicate key){information +="duplicate key"; return page();}

            bool result = int.TryParse(inputID, out int id);
            if (result)
            {
                var user = new AccountInfo { Id = id,Password=inputPassword };
                _context.AccountInfo.Add(user);
                await _context.SaveChangesAsync();
                return Redirect("/Index");
            }


            return Page();
        }
    }
}
