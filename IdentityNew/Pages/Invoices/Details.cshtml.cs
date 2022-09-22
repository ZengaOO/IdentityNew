using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityNew.Data;
using IdentityNew.Models;

namespace IdentityNew.Pages.Invoices
{
    public class DetailsModel : PageModel
    {
        private readonly IdentityNew.Data.ApplicationDbContext _context;

        public DetailsModel(IdentityNew.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Invoice Invoice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }
            else 
            {
                Invoice = invoice;
            }
            return Page();
        }
    }
}
