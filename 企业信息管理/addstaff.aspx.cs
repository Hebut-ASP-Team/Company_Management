using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 企业信息管理
{
    public partial class addstaff : System.Web.UI.Page 
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["access"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            username.Text = Session["nickname"] as string;
            comment.Text = Session["comment"] as string;
            showDepartment();
        }
        private void showDepartment()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter("select dep_id id, dep_name name from dbo.department", conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    ddlDepartment.DataSource = ds;
                    ddlDepartment.DataTextField = "name";
                    ddlDepartment.DataValueField = "id";
                    ddlDepartment.DataBind();
                }
            }
        }
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmd = new OleDbCommand("insert into staff(sta_id,sta_name,sta_sex,sta_age,sta_phone,dep_id,sta_password) values('"+addstaMAIL.Text+"','" + addstaNAME.Text + "','" + rblMale.SelectedValue +"'," + addstaAGE.Text + ",'" + addstaPHONE.Text + "'," + ddlDepartment.SelectedValue+ ",'"+addstaPWD.Text+"')", conn))
                {
                    conn.Open();
                    int affectedRows = 0;
                    try
                    {
                        affectedRows = cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException)
                    {
                        affectedRows = -1;
                    }
                    finally
                    {
                        outputBasicJavascriptLib();
                        if (affectedRows > 0)
                        {
                            // SweetAlert: http://lipis.github.io/bootstrap-sweetalert/
                            Response.Write("<script>$(document).ready(function(){swal({title:\"添加成功\", type:\"success\"}, function(){window.location.href=\"staffmanage.aspx\";})})</script>");
                        }
                        else
                            Response.Write("<script>$(document).ready(function(){swal(\"邮箱已存在\", \"\", \"error\");})</script>");
                    }
                }
            }
        }
        private void outputBasicJavascriptLib()
        {
            Response.Write("<script src=\"js/jquery-2.1.4.min.js\"></script>\n");
            Response.Write("<script type=\"text/javascript\" src=\"js/plugins/sweetalert.min.js\"></script>\n");
        }
    }
}