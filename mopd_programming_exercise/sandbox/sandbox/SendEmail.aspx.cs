using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sandbox.Logic;

namespace sandbox
{
    public partial class SendEmail : System.Web.UI.Page
    {
        string from = "test.user.for.apps.0@gmail.com";
        string password = "ka(*&dBU86*^%4vgiu_0";
        string to = "christophersahadeo@gmail.com";
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            EmailActions emailActions = new EmailActions();
            string subject = "Request Approved";
            string body = "Your request has been approved!\n";
            emailActions.SendEmail(from, password, to, subject, body);
        }

        protected void RejectButton_Click(object sender, EventArgs e)
        {
            EmailActions emailActions = new EmailActions();
            string subject = "Request Denied";
            string body = "Your request has been denied!\n";
            emailActions.SendEmail(from, password, to, subject, body);
        }
    }
}