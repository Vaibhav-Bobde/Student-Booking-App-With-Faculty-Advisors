using System;
using System.Linq;
using System.Security.Principal;
namespace WebApp.Common
{
    public interface ICustomPrincipal : IPrincipal
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
