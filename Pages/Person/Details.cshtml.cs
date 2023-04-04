using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.AdminPersonUi
{
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
