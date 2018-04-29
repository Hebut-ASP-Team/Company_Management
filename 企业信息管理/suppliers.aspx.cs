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

        protected void showCompanyList() {
            if (!IsPostBack) {
                using (OleDbConnection conn = new OleDbConnection(connectionStr)) {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from dbo.supplier", conn)) {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        gvCompanyList.DataSource = ds;
                        gvCompanyList.DataBind();
                        if (gvCompanyList.Rows.Count > 0) {
                            // 使用<TH>替换<TD>
                            gvCompanyList.UseAccessibleHeader = true;
                            //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
                            gvCompanyList.HeaderRow.TableSection = TableRowSection.TableHeader;
                            // FooterRow将被<tfoot>包裹
                            gvCompanyList.FooterRow.TableSection = TableRowSection.TableFooter;
                        }
                    }
                }
            }
        }
        
        protected void Delete(int supId) {
            using(OleDbConnection conn = new OleDbConnection(connectionStr)) {
                using(OleDbCommand cmd = new OleDbCommand("delete from dbo.supplier where sup_id=" + supId, conn)) {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void gv_company_list_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            foreach (DictionaryEntry entry in e.Keys) {
                Delete((int)entry.Value);
                gvCompanyList.Rows[e.RowIndex].Visible = false;
            }
        }

        protected void gv_company_list_RowCommand(object sender, GridViewCommandEventArgs e) {
            if(e.CommandName.Equals("Update")) {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvCompanyList.Rows[index];
                // Display the selected author.
            }
        }
    }
}