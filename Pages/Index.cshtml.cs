using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;

[Authorize]
public class IndexModel : PageModel
{

    private readonly SupermarketContext _context;

    public IndexModel(SupermarketContext context)
    {
        _context = context;
    }

    public IList<Category> Categories { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Categories != null)
        {
            Categories = await _context.Categories.ToListAsync();
        }
    }
}
