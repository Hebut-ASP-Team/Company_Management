<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data.SqlServerCe;
using System.Web.Script.Serialization;
using System.Data;
using System.Collections;
using System.Collections.Generic;

public class Handler : IHttpHandler {

   
    string con = @"Data Source='" + System.Web.HttpContext.Current.Server.MapPath("~/app_data/chartdb.sdf") + "'";
    DataSet ds = new DataSet();
    SqlCeDataAdapter da = new SqlCeDataAdapter();
    JavaScriptSerializer jsS = new JavaScriptSerializer();
    List<object> lists = new List<object>();
    string result = "";
    
    public void ProcessRequest (HttpContext context) {


        string command = context.Request["cmd"];


        switch (command)
        {
            case "pie":
                GetPie(context);
                break;
            case "bar":
                GetBars(context);
                break;
        };

    }


    public void GetPie(HttpContext context)
        {
            string sql = @"  select categoryname as name, count(*) as count from lists group by categoryname";
            ds = GetData(sql);
           
            lists = new List<object>(); 
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var obj = new { name = dr["name"], value = dr["count"] };
                lists.Add(obj); 
            } 

            jsS = new JavaScriptSerializer(); 
            result = jsS.Serialize(lists); 
            context.Response.Write(result);
        
        }



    public void GetBars(HttpContext context)
        {
           string sql = @"  select CONVERT(NVARCHAR(10),createdate,120) as date,   count(*) as count from lists  
group by CONVERT(NVARCHAR(10),createdate,120) ";
            ds = GetData(sql);
            lists = new List<object>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var obj = new { name = dr["date"], value = dr["count"] };
                lists.Add(obj);

            } 
        
            jsS = new JavaScriptSerializer();
            result = jsS.Serialize(lists);
            context.Response.Write(result);
        }



    public DataSet GetData(string sql)
    { 
        ds = new DataSet();
        da = new SqlCeDataAdapter(sql, con);
        da.Fill(ds);
        return ds;
    
    }
    
    
    
    
    
    
    
    
    
    
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}