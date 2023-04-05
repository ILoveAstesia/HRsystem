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
    public class DetailsModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public DetailsModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

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
    }
}
