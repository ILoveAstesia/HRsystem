using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRsystem.Data;
using HRsystem.Models;

namespace HRsystem.Pages.RewardingAndPunishment
{
    public class EditModel : PageModel
    {
        private readonly HRsystem.Data.HRsystemContext _context;

        public EditModel(HRsystem.Data.HRsystemContext context)
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

            var rewardingandpunishmentinfo =  await _context.RewardingAndPunishmentInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (rewardingandpunishmentinfo == null)
            {
                return NotFound();
            }
            RewardingAndPunishmentInfo = rewardingandpunishmentinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RewardingAndPunishmentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RewardingAndPunishmentInfoExists(RewardingAndPunishmentInfo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RewardingAndPunishmentInfoExists(int id)
        {
          return (_context.RewardingAndPunishmentInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
