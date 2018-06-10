using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Data.SqlClient;

namespace 企业信息管理
{
    public partial class login : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Click += btnLoginClick;
            if (Request.QueryString["username"] != null)
                 tbUserName.Text = Request.QueryString["username"];
        }

        protected void btnLoginClick(object sender, EventArgs e)
        {
            if (verify())
            {
                string sqldb
                    = ConfigurationManager.ConnectionStrings["Sqlsever"].ConnectionString;
                SqlConnection MyCon = new SqlConnection(sqldb);
                MyCon.Open();
                SqlCommand cmd = new SqlCommand("select * from staff,department where staff.sta_id='" + tbUserName.Text + " ' and sta_password='" + tbPassword.Text + "' and staff.dep_id=department.dep_id", MyCon);
                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.Read())
                    {
                        Session["username"] = dr["sta_id"].ToString();
                        Session["nickname"] = dr["sta_name"].ToString();
                        Session["comment"] = dr["dep_name"].ToString();
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert(\"用户名或密码错误\");window.location.href=('../login.aspx?username=" + tbUserName.Text + "')</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(\"登录失败\");window.location.href=('../login.aspx?username=" + tbUserName.Text + "')</script>");

                }
                finally
                {
                    dr.Close();
                    MyCon.Close();
                }
            }
            else
            {
                // 谈对话框警告
                Response.Write("<script>alert(\"请输入用户名和密码\");</script>");
            }
        }
        private bool verify()
        {
            return tbUserName.Text.Length > 0 && tbPassword.Text.Length > 0;
        }
    }
}