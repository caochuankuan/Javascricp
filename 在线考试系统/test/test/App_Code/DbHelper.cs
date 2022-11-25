using System;
using System.Data;
using System.Data.SqlClient;
namespace test
{

	public class DBHelper
	{
		//根据Select查询sql，返回DataSet
		public static DataSet GetDataSet(string sql)
		{	
			SqlConnection conn=new SqlConnection(GetConnStr());				
			SqlDataAdapter da = new SqlDataAdapter(sql,conn);
			DataSet ds= new DataSet();
			da.Fill(ds);
			return ds ;
		}
        //根据Select查询sql，返回SqlDataReader
		public  static  SqlDataReader GetReader(String sql)
		{
			SqlDataReader dr=null;
			SqlConnection conn=new SqlConnection(GetConnStr());
			SqlCommand cmd = new SqlCommand(sql, conn);
			conn.Open();
			try
			{
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch
			{
			conn.Close();
			}
			return dr;				
		}
        //根据Select查询sql，返回一个整数
		public  static  int ExecScalar(String sql)
		{
			int ret;
			SqlConnection conn=new SqlConnection(GetConnStr());
			SqlCommand cmd = new SqlCommand(sql, conn);
			conn.Open();
			try
			{
				ret= (int)cmd.ExecuteScalar();			
			}
			finally
			{
				conn.Close();			
			}
			return ret;				
		}
        //运行updae、Insert、Delete等SQL语句
		public  static  int ExecSql(string sql)
		{
			int ret;
			SqlConnection conn=new SqlConnection(GetConnStr());
     		SqlCommand cmd = new SqlCommand(sql, conn);
			conn.Open();
			try
			{
				ret = cmd.ExecuteNonQuery();
			}
			finally
			{
				conn.Close();
			}
			return ret;	
		}	
		//从web.config中读人数据库连接信息
		public static String GetConnStr()
		{		
			return System.Configuration.ConfigurationSettings.AppSettings["Db"];							
		}
		
	}
}

