using HRsystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace HRsystem.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly HRsystem.Data.HRsystemContext _context;
        [BindProperty]
        [Required]
        public int Id { get; set; } = default!;
        [BindProperty]
        [Required]
        public string Password { get; set; } = default!;
        public LoginModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
            //LoginData ??= new LoginModel();
        }

        public string? ErrorMessage { get; set; }
        //public LoginModel LoginData { get; set; }

        public void OnGet()
        {
            ErrorMessage = "Testing";
        }
        [BindProperty]
        public string rememberMe { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            //ErrorMessage = "系统账号为空";
            //return Content("<script>alert('Invalid ID or password.');window.location.href='/';</script>", "text/html");

            // 验证用户名和密码
            if (_context.AccountInfo == null)
            {
                ErrorMessage = "系统账号表为空";
                return Page();
            }

            var account = await _context.AccountInfo
                .Where(a => a.Id == Id && a.Password == Password)
                .FirstOrDefaultAsync();

            if (account == null)
            {
                // 如果验证失败，显示错误消息
                ErrorMessage = "无效的用户名或密码";
                return Page();
            }

            /*
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim("Authority", account.Authority.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
             */

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                    new Claim("Authority", account.Authority.ToString())
                };

            /*
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
             */

            //如果需要读取cookie使用以下代码

            /*
             * var userName = User.FindFirst(ClaimTypes.Name)?.Value;
             * var authority = User.FindFirst("Authority")?.Value;
            */
            string returnUrl = Request.Query["ReturnUrl"];

            bool isRemember = rememberMe == "true" ? true : false;

            AuthenticationProperties authProperties = new()
            {
                IsPersistent = isRemember,//是否持久化
                //如果用户点“登录“进来，登录成功后跳转到首页，否则跳转到上一个页面
                RedirectUri = string.IsNullOrWhiteSpace(returnUrl) ? "/Index" : returnUrl,
                ExpiresUtc = DateTime.UtcNow.AddMonths(1) //设置 cookie 过期时间：一个月后过期
            };


            //写入cookie
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

            // 如果验证成功，重定向到受保护的页面

            /*
             
            int aut = account.Authority;
            if (aut == 0)
            {
                return RedirectToPage("/Account/index");
                //return RedirectToPage("/Ui/SuperAdminInfo");
                //return RedirectToPage("/Identity/Index");

            }
            else if (aut == 1)
            { return RedirectToPage("/Ui/AdminInfo"); }

            return RedirectToPage("/Ui/PersonInfo");

            //return RedirectToPage("/Person/Details", new { id = account.Id });
             */

            /*
            return RedirectToPage("/Identity/Index");
             */


            return Page();

        }


    }
}
