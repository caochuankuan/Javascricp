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
    /// viewGrade ��ժҪ˵����
    /// </summary>
    public partial class viewGrade : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!IsPostBack)
            {
                //�ж��Ƿ��ѵ�¼
                if (Session["stuNo"] == null || Session["stuNo"].ToString() == "")
                {
                    Response.Redirect("default.aspx");
                }

                lblName.Text = "������" + Session["stuName"].ToString();
                lblNo.Text = "ѧ�ţ�" + Session["stuNo"].ToString();
                //����ʾѧ���ĳɼ�
                dg.DataSource = DBHelper.GetDataSet("select �γ���,�ɼ� from  �ɼ� where ѧ��=  '" + Session["stuNo"].ToString() + "'");
                dg.DataBind();
            }
        }



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


    }
}
