using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //1、连接对象 2、执行命令对象 3、执行内容是什么 4、执行 
        string strconn = "Server=逸风;uid=sa;pwd=123456;database=web";
        SqlConnection conn = new SqlConnection(strconn); 
        string sql="select * from student";
        SqlCommand com = new SqlCommand(sql,conn);
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataSet ds = new DataSet();
        da.Fill(ds, "a1");
        GridView1.DataSource=ds.Tables[0].DefaultView;
        GridView1.DataBind();
         
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
    }
}