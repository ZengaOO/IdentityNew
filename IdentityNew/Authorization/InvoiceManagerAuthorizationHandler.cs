using IdentityNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace IdentityNew.Authorization
{
    public class InvoiceManagerAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Invoice>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            Invoice invoice)
        {
            
            if(context.User == null || invoice == null)
                return Task.CompletedTask;

            if (requirement.Name != Constans.ApprovedOperationName &&
                requirement.Name != Constans.RejectedOperationName)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(Constans.InvoiceManagersRole))
                context.Succeed(requirement);
            {
                return Task.CompletedTask;
            }

        }
    }
}
