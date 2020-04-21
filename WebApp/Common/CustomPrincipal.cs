using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace WebApp.Common
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public CustomPrincipal(string email)
        {
            Identity = new GenericIdentity(email);
        }
        public bool IsInRole(string role)
        {
            return Identity != null && Identity.IsAuthenticated && string.IsNullOrEmpty(role) && Roles.IsUserInRole(role);
        }
    }
    public class CustomPrincipalSerializedModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}