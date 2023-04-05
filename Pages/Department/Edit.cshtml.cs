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

namespace HRsystem.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public EditModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DepartmentInfo DepartmentInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DepartmentInfo == null)
            {
                return NotFound();
            }

            var departmentinfo =  await _context.DepartmentInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (departmentinfo == null)
            {
                return NotFound();
            }
            DepartmentInfo = departmentinfo;
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

            _context.Attach(DepartmentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentInfoExists(DepartmentInfo.Id))
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

        private bool DepartmentInfoExists(int id)
        {
          return (_context.DepartmentInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
