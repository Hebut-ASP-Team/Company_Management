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

namespace 企业信息管理
{
    public partial class sell : System.Web.UI.Page
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
            showGoodsList();
        }
        protected void showGoodsList()
        {
            if (!IsPostBack)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionStr))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select goods_id,goods_name,goods_amount from storage_goods", conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        gv_sell_list.DataSource = ds;
                        gv_sell_list.DataBind();
                        if (gv_sell_list.Rows.Count > 0)
                        {
                            // 使用<TH>替换<TD>
                            gv_sell_list.UseAccessibleHeader = true;
                            //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
                            gv_sell_list.HeaderRow.TableSection = TableRowSection.TableHeader;
                            // FooterRow将被<tfoot>包裹
                            gv_sell_list.FooterRow.TableSection = TableRowSection.TableFooter;
                        }
                    }
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from goods_temporary", conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        good_temporary.DataSource = ds;
                        good_temporary.DataBind();
                        if (good_temporary.Rows.Count > 0)
                        {
                            // 使用<TH>替换<TD>
                            good_temporary.UseAccessibleHeader = true;
                            //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
                            good_temporary.HeaderRow.TableSection = TableRowSection.TableHeader;
                            // FooterRow将被<tfoot>包裹
                            good_temporary.FooterRow.TableSection = TableRowSection.TableFooter;
                        }
                    }
                }
            }
        }
        protected void gv_sell_list_RowSelect(object sender, GridViewDeleteEventArgs e)
        {
            /*foreach (DictionaryEntry entry in e.Keys)
            {
                Delete((int)entry.Value);
                gvCompanyList.Rows[e.RowIndex].Visible = false;
            }*/
        }

        protected void gv_sell_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            /*if (e.CommandName.Equals("XX"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Session["selectedIndex"] = index;
                GridViewRow selectedRow = gvCompanyList.Rows[index];
                tbID.Text = selectedRow.Cells[0].Text;
                tbCompanyName.Text = selectedRow.Cells[2].Text;
                standardTable();
            }*/
        }
        protected void btnSell_Click(object sender, EventArgs e)
        {

        }
        protected void save(object sender, EventArgs e)
        {
            Response.Write("123");
        }
    }
}