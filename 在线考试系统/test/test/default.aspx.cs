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
    /// _default ��ժҪ˵����
    /// </summary>
    public partial class _default : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                //�󶨿γ���
                lstLesson.DataSource = DBHelper.GetDataSet("select distinct �γ��� from  ���");
                lstLesson.DataTextField = "�γ���";
                lstLesson.DataBind();
            }

        }
        //�������뿼��
        protected void lnkEnter_Click(object sender, System.EventArgs e)
        {
            string sql, stuName, stuNo, lesson;
            //ȡ���û�����
            stuNo = txtNo.Text.Trim();
            lesson = lstLesson.SelectedValue;
            //�ж�ѧ���Ƿ����
            sql = String.Format("select * from ѧ�� where ѧ��='{0}' and ����='{1}'", stuNo, txtPwd.Text.Trim());
            SqlDataReader dr = DBHelper.GetReader(sql);
            if (!dr.Read())
            {
                Response.Write("<script>alert('��¼ʧ�ܣ�����ѧ�ź������Ƿ���ȷ��')</script>");
                return;
            }
            else
            {
                stuName = dr["����"].ToString();
            }
            //�ж��Ƿ��Ѳμӿ���
            sql = String.Format("select count(*) from �ɼ� where ѧ��='{0}' and �γ���='{1}'", stuNo, lesson);
            int ret = DBHelper.ExecScalar(sql);
            if (ret > 0)
            {
                Response.Write("<script>alert('���Ѿ��μӹ����ſεĿ��ԣ�')</script>");
                return;
            }
            //�ѿ�Ŀ��ѧ�š��������뵽Session���Ա㴫�ݸ�����ҳ��
            Session["stuNo"] = stuNo;
            Session["stuName"] = stuName;
            Session["lesson"] = lesson;
            //ת����ҳ��
            Response.Redirect("exam.aspx");
        }


    }
}
