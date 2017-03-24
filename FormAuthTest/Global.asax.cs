using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace FormAuthTest
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (Request.IsAuthenticated && Context.User.Identity is FormsIdentity)
            {
                var orgTicket = ((FormsIdentity)Context.User.Identity).Ticket;
                // Manually slide the expiration
             
                var timeoutValue = (TimeSpan)(orgTicket.Expiration - orgTicket.IssueDate);
                var now = DateTime.Now;
                //重新再計算新的過期時間
                var newExpiration = now + timeoutValue;
                //建立一個新的 Ticket 
                var newTicket = new FormsAuthenticationTicket(orgTicket.Version, orgTicket.Name, now, newExpiration, orgTicket.IsPersistent, orgTicket.UserData);

                if (newTicket.Expiration > orgTicket.Expiration)
                {
                    // Create the (encrypted) cookie.
                    HttpCookie objCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(newTicket));
                    // Add the cookie to the list for outbound response. 
                    Response.Cookies.Add(objCookie);
                    // Update original
                    orgTicket = newTicket;
                }
            }
        }
    }
}