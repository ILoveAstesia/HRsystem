﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.AdminPersonUi
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
        public PersonBasicInfo PersonBasicInfo { get; set; } = default!;
        //public DepartmentInfo DepartmentInfo { get; set; } = default!;
        //public IList<DepartmentInfo> DepartmentInfoSet { get;set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

          if (!ModelState.IsValid || _context.PersonBasicInfo == null || PersonBasicInfo == null  )
            {
                TempData["Error"]="System PersonBasicInfo table is null";
                return Page();
            }

            int inputId=PersonBasicInfo.DepartmentId;

            bool exists = _context.DepartmentInfo.Any(d => d.Id == inputId);

            if(!exists){
                TempData["Error"]="No Such DepartmentId: "+inputId;
                return Page();
            }

            _context.PersonBasicInfo.Add(PersonBasicInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
