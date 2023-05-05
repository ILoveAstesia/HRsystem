using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HRsystem.Pages.Account
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public IndexModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        public IList<AccountInfo> AccountInfo { get; set; } = default!;

        public string? Infomation { get; set; } = default!;

        public async Task OnGetAsync()
        {


            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //var authority = User.FindFirst("Authority")?.Value;
            //Infomation = "userId:" + userId+ " authority:" + authority;
            /*
            var claims = User.Claims;
            var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var authority = claims.FirstOrDefault(c => c.Type == "Authority")?.Value;
             */


            Infomation = "UserId:" + User.FindFirst(ClaimTypes.NameIdentifier)?.Value + " Authority:" + User.FindFirst("Authority")?.Value; ;

            if (_context.AccountInfo != null)
            {
                AccountInfo = await _context.AccountInfo.ToListAsync();
            }
        }
    }
}
