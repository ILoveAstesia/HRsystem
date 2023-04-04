using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.Salary
{
    public class DetailsModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public DetailsModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

      public SalaryInfo SalaryInfo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalaryInfo == null)
            {
                return NotFound();
            }

            var salaryinfo = await _context.SalaryInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (salaryinfo == null)
            {
                return NotFound();
            }
            else 
            {
                SalaryInfo = salaryinfo;
            }
            return Page();
        }
    }
}
