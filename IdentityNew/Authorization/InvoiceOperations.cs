using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace IdentityNew.Authorization
{
    public class InvoiceOperations
    {
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement { Name = Constans.CreateOperationName };
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement { Name = Constans.ReadOperationName };
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement { Name = Constans.UpdateOperationName };
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement { Name = Constans.DeleteOperationName };
        public static OperationAuthorizationRequirement Approved =
            new OperationAuthorizationRequirement { Name = Constans.ApprovedOperationName };
        public static OperationAuthorizationRequirement Reject =
            new OperationAuthorizationRequirement { Name = Constans.RejectedOperationName };
    }

    public class Constans
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read"; 
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";
        
        
        public static readonly string ApprovedOperationName = "Approved";
        public static readonly string RejectedOperationName = "Rejected";

        public static readonly string InvoiceManagersRole = "InvoiceManager";

    }
}
