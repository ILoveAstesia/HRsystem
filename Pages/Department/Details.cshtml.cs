using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public DetailsModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

      public DepartmentInfo DepartmentInfo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DepartmentInfo == null)
            {
                return NotFound();
            }

            var departmentinfo = await _context.DepartmentInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (departmentinfo == null)
            {
                return NotFound();
            }
            else 
            {
                DepartmentInfo = departmentinfo;
            }
            return Page();
        }
    }
}
