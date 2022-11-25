using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace test
{
    /// <summary>
    /// _default 的摘要说明。
    /// </summary>
    public partial class _default : System.Web.UI.Page
    {



        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定课程名
                lstLesson.DataSource = DBHelper.GetDataSet("select distinct 课程名 from  题库");
                lstLesson.DataTextField = "课程名";
                lstLesson.DataBind();
            }

        }
        //单击进入考场
        protected void lnkEnter_Click(object sender, System.EventArgs e)
        {
            string sql, stuName, stuNo, lesson;
            //取得用户输入
            stuNo = txtNo.Text.Trim();
            lesson = lstLesson.SelectedValue;
            //判断学生是否存在
            sql = String.Format("select * from 学生 where 学号='{0}' and 密码='{1}'", stuNo, txtPwd.Text.Trim());
            SqlDataReader dr = DBHelper.GetReader(sql);
            if (!dr.Read())
            {
                Response.Write("<script>alert('登录失败，请检查学号和密码是否正确！')</script>");
                return;
            }
            else
            {
                stuName = dr["姓名"].ToString();
            }
            //判断是否已参加考试
            sql = String.Format("select count(*) from 成绩 where 学号='{0}' and 课程名='{1}'", stuNo, lesson);
            int ret = DBHelper.ExecScalar(sql);
            if (ret > 0)
            {
                Response.Write("<script>alert('你已经参加过这门课的考试！')</script>");
                return;
            }
            //把科目、学号、姓名存入到Session，以便传递给考试页面
            Session["stuNo"] = stuNo;
            Session["stuName"] = stuName;
            Session["lesson"] = lesson;
            //转向考试页面
            Response.Redirect("exam.aspx");
        }


    }
}
