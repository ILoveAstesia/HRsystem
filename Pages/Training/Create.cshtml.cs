﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.Training
{
    public class CreateModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public CreateModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TrainingInfo TrainingInfo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TrainingInfo == null || TrainingInfo == null)
            {
                return Page();
            }

            _context.TrainingInfo.Add(TrainingInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
