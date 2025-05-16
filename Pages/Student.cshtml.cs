using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SupermarketWEB.Pages
{
    [Authorize]
    public class StudentModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
