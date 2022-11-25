<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" Height="268px" Width="476px" 
            AutoGenerateColumns="False" onrowediting="GridView1_RowEditing">
            <Columns>
                <asp:BoundField DataField="sno" HeaderText="学号" />
                <asp:BoundField DataField="sname" HeaderText="姓名" />
                <asp:BoundField DataField="sdept" HeaderText="系别" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
