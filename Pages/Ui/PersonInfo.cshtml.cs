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
            DepartmentInfo = default!;
        }

        public string? ErrorMassage { get; set; }
        public PersonBasicInfo PersonBasicInfo { get; set; } = default!;
        public SalaryInfo SalaryInfo { get; set; } = default!;
        public AccountInfo AccountInfo { get; set; } = default!;
        public DepartmentInfo DepartmentInfo { get; set; }
        public IList<RewardingAndPunishmentInfo> RewardingAndPunishmentInfo { get; set; } = default!;
        //find personbasicinfo from coocike nameidentifier
        public async Task<IActionResult> OnGetAsync(/*int id*/)
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value,out int id))
            {
                ErrorMassage = " ID:" + User.FindFirst(ClaimTypes.NameIdentifier)?.Value + " Authority:" + User.FindFirst("Authority")?.Value;
            }
            else
            {
                ErrorMassage = "NameIdentifier is null or invalid Please Login in";
                return Page();

            }

            //int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            /*
            AccountInfo.Id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            AccountInfo.Authority = int.Parse(User.FindFirst("Authority")?.Value);
            */

            //if (_context.PersonBasicInfo == null)
            //{
            //    return NotFound();
            //}

            var pi = await _context.PersonBasicInfo
                                    .FirstOrDefaultAsync(m => m.Id == id);

            var si = await _context.SalaryInfo
                                    .FirstOrDefaultAsync(m => m.Id == id);

            if (pi == null)
            {
                //return NotFound();
                PersonBasicInfo = default!;
                ErrorMassage += "pi == null , ";
                return Page();
            }

            if (PersonBasicInfo == null || PersonBasicInfo.DepartmentId == null)
            {
                // Handle the situation here
                return NotFound();
            }

            var di  = await _context.DepartmentInfo
                                    .FirstOrDefaultAsync(m => m.Id == PersonBasicInfo.DepartmentId);

            if (di == null || si == null) {
                ErrorMassage += "di == null || si == null , ";
                //return NotFound();
                SalaryInfo = default!;
                DepartmentInfo = default!;
                return Page();
            }

            PersonBasicInfo = pi;
            SalaryInfo = si;
            DepartmentInfo = di;

            if (_context.RewardingAndPunishmentInfo != null)
            {
                RewardingAndPunishmentInfo = await _context.RewardingAndPunishmentInfo
                    .Where(r => r.PersonId == id)
                    .ToListAsync();
            }

            return Page();
        }
    }
}
