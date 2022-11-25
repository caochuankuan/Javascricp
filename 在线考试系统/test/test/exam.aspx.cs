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
    /// exam ��ժҪ˵����
    /// </summary>
    public partial class exam : System.Web.UI.Page
    {




        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //�ж��Ƿ��ѵ�¼
            if (Session["stuNo"] == null || Session["stuNo"].ToString() == "")
            {
                Response.Redirect("default.aspx");
            }

            //ȡ��Session�д���Ĳ���
            lblLesson.Text = Session["lesson"].ToString();
            lblName.Text = Session["stuName"].ToString();
            lblNo.Text = Session["stuNo"].ToString();

            //���������������Ծ����

            //ȡ������
            SqlDataReader dr = DBHelper.GetReader("select *  from ��� where  �γ���='" + lblLesson.Text + "'   Order By ���");
            int num = 1;   //num--�������
            while (dr.Read())
            {
                //������Ŀ
                Literal Literal1 = new Literal();
                Literal1.Text = num.ToString() + "." + dr["��Ŀ"].ToString() + "(" + dr["����"].ToString() + "��)<br>";
                PlaceHolder1.Controls.Add(Literal1);

                //�������ͣ���ѡ����ѡ������ʹ��RadioButtonList����CheckBoxList
                ListControl list;
                if (dr["����"].ToString() == "��ѡ")
                {
                    list = new RadioButtonList();
                }
                else  //��ѡ
                {
                    list = new CheckBoxList();

                }
                //����ѡ������
                list.Items.Add(Server.HtmlEncode(dr["ѡ��1"].ToString()));
                list.Items.Add(Server.HtmlEncode(dr["ѡ��2"].ToString()));
                list.Items.Add(Server.HtmlEncode(dr["ѡ��3"].ToString()));
                list.Items.Add(Server.HtmlEncode(dr["ѡ��4"].ToString()));
                PlaceHolder1.Controls.Add(list);

                num = num + 1;
            }
            dr.Close();
        }

        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            string sql, answer;
            //ȡ������
            SqlDataReader dr = DBHelper.GetReader("select *  from ��� where  �γ���='" + lblLesson.Text + "'   Order By ���");

            //������㿼�Է���
            int j = 0;    //ѭ������ 
            int sum = 0;  //sum--���Է���
            while (dr.Read())
            {
                ListControl list = (ListControl)PlaceHolder1.Controls[2 * j + 1];

                //ȡ�ÿ����Ĵ�
                answer = "";  //answer--������
                for (int i = 0; i < list.Items.Count; i++)
                {
                    if (list.Items[i].Selected)
                        answer += (i + 1).ToString();
                }

                if (answer == dr["���"].ToString())
                    sum = sum + Convert.ToInt32(dr["����"].ToString());

                j = j + 1;
            }

            //�ѿ��Գɼ���¼����ɼ�����
            sql = String.Format("insert into  �ɼ�(ѧ��,  �γ���, �ɼ�)  values('{0}','{1}',{2}) ", lblNo.Text, lblLesson.Text, sum.ToString());
            DBHelper.ExecSql(sql);
            //ת��鿴�ɼ�ҳ��
            Response.Redirect("viewGrade.aspx");

        }
    }
}
