using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace HRsystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;
        public class LoginModel
        {
        }
        [BindProperty]
        public int Id { get; set; } = default!;
        [BindProperty]
        public string? Password { get; set; } = default!;
        public IndexModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
            //LoginData ??= new LoginModel();
        }

        public string? ErrorMessage { get; set; }
        //public LoginModel LoginData { get; set; }

        public void OnGet()
        {
            //Response.WriteAsync("AlertMassage");
        }


    }

}
