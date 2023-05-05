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

                return Redirect("/Account/Login");
            }

            string? sId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            AuthorityMassage = "ID: " + sId + " Authority: " + User.FindFirst("Authority")?.Value;

            // if(User.FindFirst(ClaimTypes.NameIdentifier)!=null){
            //     RedirectToPage("~/Account/Login.cshtml");
            // }


            bool _try = int.TryParse(sId, out int id);
            if (!_try)
            {
                TempData["Error"] = "TryParse(sId,out int id) faild";
                return Redirect("/Index");
            }
            var personbasicinfo = await _context.PersonBasicInfo
                                                .FirstOrDefaultAsync(m => m.Id == id);

            if (personbasicinfo == null)
            {
                TempData["Error"] = "PersonBasicInfo Is Null Please Update!";
                return Redirect("/Index");
            }

            var salaryinfo = await _context.SalaryInfo
                                                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaryinfo == null)
            {
                TempData["Error"] = "salaryinfo Is Null Please Update!";
                return Redirect("/Index");
            }
            var departmentinfo = await _context.DepartmentInfo.FirstOrDefaultAsync(m => m.Id == personbasicinfo.DepartmentId);
            if (departmentinfo == null)
            {
                TempData["Error"] = "departmentinfo Is Null Please Update!";
                return Redirect("/Index");
            }
            /*
            */

            PersonBasicInfo = personbasicinfo;
            SalaryInfo = salaryinfo;
            DepartmentInfo = departmentinfo;

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
