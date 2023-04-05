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
    public class IndexModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public IndexModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        public IList<TrainingInfo> TrainingInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TrainingInfo != null)
            {
                TrainingInfo = await _context.TrainingInfo.ToListAsync();
            }
        }
    }
}
