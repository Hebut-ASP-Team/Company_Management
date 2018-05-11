using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 企业信息管理 {

    public partial class staffmanage : System.Web.UI.Page {
        string connectionStr = ConfigurationManager.ConnectionStrings["access"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["username"] == null) {
                Response.Redirect("login.aspx");
                return;
            }
            username.Text = Session["nickname"] as string;
            comment.Text = Session["comment"] as string;
            showStaffList();
            showDepartment();
        }

        private void showDepartment()
        {
            using(OleDbConnection conn =new OleDbConnection(connectionStr)) {
                using(OleDbDataAdapter adapter = new OleDbDataAdapter("select dep_id id, dep_name name from dbo.department",conn)) {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    ddlDepartment.DataSource = ds;
                    ddlDepartment.DataTextField = "name";
                    ddlDepartment.DataValueField = "id";
                    ddlDepartment.DataBind();
                }
            }
        }

        protected void showStaffList() {
            if (!IsPostBack) {
                using (OleDbConnection conn = new OleDbConnection(connectionStr)) {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from staff,department where staff.dep_id=department.dep_id", conn)) {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        gvCompanyList.DataSource = ds;
                        gvCompanyList.DataBind();
                        standardTable();
                    }
                }
            }
        }
        protected void Delete(string staId) {
            using (OleDbConnection conn = new OleDbConnection(connectionStr)) {
                using (OleDbCommand cmd = new OleDbCommand("delete from staff where sta_id='" + staId + "'", conn)) {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            standardTable();
        }
        protected void gv_company_list_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            foreach (DictionaryEntry entry in e.Keys) {
                Delete((string)entry.Value);
                gvCompanyList.Rows[e.RowIndex].Visible = false;
            }
        }
        protected void gv_company_list_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName.Equals("XX")) {
                int index = Convert.ToInt32(e.CommandArgument);
                Session["selectedIndex"] = index;
                GridViewRow selectedRow = gvCompanyList.Rows[index];
                staID.Text = selectedRow.Cells[0].Text;
                staNAME.Text = selectedRow.Cells[1].Text;
                staSEX.SelectedValue = selectedRow.Cells[2].Text;
                staSEX.SelectedIndex = (selectedRow.Cells[2].Text.Equals("男")) ? 0 : 1;
                staAGE.Text = selectedRow.Cells[3].Text;
                staPHONE.Text = selectedRow.Cells[4].Text;
                // ddlDepartment.Text = selectedRow.Cells[5].Text;
                foreach (ListItem item in ddlDepartment.Items)
                {
                    if(item.Text.Equals(selectedRow.Cells[5].Text))
                    {
                        ddlDepartment.SelectedValue = item.Value;
                        break;
                    }
                }
                standardTable();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e) {
            if (Session["selectedIndex"] == null) return;
            string sqldb
                    = ConfigurationManager.ConnectionStrings["Sqlsever"].ConnectionString;
            SqlConnection MyCon_hyh = new SqlConnection(sqldb);
            MyCon_hyh.Open();
            SqlCommand cmd_hyh = new SqlCommand("select * from department where dep_name='" + ddlDepartment.SelectedValue + "'", MyCon_hyh);
            SqlDataReader dr_hyh = cmd_hyh.ExecuteReader();
            int dep_id = 0;
            if (dr_hyh.Read())
                dep_id = Convert.ToInt32(dr_hyh["dep_id"].ToString());
            using (OleDbConnection conn = new OleDbConnection(connectionStr)) {
                using (OleDbCommand cmd = new OleDbCommand("update staff set sta_name='" + staNAME.Text + "',sta_sex='" + (staSEX.SelectedIndex == 0 ? "男" : "女") + "',sta_age=" + staAGE.Text + ",sta_phone='" + staPHONE.Text + "',dep_id=" + dep_id + "  where sta_id='" + staID.Text + "'", conn)) {
                    conn.Open();
                    int affectedRows = cmd.ExecuteNonQuery();
                    outputBasicJavascriptLib();
                    if (affectedRows > 0) {
                        try {
                            GridViewRow selectedRow = gvCompanyList.Rows[(int)Session["selectedIndex"]];
                            selectedRow.Cells[1].Text = staNAME.Text;
                            selectedRow.Cells[2].Text = staSEX.SelectedValue;
                            selectedRow.Cells[3].Text = staAGE.Text;
                            selectedRow.Cells[4].Text = staPHONE.Text;
                            selectedRow.Cells[5].Text = ddlDepartment.SelectedItem.Text;
                            Session.Remove("selectedIndex");
                            staID.Text = "";
                            staNAME.Text = "";
                            staSEX.SelectedIndex = 0;
                            staAGE.Text = "";
                            ddlDepartment.SelectedValue = "0";
                            staPHONE.Text = "";
                            standardTable();
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