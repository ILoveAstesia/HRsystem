using HRsystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HRsystem.Pages.Ui
{
    [Authorize]
    public class PersonInfoModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public PersonInfoModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        public string? ErrorMassage { get; set; }
        public PersonBasicInfo PersonBasicInfo { get; set; } = default!;
        public SalaryInfo SalaryInfo { get; set; } = default!;
        public DepartmentInfo DepartmentInfo { get; set; }
        public IList<RewardingAndPunishmentInfo> RewardingAndPunishmentInfo { get; set; } = default!;
        //find personbasicinfo from coocike nameidentifier
        public async Task<IActionResult> OnGetAsync(/*int id*/)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value == null ) {
                ErrorMassage = "NameIdentifier is null Please Login in";
                return Page();
            }
            int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var personbasicinfo = await _context.PersonBasicInfo
                                                .FirstOrDefaultAsync(m => m.Id == id);

            var salaryinfo = await _context.SalaryInfo
                                                .FirstOrDefaultAsync(m => m.Id == id);

            var departmentinfo = await _context.DepartmentInfo.FirstOrDefaultAsync(m => m.Id == personbasicinfo.DepartmentId);

            /*
            */
            if (personbasicinfo == null || _context.PersonBasicInfo == null)
            {
                return NotFound();
            }

            PersonBasicInfo = personbasicinfo;
            SalaryInfo = salaryinfo;
            DepartmentInfo = departmentinfo;



            return Page();
        }
    }
}
