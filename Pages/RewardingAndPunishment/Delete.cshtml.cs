using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.RewardingAndPunishment
{
    public class DeleteModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public DeleteModel(HRsystem.Data.HRsystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RewardingAndPunishmentInfo RewardingAndPunishmentInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RewardingAndPunishmentInfo == null)
            {
                return NotFound();
            }

            var rewardingandpunishmentinfo = await _context.RewardingAndPunishmentInfo.FirstOrDefaultAsync(m => m.Id == id);

            if (rewardingandpunishmentinfo == null)
            {
                return NotFound();
            }
            else 
            {
                RewardingAndPunishmentInfo = rewardingandpunishmentinfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RewardingAndPunishmentInfo == null)
            {
                return NotFound();
            }
            var rewardingandpunishmentinfo = await _context.RewardingAndPunishmentInfo.FindAsync(id);

            if (rewardingandpunishmentinfo != null)
            {
                RewardingAndPunishmentInfo = rewardingandpunishmentinfo;
                _context.RewardingAndPunishmentInfo.Remove(RewardingAndPunishmentInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
