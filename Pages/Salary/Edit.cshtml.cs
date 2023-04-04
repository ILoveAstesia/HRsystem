using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.Salarys
{
    public class EditModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public EditModel(HRsystem.Data.HRsystemContext context)
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

            var salaryinfo =  await _context.SalaryInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (salaryinfo == null)
            {
                return NotFound();
            }
            SalaryInfo = salaryinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SalaryInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryInfoExists(SalaryInfo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SalaryInfoExists(int id)
        {
          return (_context.SalaryInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
