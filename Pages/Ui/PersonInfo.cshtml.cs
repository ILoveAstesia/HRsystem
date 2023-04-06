using HRsystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
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
            DepartmentInfo = default!;
        }
        public string? AuthorityMassage { get; set; } = default!;
        public string? ErrorMassage { get; set; } = default!;
        public PersonBasicInfo PersonBasicInfo { get; set; } = default!;
        public SalaryInfo SalaryInfo { get; set; } = default!;
        public AccountInfo AccountInfo { get; set; } = default!;
        public DepartmentInfo DepartmentInfo { get; set; } = default!;
        public IList<RewardingAndPunishmentInfo> RewardingAndPunishmentInfo { get; set; } = default!;
        public IList<TrainingInfo> TrainingInfo { get; set; } = default!;
        
        //find personbasicinfo from coocike nameidentifier
        public async Task<IActionResult> OnGetAsync(/*int id*/)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value == null)
            {
                ErrorMassage = "NameIdentifier is null Please Login in";
                return Page();
            }

            AuthorityMassage= "ID: "+User.FindFirst(ClaimTypes.NameIdentifier)?.Value+" Authority: "+User.FindFirst("Authority")?.Value;

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
            SalaryInfo      = salaryinfo;
            DepartmentInfo  = departmentinfo;

            if (_context.RewardingAndPunishmentInfo != null)
            {
                RewardingAndPunishmentInfo = await _context.RewardingAndPunishmentInfo
                    .Where(r => r.PersonId == id)
                    .ToListAsync();
            }

            if (_context.TrainingInfo != null)
            {
                TrainingInfo = await _context.TrainingInfo
                    .Where(r => r.PersonId == id)
                    .ToListAsync();
            }

            return Page();
        }
    }
}
