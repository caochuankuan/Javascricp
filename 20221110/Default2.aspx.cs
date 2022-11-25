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
        if (!IsPostBack)
        {
            getdata();
        }
    }

    public void getdata()
    {
        //1、连接对象 2、执行命令对象 3、执行内容是什么 4、执行 
        string strcon = "Server=逸风;uid=sa;pwd=123456;database=web";//strConn是用于数据库连接的
        SqlConnection con = new SqlConnection(strcon);//创建数据库连接实例
        string sql = "select * from student";
        SqlCommand com = new SqlCommand(sql, con);//Command对象的构造函数的参数有两个，一个是需要执行的SQL语句，另一个是数据库连接对象。
        SqlDataAdapter da = new SqlDataAdapter(com);//数据适配器
        DataSet ds = new DataSet();//数据集
        da.Fill(ds, "a1");//通过适配器对象的Fill方法将数据填充到数据集中
        //da.Fill(ds, "a1")中，ds是dataset类的对象，就是一个表的集合，是之前声明好的。然后a1就是说你要把数据保存到ds里面的一个名字叫做a1的表中。如果不存在a1这个表，那么da会自己新建一个名字叫a1的表。如果已经存在表a1，那么这次查询到的内容会追加到表后。
        GridView1.DataSource = ds.Tables[0].DefaultView;//默认视图
        GridView1.DataBind();//数据绑定
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        getdata();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string s1 = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        //Response.Write(s1);
        string s2 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString();
        string strcon = "Server=逸风;uid=sa;pwd=123456;database=web";
        SqlConnection con = new SqlConnection(strcon);
        con.Open();
        string sql = "update student set sdept='"+s2+"' where sno='"+s1+"'";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        getdata();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        getdata();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string s1 = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string strcon = "Server=逸风;uid=sa;pwd=123456;database=web";
        SqlConnection con = new SqlConnection(strcon);
        con.Open();
        string sql = "delete from student where sno='" + s1 + "'";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        getdata();
    }
}