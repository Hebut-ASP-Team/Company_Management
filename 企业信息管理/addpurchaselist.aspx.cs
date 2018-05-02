using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 企业信息管理
{
    public partial class addpurchaselist : System.Web.UI.Page
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["access"].ConnectionString;
        int purchase_detail_id = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            username.Text = Session["nickname"] as string;
            comment.Text = Session["comment"] as string;
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT MAX(pur_id) FROM purchase", conn))
                {
                    conn.Open();
                    int pur_id = (int)cmd.ExecuteScalar()+1;
                    tbPurchaseID.Text = pur_id.ToString();
                    tbPurchaseDetID.Text = purchase_detail_id.ToString();
                }
            }

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            
            int goods_id = getGoodsID(good_Name.SelectedItem.Text);
            //int supplier_id=getSupplierID(dropSupplier.SelectedItem.Text);
            insertPurchaseDetail(Convert.ToInt32(tbPurchaseID.Text), Convert.ToInt32(tbPurchaseDetID.Text),goods_id, Convert.ToInt32(tbAmount.Text),tbMoney.Text,dropSupplier.SelectedValue.ToString());


        }
        public int getGoodsID(string goods_name)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT goods_id FROM storage_goods WHERE goods_name= '" + goods_name + "'", conn))
                {
                    conn.Open();
                    int goods_id = (int)cmd.ExecuteScalar();
                    return goods_id;
                }
            }
        }
        public int getSupplierID(string supplier_name)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT sup_id FROM supplier WHERE sup_name= '" + supplier_name + "'", conn))
                {
                    conn.Open();
                    int sup_id = (int)cmd.ExecuteScalar();
                    return sup_id;
                }
            }

        }
        public void insertPurchaseDetail(int pur_id, int purdet_id, int goods_id, int amount, string money, string supplier)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmmd = new OleDbCommand("INSERT INTO purchase_detail(pur_id, purdet_id, goods_id, purdet_amount, purdet_money, purdet_supplier)VALUES(" + purdet_id + "," + pur_id + "," + goods_id + "," + amount + ",'" + money + "','" + supplier + "'" + ")", conn))
                {
                    int totalmoney = amount * Convert.ToInt32(money);
                    string sta_id = getStaID(username.Text);
                    conn.Open();
                    int affectedRows = cmmd.ExecuteNonQuery();
                    outputBasicJavascriptLib();
                    if (affectedRows > 0)
                    {

                        // SweetAlert: http://lipis.github.io/bootstrap-sweetalert/

                         Response.Write("<script>$(document).ready(function(){swal({title:\"添加成功\", type:\"success\"}, function(){window.location.href=\"supply.aspx\";})})</script>");
                         if(purchase_detail_id==1)
                        {
                            
                            insertPurchase(pur_id,totalmoney.ToString(),sta_id);
                        }
                        else
                        {
                            updatePurchase(pur_id, money.ToString());
                        }
                         purchase_detail_id++;
                         tbPurchaseDetID.Text = purchase_detail_id.ToString();
                        tbAmount.Text = "";
                        tbMoney.Text = "";
                        
                    }
                    else
                        Response.Write("<script>$(document).ready(function(){swal(\"添加失败\", \"\", \"error\");})</script>");
                }
            }
        }

        public void insertPurchase(int pur_id, string totalmoney, string sta_id)
        {
            string time = DateTime.Now.ToShortDateString().ToString();
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmmd = new OleDbCommand("INSERT INTO purchase(pur_id,pur_status,pur_money,sta_id,pur_creat_time)VALUES(" + pur_id + "," + 1 + ",'" + totalmoney + "','" +sta_id+"','"+time+"')", conn))
                {
                    conn.Open();
                    cmmd.ExecuteNonQuery();
                }
            }
        }
        public void updatePurchase(int pur_id,string totalmoney)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmmd = new OleDbCommand("UPDATE purchase SET pur_money =+" + "'" + totalmoney + "'WHERE pur_id = " + pur_id, conn))
                {
                    conn.Open();
                    int affectedRows = cmmd.ExecuteNonQuery();
                }
            }
        }

        public string getStaID(string name)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmmd = new OleDbCommand(" SELECT sta_id FROM staff WHERE sta_name= '" + name+"'", conn))
                {
                    conn.Open();
                    string sta_id = (string)cmmd.ExecuteScalar();
                    return sta_id;
                }
            }
           
        }

        private void outputBasicJavascriptLib()
        {
            Response.Write("<script src=\"js/jquery-2.1.4.min.js\"></script>\n");
            Response.Write("<script type=\"text/javascript\" src=\"js/plugins/sweetalert.min.js\"></script>\n");
        }
    }
}