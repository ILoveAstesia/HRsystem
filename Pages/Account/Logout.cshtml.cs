using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HRsystem.Pages.Account
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        public string? Infomation { get; set; } = default!;
        public void OnGet()
        {
            Infomation = "UserId:" + User.FindFirst(ClaimTypes.NameIdentifier)?.Value + " Authority:" + User.FindFirst("Authority")?.Value;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }

    }
}
