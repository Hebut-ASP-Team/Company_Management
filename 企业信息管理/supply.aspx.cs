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
/// <summary>
/// 企业信息管理 采购以及查询
/// </summary>
namespace 企业信息管理
{
    public partial class supply : System.Web.UI.Page
    {
        //连接字符串
        string connectionStr = ConfigurationManager.ConnectionStrings["access"].ConnectionString;
        /// <summary>
        /// 页面加载函数 
        /// 如果用户没有登录则返回登录 页面，已经登录显示采购单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            username.Text = Session["nickname"] as string;
            comment.Text = Session["comment"] as string;
            //显示采购单
            showPurchaseList();
            no_detail.Text = "请选择一条数据";
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
                using (OleDbCommand cmd = new OleDbCommand("delete from purchase where pur_id=" + purId, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    standardTable();
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
                    if (ds.Tables[0].Rows.Count <= 0)
                        no_detail.Text = "没有数据";
                    else
                        no_detail.Text = "";
                }
            }
        }

        /// <summary>
        /// GridView 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void purchase_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //“查看”按钮
            if (e.CommandName.Equals("detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = purchase_list.Rows[index];
                int pur_id = Convert.ToInt32(selectedRow.Cells[0].Text);
                showPurchaseDetailList(pur_id);
                standardTable();
            }
            //“修改”按钮
            else if (e.CommandName.Equals("change"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = purchase_list.Rows[index];
                using (OleDbConnection conn = new OleDbConnection(connectionStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand("update purchase set pur_status=3 where pur_id=" + selectedRow.Cells[0].Text, conn))
                    {
                        conn.Open();
                        int affectedRows = cmd.ExecuteNonQuery();
                        outputBasicJavascriptLib();
                        if (affectedRows > 0)
                        {
                            selectedRow.Cells[1].Text = "3";
                            Button btn = selectedRow.FindControl("btnIn") as Button;
                            btn.Enabled = false;
                            btn.Text = "已入库";
                            // SweetAlert: http://lipis.github.io/bootstrap-sweetalert/
                            Response.Write("<script>$(document).ready(function(){swal(\"修改成功\", \"\", \"success\");})</script>");
                        }
                        else
                            Response.Write("<script>$(document).ready(function(){swal(\"修改失败\", \"\", \"error\");})</script>");
                        standardTable();
                    }
                }
                standardTable();
            }
        }

        /// <summary>
        /// 修改属性, 生成带有thead和tfoot的标准table
        /// </summary> 
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

        private void outputBasicJavascriptLib()
        {
            Response.Write("<script src=\"js/jquery-2.1.4.min.js\"></script>");
        }

    }
}