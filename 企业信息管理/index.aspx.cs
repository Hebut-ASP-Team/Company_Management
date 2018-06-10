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
    public partial class index : Page
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
            if (!IsPostBack)
            {
                DateTime time = DateTime.Now;
                using (OleDbConnection conn = new OleDbConnection(connectionStr))
                {
                    using (OleDbCommand adapter = new OleDbCommand("SELECT sum(sale_money) from sale where sale_creat_time = " + String.Format("'{0:yyyy-MM-dd}'", time), conn))
                    {
                        conn.Open();
                        decimal money = (decimal)adapter.ExecuteScalar();       // money
                        lbMoney.Text = money.ToString();
                    }
                    using (OleDbCommand adapter = new OleDbCommand("SELECT COUNT (sale_id) FROM sale_detail WHERE sale_id IN ( SELECT sale_id FROM sale WHERE sale_creat_time = " + String.Format("'{0:yyyy-MM-dd}'", time) + " ) GROUP BY sale_id", conn))
                    {
                        lbCount.Text = adapter.ExecuteScalar().ToString();
                    }
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select T2.sta_id, staff.sta_name, T2.money from staff right JOIN " +
                            "(select sta_id, sum(sale_money) money from sale where sale_creat_time like '" + String.Format("{0:yyyy-MM}", time) + "-__'" +
                            "group by sta_id) T2 on staff.sta_id = T2.sta_id + '@qq.com' order by money desc", conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        staff_rank_list.DataSource = ds;
                        staff_rank_list.DataBind();
                    }
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select T.goods_id, T.money, storage_goods.goods_name from " +
                   "(select goods_id, sum(saledet_money) money from sale_detail " +
                   " where sale_id in (select sale_id from sale WHERE sale_creat_time like '" + String.Format("{0:yyyy-MM}", time) + "-__') " +
                   " group by goods_id) T left JOIN storage_goods on T.goods_id = storage_goods.goods_id order by money desc", conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        goods_rank_list.DataSource = ds;
                        goods_rank_list.DataBind();
                    }
                }

            }
        }
    }
}