using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.Training
{
    public class DeleteModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public DeleteModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TrainingInfo TrainingInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TrainingInfo == null)
            {
                return NotFound();
            }

            var traininginfo = await _context.TrainingInfo.FirstOrDefaultAsync(m => m.Id == id);

            if (traininginfo == null)
            {
                return NotFound();
            }
            else 
            {
                TrainingInfo = traininginfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TrainingInfo == null)
            {
                return NotFound();
            }
            var traininginfo = await _context.TrainingInfo.FindAsync(id);

            if (traininginfo != null)
            {
                TrainingInfo = traininginfo;
                _context.TrainingInfo.Remove(TrainingInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
