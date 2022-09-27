using Microsoft.AspNetCore.Identity;
using IdentityNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace IdentityNew.Authorization
{
    public class InvoiceCreatorAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Invoice>
    {
        UserManager<IdentityUser> _userManager;

        public InvoiceCreatorAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            OperationAuthorizationRequirement requirement,
            Invoice invoice)
        {
          if (context.User == null || invoice == null)
                return Task.CompletedTask; 
          
          if (requirement.Name != Constans.CreateOperationName &&
                requirement.Name != Constans.ReadOperationName && 
                requirement.Name != Constans.UpdateOperationName &&
                requirement.Name != Constans.DeleteOperationName)
          {
                return Task.CompletedTask;
          }

            if (invoice.CreatorId == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
