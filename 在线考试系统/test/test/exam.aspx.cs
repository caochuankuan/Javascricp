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
    /// exam 的摘要说明。
    /// </summary>
    public partial class exam : System.Web.UI.Page
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
            //判断是否已登录
            if (Session["stuNo"] == null || Session["stuNo"].ToString() == "")
            {
                Response.Redirect("default.aspx");
            }

            //取得Session中传入的参数
            lblLesson.Text = Session["lesson"].ToString();
            lblName.Text = Session["stuName"].ToString();
            lblNo.Text = Session["stuNo"].ToString();

            //下面根据题库生成试卷界面

            //取得试题
            SqlDataReader dr = DBHelper.GetReader("select *  from 题库 where  课程名='" + lblLesson.Text + "'   Order By 题号");
            int num = 1;   //num--试题序号
            while (dr.Read())
            {
                //加入题目
                Literal Literal1 = new Literal();
                Literal1.Text = num.ToString() + "." + dr["题目"].ToString() + "(" + dr["分数"].ToString() + "分)<br>";
                PlaceHolder1.Controls.Add(Literal1);

                //根据题型（单选、复选）决定使用RadioButtonList还是CheckBoxList
                ListControl list;
                if (dr["类型"].ToString() == "单选")
                {
                    list = new RadioButtonList();
                }
                else  //复选
                {
                    list = new CheckBoxList();

                }
                //加入选项内容
                list.Items.Add(Server.HtmlEncode(dr["选项1"].ToString()));
                list.Items.Add(Server.HtmlEncode(dr["选项2"].ToString()));
                list.Items.Add(Server.HtmlEncode(dr["选项3"].ToString()));
                list.Items.Add(Server.HtmlEncode(dr["选项4"].ToString()));
                PlaceHolder1.Controls.Add(list);

                num = num + 1;
            }
            dr.Close();
        }

        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            string sql, answer;
            //取得试题
            SqlDataReader dr = DBHelper.GetReader("select *  from 题库 where  课程名='" + lblLesson.Text + "'   Order By 题号");

            //下面计算考试分数
            int j = 0;    //循环变量 
            int sum = 0;  //sum--考试分数
            while (dr.Read())
            {
                ListControl list = (ListControl)PlaceHolder1.Controls[2 * j + 1];

                //取得考生的答案
                answer = "";  //answer--考生答案
                for (int i = 0; i < list.Items.Count; i++)
                {
                    if (list.Items[i].Selected)
                        answer += (i + 1).ToString();
                }

                if (answer == dr["解答"].ToString())
                    sum = sum + Convert.ToInt32(dr["分数"].ToString());

                j = j + 1;
            }

            //把考试成绩记录插入成绩表中
            sql = String.Format("insert into  成绩(学号,  课程名, 成绩)  values('{0}','{1}',{2}) ", lblNo.Text, lblLesson.Text, sum.ToString());
            DBHelper.ExecSql(sql);
            //转向查看成绩页面
            Response.Redirect("viewGrade.aspx");

        }
    }
}
