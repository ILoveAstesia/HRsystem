using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.Identity
{
    public class DetailsModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public DetailsModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

      public AccountInfo AccountInfo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AccountInfo == null)
            {
                return NotFound();
            }

            var accountinfo = await _context.AccountInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (accountinfo == null)
            {
                return NotFound();
            }
            else 
            {
                AccountInfo = accountinfo;
            }
            return Page();
        }
    }
}
