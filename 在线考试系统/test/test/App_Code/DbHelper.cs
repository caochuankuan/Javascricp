using System;
using System.Data;
using System.Data.SqlClient;
namespace test
{

	public class DBHelper
	{
		//����Select��ѯsql������DataSet
		public static DataSet GetDataSet(string sql)
		{	
			SqlConnection conn=new SqlConnection(GetConnStr());				
			SqlDataAdapter da = new SqlDataAdapter(sql,conn);
			DataSet ds= new DataSet();
			da.Fill(ds);
			return ds ;
		}
        //����Select��ѯsql������SqlDataReader
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
        //����Select��ѯsql������һ������
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
        //����updae��Insert��Delete��SQL���
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
		//��web.config�ж������ݿ�������Ϣ
		public static String GetConnStr()
		{		
			return System.Configuration.ConfigurationSettings.AppSettings["Db"];							
		}
		
	}
}

