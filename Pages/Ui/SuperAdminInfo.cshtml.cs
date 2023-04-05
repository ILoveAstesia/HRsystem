using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRsystem.Pages.Ui
{
    [Authorize(Policy = "SuperAdminOnly")]
    public class SuperAdminInfoModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
