﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace HRsystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;
        public class LoginModel
        {
            public int Id { get; set; } = 0;
            public string? Password { get; set; }
        }
        public IndexModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
            LoginData ??= new LoginModel();
        }

        public string? ErrorMessage { get; set; }
        [BindProperty]
        public LoginModel LoginData { get; set; }

        public void OnGet()
        {
            ErrorMessage = "Testing";
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            //ErrorMessage = "系统账号为空";
            //return Content("<script>alert('Invalid ID or password.');window.location.href='/';</script>", "text/html");
            
            // 验证用户名和密码
            if (_context.AccountInfo == null || LoginData==null)
            {
                ErrorMessage = "系统账号为空";
                return Page();
            }

            var account = await _context.AccountInfo
                .Where(a => a.Id == LoginData.Id && a.Password == LoginData.Password)
                .FirstOrDefaultAsync();



            if (account != null)
            {
               int aut = account.Autority;
                // 如果验证成功，重定向到受保护的页面
                if (aut==0)
                { return RedirectToPage("/Identity/Index"); }
                else if(aut ==1)
                { return RedirectToPage("/Salary/Index"); }
                return RedirectToPage("/Person/Details?id=202002");
                return RedirectToPage("/Person/Details/" + account.Id);
            }
            else
            {
                // 如果验证失败，显示错误消息
                ErrorMessage = "无效的用户名或密码";
            }
            return Page();
        }

       
        
    }

}
