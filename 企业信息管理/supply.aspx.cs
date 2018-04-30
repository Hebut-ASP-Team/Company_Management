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
    public partial class supply : System.Web.UI.Page
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
            showPurchaseList();
        }

        /// <summary>
        /// 显示采购订单表
        /// </summary>
        protected void showPurchaseList()
        {
            if (!IsPostBack)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionStr))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from purchase ", conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "purchase");
                        purchase_list.DataSource = ds;
                        purchase_list.DataBind();
                        if (purchase_list.Rows.Count > 0)
                        {
                            // 使用<TH>替换<TD>
                            purchase_list.UseAccessibleHeader = true;
                            //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
                            purchase_list.HeaderRow.TableSection = TableRowSection.TableHeader;
                            // FooterRow将被<tfoot>包裹
                            purchase_list.FooterRow.TableSection = TableRowSection.TableFooter;
                        }
                    }
                }
            }

        }


        /// <summary>
        /// 根据pur_id删除一行采购数据
        /// </summary>
        /// <param name="supId"></param>
        protected void Delete(int purId)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmd = new OleDbCommand("delete from purchase_detail where pur_id=" + purId, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                using (OleDbCommand cmd = new OleDbCommand("delete from purchase where pur_id=" + purId, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// “删除”按钮事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void purchase_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            foreach (DictionaryEntry entry in e.Keys)
            {
                Delete((int)entry.Value);
                purchase_list.Rows[e.RowIndex].Visible = false;
            }
        }
        /// <summary>
        /// 显示采购明细表
        /// </summary>
        protected void showPurchaseDetailList(int pur_id)
        {
            
                using (OleDbConnection conn = new OleDbConnection(connectionStr))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM purchase_detail WHERE pur_id=" + pur_id, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "purchase_detail");
                        purchase_detail_list.DataSource = ds;
                        purchase_detail_list.DataBind();                   
                    }             
            }
        }
        protected void purchase_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow =purchase_list.Rows[index];
                int pur_id = Convert.ToInt32(selectedRow.Cells[0].Text);
                showPurchaseDetailList(pur_id);
                standardTable();
            }
            else if(e.CommandName.Equals("change"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = purchase_list.Rows[index];
               
                tbPurID.Text = selectedRow.Cells[0].Text; 
                tbPurStatus.Text = selectedRow.Cells[1].Text;
                standardTable();
            }
        }

        // 修改属性, 生成带有thead和tfoot的标准table
        private void standardTable()
        {
            if (purchase_list.Rows.Count > 0)
            {
                // 使用<TH>替换<TD>
                purchase_list.UseAccessibleHeader = true;
                //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
                purchase_list.HeaderRow.TableSection = TableRowSection.TableHeader;
                // FooterRow将被<tfoot>包裹
                purchase_list.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["selectedIndex"] == null) return;
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmd = new OleDbCommand("update purchase set pur_status ="+tbPurStatus.Text + "where pur_id=" + tbPurID.Text, conn))
                {
                    conn.Open();
                    int affectedRows = cmd.ExecuteNonQuery();
                    outputBasicJavascriptLib();
                    if (affectedRows > 0)
                    {
                        try
                        {
                            GridViewRow selectedRow = purchase_list.Rows[(int)Session["selectedIndex"]];
                            selectedRow.Cells[1].Text = tbPurStatus.Text;
                            Session.Remove("selectedIndex");
                            tbPurID.Text = "";
                            tbPurStatus.Text = "";
                        }
                        catch (Exception) { }
                        // SweetAlert: http://lipis.github.io/bootstrap-sweetalert/
                        Response.Write("<script>$(document).ready(function(){swal(\"修改成功\", \"\", \"success\");})</script>");
                    }
                    else
                        Response.Write("<script>$(document).ready(function(){swal(\"修改失败\", \"\", \"error\");})</script>");
                    standardTable();
                }
            }
        }

        private void outputBasicJavascriptLib()
        {
            Response.Write("<script src=\"js/jquery-2.1.4.min.js\"></script>");
        }

    }
}