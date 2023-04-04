using HRsystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRsystem.Pages.Ui
{
    public class PersonInfoModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public PersonInfoModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        public PersonBasicInfo PersonBasicInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersonBasicInfo == null)
            {
                return NotFound();
            }

            var personbasicinfo = await _context.PersonBasicInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (personbasicinfo == null)
            {
                return NotFound();
            }
            else
            {
                PersonBasicInfo = personbasicinfo;
            }
            return Page();
        }
    }
}
