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

namespace HRsystem.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly HRsystemContext _context;

        public EditModel(HRsystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountInfo AccountInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AccountInfo == null)
            {
                return NotFound();
            }

            var accountinfo = await _context.AccountInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (accountinfo == null)
            {
                return NotFound();
            }
            AccountInfo = accountinfo;
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

            _context.Attach(AccountInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountInfoExists(AccountInfo.Id))
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

        private bool AccountInfoExists(int id)
        {
            return (_context.AccountInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
