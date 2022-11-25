<%@ Page language="c#" Inherits="test._default" CodeFile="default.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<Body>
		<Form Runat="Server" ID="Form1">
			&nbsp; &nbsp;&nbsp;
			<P></P>
			<P>
                &nbsp; &nbsp;&nbsp;
                <table align="center" style="width: 240px; height: 163px">
                    <tr>
                        <td align="center" colspan="2" style="height: 67px">
                            <strong>
                            在线考试系统</strong></td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 33px" >
                            科目：</td>
                        <td style="height: 33px" >
				<asp:DropDownList id="lstLesson" 
					runat="server" Width="120px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" style=" height: 33px" >
                            学号：</td>
                        <td style="height: 33px" >
			<asp:TextBox id="txtNo" runat="server" Width="120px" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" style=" height: 36px" >
                            密码：</td>
                        <td style=" height: 36px;"><asp:TextBox id="txtPwd" 
					runat="server" Width="120px" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 42px" >
				<Asp:LinkButton Runat="Server" Text="进入考场" ID="lnkEnter"  onclick="lnkEnter_Click">
进入考场</Asp:LinkButton></td>
                    </tr>
                </table>
            </P>
		</Form>
	</Body>
</HTML>
