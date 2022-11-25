using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace test
{
    /// <summary>
    /// viewGrade 的摘要说明。
    /// </summary>
    public partial class viewGrade : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!IsPostBack)
            {
                //判断是否已登录
                if (Session["stuNo"] == null || Session["stuNo"].ToString() == "")
                {
                    Response.Redirect("default.aspx");
                }

                lblName.Text = "姓名：" + Session["stuName"].ToString();
                lblNo.Text = "学号：" + Session["stuNo"].ToString();
                //绑定显示学生的成绩
                dg.DataSource = DBHelper.GetDataSet("select 课程名,成绩 from  成绩 where 学号=  '" + Session["stuNo"].ToString() + "'");
                dg.DataBind();
            }
        }



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


    }
}
