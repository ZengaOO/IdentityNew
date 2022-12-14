using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityNew;
using IdentityNew.Data;

namespace IdentityNew.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly IdentityNew.Data.ApplicationDbContext _context;

        public IndexModel(IdentityNew.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Invoice != null)
            {
                Invoice = await _context.Invoice.ToListAsync();
            }
        }
    }
}
