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

        public async Task<IActionResult> OnPostAsync()
        {
            //ErrorMessage = "ϵͳ�˺�Ϊ��";
            //return Content("<script>alert('Invalid ID or password.');window.location.href='/';</script>", "text/html");

            // ��֤�û���������
            if (_context.AccountInfo == null)
            {
                ErrorMessage = "ϵͳ�˺�Ϊ��";
                return Page();
            }

            var account = await _context.AccountInfo
                .Where(a => a.Id == Id && a.Password == Password)
                .FirstOrDefaultAsync();



            if (account == null)
            {
                // �����֤ʧ�ܣ���ʾ������Ϣ
                ErrorMessage = "��Ч���û���������";
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

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //�����Ҫ��ȡcookieʹ�����´���

            /*
             * var userName = User.FindFirst(ClaimTypes.Name)?.Value;
             * var authority = User.FindFirst("Authority")?.Value;
            */

            //д��cookie
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // �����֤�ɹ����ض����ܱ�����ҳ��


            int aut = account.Authority;
            if (aut == 0)
            {
                return RedirectToPage("/Ui/SuperAdminInfo");
                //return RedirectToPage("/Identity/Index");

            }
            else if (aut == 1)
            { return RedirectToPage("/Ui/AdminInfo"); }

            return RedirectToPage("/Ui/PersonInfo");

            //return RedirectToPage("/Person/Details", new { id = account.Id });

            /*
            return RedirectToPage("/Identity/Index");
             */




        }


    }
}
