using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;

        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Provider Provider { get; set; } = default;

        public async Task<ActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);

            if (provider == null)
            {
                return NotFound();
            }
            else
            {
                Provider = provider;
            }
            return Page();
        }
       

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }
            var provider = await _context.Providers.FindAsync(id);

            if (provider != null)
            {
                Provider = provider;
                _context.Providers.Remove(Provider);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}

