<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Donors</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="GetData">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" SortExpression="BloodGroup" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="EncPass" HeaderText="EncPass" SortExpression="EncPass" />
                    <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
                    <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                    <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="GetData" runat="server" ConnectionString="<%$ ConnectionStrings:BloodDonorConnectionString %>" SelectCommand="SELECT * FROM [RegisterTbl] ORDER BY [BloodGroup], [DateOfBirth], [gender]"></asp:SqlDataSource>
            <div class="Content">
                <ul>
                    <li><asp:TextBox ID="UserName" runat="server" placeholder="username"></asp:TextBox> <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" /></li>
                    <li><asp:TextBox ID="LastName" runat="server" placeholder="lastName"></asp:TextBox> <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" /></li>
                    <li><asp:TextBox ID="BloodGroup" runat="server" placeholder="BloodGroup"></asp:TextBox> <asp:Button ID="update" runat="server" Text="Update" OnClick="update_Click" /></li>
                    <li><asp:TextBox ID="Email" runat="server" placeholder="Email"></asp:TextBox></li>
                    <li><asp:TextBox ID="Dob" runat="server" placeholder="Dob"></asp:TextBox></li>
                    <li><asp:TextBox ID="role" runat="server" placeholder="role"></asp:TextBox></li>
                </ul>
            </div>
            <div class="ReqContent">
                <h1>Requests</h1>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="RequestSource">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                        <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" SortExpression="BloodGroup" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="RequestSource" runat="server" ConnectionString="<%$ ConnectionStrings:BloodDonorConnectionString %>" SelectCommand="SELECT * FROM [RequestTbl] ORDER BY [BloodGroup], [UserName], [Email]"></asp:SqlDataSource>
            </div>
        </div>
        <asp:Button ID="logout" runat="server" Text="logout" OnClick="logout_Click" />
    </form>
    
</body>
</html>
