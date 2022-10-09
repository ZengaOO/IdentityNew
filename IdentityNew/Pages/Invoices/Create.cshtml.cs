using IdentityNew.Authorization;
using IdentityNew.Data;
using IdentityNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityNew.Pages.Invoices
{
   
    public class CreateModel : DI_BasePageModel
    {
        public CreateModel(
            ApplicationDbContext context, 
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {       
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Invoice Invoice { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            Invoice.CreatorId = UserManager.GetUserId(User);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Invoice, InvoiceOperations.Create);

            if (isAuthorized.Succeeded == false)
            {
                return Forbid();
            }

            Context.Invoice.Add(Invoice);
            await Context.SaveChangesAsync();
            {
                return RedirectToPage("./Index");
            }
        }
    }
}
