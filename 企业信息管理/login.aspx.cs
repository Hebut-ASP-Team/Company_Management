using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 企业信息管理 {
    public partial class login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            btnLogin.Click += btnLoginClick;
        }

        protected void btnLoginClick(object sender, EventArgs e) {
            if(verify()) {
                Session["username"] = tbUserName.Text;
                Session["nickname"] = "ID为" + tbUserName.Text + "的小可爱";
                Session["comment"] = "ID为" + tbUserName.Text + "写的备注!";
                Response.Redirect("sell.aspx");
            } else {
                // 谈对话框警告
                Response.Write("<script>alert(\"密码错误\");</script>");
            }
        }
        private bool verify() {
            return tbUserName.Text.Length > 0 && tbPassword.Text.Length > 0;
        }
    }
}