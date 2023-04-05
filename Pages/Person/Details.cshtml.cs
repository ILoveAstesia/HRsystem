using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HRsystem.Pages.AdminPersonUi
{
    //[Authorize(Policy = "SelfOrAdminOnly")]
    public class DetailsModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public DetailsModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

      public PersonBasicInfo PersonBasicInfo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
                if (id == null)
                {
                    return NotFound();
                }
            // 仅限自己和管理员查看的功能
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _context.AccountInfo.FindAsync(int.Parse(userId));

                if (user == null || (user.Authority > 1 && user.Id != id))
                {
                    return Unauthorized();
                }


            if (id == null || _context.PersonBasicInfo == null)
            {
                return NotFound();
            }

            var personbasicinfo = await _context.PersonBasicInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (personbasicinfo == null)
            {
                return NotFound();
            }
            else 
            {
                PersonBasicInfo = personbasicinfo;
            }
            return Page();
        }
    }
}
