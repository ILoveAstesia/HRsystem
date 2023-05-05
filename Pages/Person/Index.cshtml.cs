using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace HRsystem.Pages.Person
{
    [Authorize(Policy = "AdminLest")]
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
        public SelectList? DepartmentList { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? InputId { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of Departments.
            /*
             
            if (m.Department==null)
            {
                return page();
            }

            */

            //if personbasicinfo is null
            //if 
            IQueryable<int> genreQuery = from m in _context.DepartmentInfo 
                                            orderby m.Id
                                            select m.Id;

            var person = from m in _context.PersonBasicInfo
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                person = person.Where(s => s.Name.Contains(SearchString));
            }

            if (InputId != null)
            {
                person = person.Where(x => x.DepartmentId == InputId);
            }

            DepartmentList = new SelectList(await genreQuery.Distinct().ToListAsync());
            PersonBasicInfo = await person.ToListAsync();
            
        }
    }
}
