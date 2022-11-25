using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;




public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
   string tmp = RndNum(4); 
   Session["aa"]= tmp;
   HttpCookie a = new HttpCookie("ImageV",tmp);   
   Response.Cookies.Add(a);
   this.ValidateCode(tmp);


    }





    private void ValidateCode(string VNum) 
  {
   Bitmap Img=null;
   Graphics g=null;
   MemoryStream ms=null;

   int gheight=VNum.Length*12;
   Img=new Bitmap(gheight,25);
   g=Graphics.FromImage(Img);
   //背景颜色
   g.Clear(Color.Yellow);
   //文字字体
   Font f=new Font("Arial Black",10);
   //文字颜色
   SolidBrush s=new SolidBrush(Color.Black);
    g.DrawString(VNum, f, s, 3, 0);
   ms=new MemoryStream();
   Img.Save(ms,ImageFormat.Jpeg);
   Response.ClearContent(); 
   Response.ContentType="image/Jpeg";
   Response.BinaryWrite(ms.ToArray());
   
   g.Dispose();
   Img.Dispose();
   Response.End();
  }

    private string RndNum(int VcodeNum)
  {
   string Vchar="0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
   string[] VcArray=Vchar.Split(new Char [] {','});
   string VNum="";
   int temp=-1;

   Random rand=new Random();
   
   for(int i=1;i<VcodeNum+1;i++)
   {
   // if(temp!=-1)
   // {
   //  rand=new Random(i*temp*unchecked((int)DateTime.Now.Ticks));
   // }
   
    int t=rand.Next(35);
    if(temp!=-1&&temp==t)
    {
     return RndNum(VcodeNum);
    }
    temp=t;
    VNum+=VcArray[t];
   }
   return VNum;
  }


}
