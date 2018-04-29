using System;
using System.Collections.Generic;
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
            showCompanyList();
        }

        protected void showCompanyList()
        {
            if (!IsPostBack)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionStr))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from dbo.staff", conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        gv_company_list.DataSource = ds;
                        gv_company_list.DataBind();
                    }
                }
            }
        }

        protected void Delete(int staId)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmd = new OleDbCommand("delete from staff where sta_id=" + staId, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}