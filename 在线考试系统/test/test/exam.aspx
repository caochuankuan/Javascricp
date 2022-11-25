<%@ Page language="c#" Inherits="test.exam" CodeFile="exam.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>exam</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body>
		<form id="Form1" method="post" runat="server" width="800px">
            &nbsp;<table align="center" width="80%">
                <tr>
                    <td >
                    
                        课程：<asp:Label id="lblLesson" 				runat="server" Font-Bold="True">lblLesson</asp:Label>
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        学号：<asp:Label id="lblNo"  runat="server" Font-Bold="True">lblNo</asp:Label>
                        &nbsp; &nbsp; &nbsp;&nbsp;
                        姓名：<asp:Label id="lblName"  runat="server" Font-Bold="True">lblName</asp:Label></td>
                </tr>
            </table>
            <br />
			<TABLE id="Table1"  cellSpacing="1" align="center"				cellPadding="1" width="80%" border="0">
				<TR>
					<TD style="HEIGHT: 53px">
						<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Button id="btnSubmit" runat="server" Text="交卷" onclick="btnSubmit_Click"></asp:Button></TD>
				</TR>
			</TABLE>
			&nbsp; &nbsp; &nbsp; &nbsp;

		</form>
	</body>
</HTML>
