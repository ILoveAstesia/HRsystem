﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRsystem.Pages.AdminPersonUi
{
    public class IndexModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public IndexModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        public IList<PersonBasicInfo> PersonBasicInfo { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Department { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? DepartmentId { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of Departments.
            IQueryable<string> genreQuery = from m in _context.PersonBasicInfo
                                            orderby m.Department.Id
                                            select m.Department.Name;

            var person = from m in _context.PersonBasicInfo
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                person = person.Where(s => s.Name.Contains(SearchString));
            }

            if (DepartmentId!=null)
            {
                person = person.Where(x => x.Department.Id == DepartmentId);
            }

            Department = new SelectList(await genreQuery.Distinct().ToListAsync());
            PersonBasicInfo = await person.ToListAsync();
        }
    }
}
