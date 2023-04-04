using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.Salarys
{
    public class DeleteModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public DeleteModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SalaryInfo == null)
            {
                return NotFound();
            }
            var salaryinfo = await _context.SalaryInfo.FindAsync(id);

            if (salaryinfo != null)
            {
                SalaryInfo = salaryinfo;
                _context.SalaryInfo.Remove(SalaryInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
