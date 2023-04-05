using HRsystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace HRsystem.Pages.Account
{
    public class LoginModel : PageModel 
    {

    //    private readonly UserManager<AccountInfo> _userManager;
    //    private readonly SignInManager<AccountInfo> _signInManager;

    //    public LoginModel(UserManager<AccountInfo> userManager, SignInManager<AccountInfo> signInManager)
    //    {
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //    }

    //    [BindProperty]
    //    public InputModel Input { get; set; }

    //    public string ReturnUrl { get; set; }

    //    public string ErrorMessage { get; set; }

    //    public class InputModel
    //    {
    //        [Required]
    //        public int Id { get; set; }

    //        [Required]
    //        [DataType(DataType.Password)]
    //        public string? Password { get; set; }
    //    }

    //    public void OnGet(string returnUrl = null)
    //    {
    //        ReturnUrl = returnUrl;
    //    }

    //    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = await _userManager.FindByEmailAsync(Input.Id.ToString());
    //            if (user != null && await _userManager.CheckPasswordAsync(user, Input.Password))
    //            {
    //                var claims = new List<Claim>
    //            {
    //                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    //                new Claim("Authority", user.Authority.ToString())
    //            };

    //                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    //                var principal = new ClaimsPrincipal(identity);

    //                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    //                return LocalRedirect(returnUrl ?? Url.Content("~/"));
    //            }
    //            else
    //            {
    //                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
    //            }
    //        }

    //        return Page();
    //    }
    }
}
