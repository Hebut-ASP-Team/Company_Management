using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
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
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from supplier", conn)) {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        gvCompanyList.DataSource = ds;
                        gvCompanyList.DataBind();
                        standardTable();
                    }
                }
            }
        }

        protected void Delete(int supId) {
            using (OleDbConnection conn = new OleDbConnection(connectionStr)) {
                using (OleDbCommand cmd = new OleDbCommand("delete from supplier where sup_id=" + supId, conn)) {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            standardTable();
        }

        protected void gv_company_list_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            foreach (DictionaryEntry entry in e.Keys) {
                Delete((int)entry.Value);
                gvCompanyList.Rows[e.RowIndex].Visible = false;
            }
        }

        protected void gv_company_list_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName.Equals("XX")) {
                int index = Convert.ToInt32(e.CommandArgument);
                Session["selectedIndex"] = index;
                GridViewRow selectedRow = gvCompanyList.Rows[index];
                tbID.Text = selectedRow.Cells[0].Text;
                tbCompanyName.Text = selectedRow.Cells[2].Text;
                standardTable();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e) {
            if (Session["selectedIndex"] == null) return;
            using (OleDbConnection conn = new OleDbConnection(connectionStr)) {
                using (OleDbCommand cmd = new OleDbCommand("update supplier set sup_name='" + tbCompanyName.Text + "' where sup_id=" + tbID.Text, conn)) {
                    conn.Open();
                    int affectedRows = cmd.ExecuteNonQuery();
                    outputBasicJavascriptLib();
                    if (affectedRows > 0) {
                        try {
                            GridViewRow selectedRow = gvCompanyList.Rows[(int)Session["selectedIndex"]];
                            selectedRow.Cells[2].Text = tbCompanyName.Text;
                            Session.Remove("selectedIndex");
                            tbID.Text = "";
                            tbCompanyName.Text = "";
                        } catch (Exception) { }
                        // SweetAlert: http://lipis.github.io/bootstrap-sweetalert/
                        Response.Write("<script>$(document).ready(function(){swal(\"修改成功\", \"\", \"success\");})</script>");
                    } else
                        Response.Write("<script>$(document).ready(function(){swal(\"修改失败\", \"\", \"error\");})</script>");
                    standardTable();
                }
            }
        }

        // 修改属性, 生成带有thead和tfoot的标准table
        private void standardTable() {
            if (gvCompanyList.Rows.Count > 0) {
                // 使用<TH>替换<TD>
                gvCompanyList.UseAccessibleHeader = true;
                //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
                gvCompanyList.HeaderRow.TableSection = TableRowSection.TableHeader;
                // FooterRow将被<tfoot>包裹
                gvCompanyList.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void outputBasicJavascriptLib() {
            Response.Write("<script src=\"js/jquery-2.1.4.min.js\"></script>");
        }
    }
}