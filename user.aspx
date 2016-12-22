<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" SortExpression="BloodGroup" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
                    <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BloodDonorConnectionString %>" SelectCommand="SELECT [FirstName], [LastName], [BloodGroup], [Email], [DateOfBirth], [gender] FROM [RegisterTbl] ORDER BY [BloodGroup], [DateOfBirth], [gender]"></asp:SqlDataSource>
        </div>
        <div class="request">
            <fieldset>
                <legend>Request</legend>
                <ul>
                    <li>
                        <asp:TextBox ID="FullName" runat="server" Placeholder="Enter Full Name"></asp:TextBox>
                    </li>
                    <li>
                        <asp:TextBox ID="Group" runat="server" Placeholder="Enter Blood Group "></asp:TextBox>

                    </li>
                    <li>
                        <asp:TextBox ID="Email" runat="server" Placeholder="Enter Email"></asp:TextBox>

                    </li>
                    <li>
                        <asp:Button ID="Requst" runat="server" Text="Request" OnClick="Requst_Click" />

                    </li>
                </ul>
            </fieldset>
        </div>
        <asp:Button ID="logout" runat="server" Text="logout" OnClick="logout_Click" />
    </form>
</body>
</html>
