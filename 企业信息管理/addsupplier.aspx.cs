using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 企业信息管理 {
    public partial class addsupplier : System.Web.UI.Page {
        string connectionStr = ConfigurationManager.ConnectionStrings["access2"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["username"] == null) {
                Response.Redirect("login.aspx");
                return;
            }
            username.Text = Session["nickname"] as string;
            comment.Text = Session["comment"] as string;
        }

        protected void btnCommit_Click(object sender, EventArgs e) {
            using (OleDbConnection conn = new OleDbConnection(connectionStr)) {
                using (OleDbCommand cmd = new OleDbCommand("insert into supplier(sup_name) values(\'" + tbSupplierName.Text + "\')", conn)) {
                    conn.Open();
                    int affectedRows = cmd.ExecuteNonQuery();
                    outputBasicJavascriptLib();
                    if (affectedRows > 0) {
                        Response.Write("<script>$(document).ready(function(){swal(\"修改成功\", \"\", \"success\");})</script>");
                    } else
                        Response.Write("<script>$(document).ready(function(){swal(\"修改失败\", \"\", \"error\");})</script>");

                }
            }
        }

        private void outputBasicJavascriptLib() {
            Response.Write("<script src=\"js/jquery-2.1.4.min.js\"></script>\n");
            Response.Write("<script type=\"text/javascript\" src=\"js/plugins/sweetalert.min.js\"></script>\n");
        }
    }
}