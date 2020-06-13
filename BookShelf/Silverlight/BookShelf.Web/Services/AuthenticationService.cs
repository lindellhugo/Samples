namespace BookShelf.Web
{
    using System.Security.Authentication;
    using OpenRiaServices.DomainServices.Hosting;
    using OpenRiaServices.DomainServices.Server;
    using System.Threading;
    using OpenRiaServices.DomainServices.Server.ApplicationServices;

    /// <summary>
    /// RIA Services DomainService responsible for authenticating users when
    /// they try to log on to the application.
    ///
    /// Most of the functionality is already provided by the base class
    /// AuthenticationBase
    /// </summary>
    [EnableClientAccess]
    public class AuthenticationService : AuthenticationBase<User> { }
}
