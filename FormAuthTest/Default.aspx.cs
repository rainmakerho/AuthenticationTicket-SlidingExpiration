using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormAuthTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                FormsAuthenticationTicketInfo();
        }

        

        protected void btnAddIdentity_OnClick(object sender, EventArgs e)
        {
            FormsAuthenticationTicketInfo();
        }

        void FormsAuthenticationTicketInfo()
        {
            var identityInfos = new StringBuilder();
            FormsAuthenticationTicket ticket = ((FormsIdentity)Context.User.Identity).Ticket;
            var timeoutValue = (TimeSpan)(ticket.Expiration - ticket.IssueDate);
            identityInfos.AppendLine($"Timeout:{timeoutValue}");
            identityInfos.AppendLine($",IssueDate:{ticket.IssueDate.ToString("hh:mm:ss", null)}, Expiration:{ticket.Expiration.ToString("hh:mm:ss", null)}");
            var now = DateTime.Now;
            identityInfos.AppendLine($",Now:{now.ToString("hh:mm:ss", null)}");
            //var span = now - ticket.IssueDate;
            //var span2 = ticket.Expiration - now;
            //identityInfos.AppendLine($"now - ticket.IssueDate:{span}, Expiration - now:{span2}");

            lsIdentityInfos.Items.Add(identityInfos.ToString());

            //var newTicket = FormsAuthentication.RenewTicketIfOld(ticket);
            //Response.Write($"{newTicket.Expiration.ToString("hh:mm:ss", null)}");
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
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
                    //orgTicket = newTicket;
                }
            }
        }
    }
}