using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRsystem.Pages.Ui
{
    [Authorize(Policy = "AdminLest")]
    public class AdminInfoModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
