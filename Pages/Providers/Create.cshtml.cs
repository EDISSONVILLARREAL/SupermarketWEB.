using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Xml.Linq;

namespace SupermarketWEB.Pages.Providers
{
    [Authorize]
    public class CreateModel : PageModel
{
    private readonly SupermarketContext _context;

    public CreateModel(SupermarketContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
        public Provider Provider { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || _context.Providers == null || Provider == null)
        {
            return Page();
        }

        _context.Providers.Add(Provider);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
}
