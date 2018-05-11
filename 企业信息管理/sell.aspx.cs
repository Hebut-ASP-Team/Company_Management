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
using System.Data.SqlClient;

namespace 企业信息管理 {
    public partial class sell : System.Web.UI.Page {
        string connectionStr = ConfigurationManager.ConnectionStrings["access"].ConnectionString;
        private LinkedList<Goods> goodsList;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["username"] == null) {
                Response.Redirect("login.aspx");
                return;
            }
            username.Text = Session["nickname"] as string;
            comment.Text = Session["comment"] as string;
            if(!IsPostBack) {
                Session.Remove("list");
            }
            if (Session["list"] == null) {
                goodsList = new LinkedList<Goods>();
                Session["list"] = goodsList;
            } else {
                goodsList = Session["List"] as LinkedList<Goods>;
            }
            showGoodsList();
        }
        protected void showGoodsList() {
            if (!IsPostBack) {
                using (OleDbConnection conn = new OleDbConnection(connectionStr)) {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select goods_id,goods_name,goods_amount from storage_goods", conn)) {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        gv_sell_list.DataSource = ds;
                        gv_sell_list.DataBind();
                        standardTable();
                    }
                    good_temporary.DataSource = goodsList;
                    good_temporary.DataBind();
                }
            }
        }

        private void standardTable() {
            if (gv_sell_list.Rows.Count > 0) {
                // 使用<TH>替换<TD>
                gv_sell_list.UseAccessibleHeader = true;
                //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
                gv_sell_list.HeaderRow.TableSection = TableRowSection.TableHeader;
                // FooterRow将被<tfoot>包裹
                gv_sell_list.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void gv_sell_list_RowSelect(object sender, GridViewDeleteEventArgs e) {
            /*foreach (DictionaryEntry entry in e.Keys)
            {
                Delete((int)entry.Value);
                gvCompanyList.Rows[e.RowIndex].Visible = false;
            }*/
        }

        protected void gv_sell_list_RowCommand(object sender, GridViewCommandEventArgs e) {
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
        protected void btnSell_Click(object sender, EventArgs e) {

        }
        // 在"购买数量"对话框中点击确认按钮
        protected void btnOK_Click(object sender, EventArgs e) {
            goodsList.AddLast(new Goods(Int32.Parse(goodsid.Text), goodsname.Text, Int32.Parse(buyAmount.Text)));
            good_temporary.DataSource = goodsList;
            good_temporary.DataBind();
            standardTable();
        }

        protected void btnSellCommit_Click(object sender, EventArgs e) {
            // 所有数据都存储在List中了
            string sqldb
                    = ConfigurationManager.ConnectionStrings["Sqlsever"].ConnectionString;
            SqlConnection MyCon = new SqlConnection(sqldb);
            MyCon.Open();
            int i = 0;
            while(i < goodsList.Count)
            {
                SqlCommand comm = new SqlCommand("update storage_goods SET goods_amount = goods_amount - " + goodsList.ElementAt(i).num + "WHERE goods_id = "+ goodsList.ElementAt(i).id,MyCon);
                comm.ExecuteNonQuery();
                i++;
            }
            Session["list"] = null;  
            Response.Redirect("sell.aspx");
        }
    }
    public class Goods {
        static int count = 0;
        public int seq;        // 序号
        public int id;         // 商品ID
        public string name;    // 商品名称
        public int num;      // 购买数量

        public Goods(int id, string name, int num) {
            this.seq = ++count;
            this.id = id;
            this.name = name;
            this.num = num;
        }

        public Goods() { }
    }
}