using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 企业信息管理 {
    public partial class suppliers : System.Web.UI.Page {
        string connectionStr = ConfigurationManager.ConnectionStrings["access"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["username"] == null) {
                Response.Redirect("login.aspx");
                return;
            }
            username.Text = Session["nickname"] as string;
            comment.Text = Session["comment"] as string;
            showCompanyList();
        }

        protected void gv_company_list_PageIndexChanging(object sender, GridViewPageEventArgs e) {

        }

        protected void showCompanyList() {
            if (!IsPostBack) {
                using (OleDbConnection conn = new OleDbConnection(connectionStr)) {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from dbo.supplier", conn)) {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        gv_company_list.DataSource = ds;
                        gv_company_list.DataBind();
                    }
                }
            }
        }
        
        protected void Delete(int supId) {
            using(OleDbConnection conn = new OleDbConnection(connectionStr)) {
                using(OleDbCommand cmd = new OleDbCommand("delete from supplier where sup_id=" + supId, conn)) {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void gv_company_list_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            foreach (DictionaryEntry entry in e.Keys) {
                Delete((int)entry.Value);
                gv_company_list.Rows[e.RowIndex].Visible = false;
            }
        }
    }
}