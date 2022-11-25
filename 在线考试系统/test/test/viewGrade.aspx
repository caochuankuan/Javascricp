<%@ Page language="c#" Inherits="test.viewGrade" CodeFile="viewGrade.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>viewGrade</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300px" border="0" align="center">
				<TR>
					<TD style="HEIGHT: 66px;" align="center">
						<asp:Label id="lblNo" runat="server" Width="80px" Font-Bold="True">lblNo</asp:Label>
                        &nbsp; &nbsp;
				
				
						<asp:Label id="lblName" runat="server" Width="97px" Font-Bold="True">lblName</asp:Label></TD>
				</TR>
				<TR>
					<TD  valign="top" >
                        <asp:GridView ID="dg" runat="server"  width="300px" BorderWidth="2px" >
                            <RowStyle HorizontalAlign="Center" Height="30px" BorderStyle="Solid" BorderWidth="2px" />
                        </asp:GridView>
                    </TD>
				</TR>
				<TR>
					<TD align="center" style="height: 55px" >
						<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="default.aspx" Width="45px">·µ»Ø</asp:HyperLink></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
