using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 企业信息管理 {
    public partial class sell : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(Session.Count == 0) {
                Response.Redirect("login.aspx");
                return;
            }
            username.Text = Session["nickname"] as string;
            comment.Text = Session["comment"] as string;
        }
    }
}