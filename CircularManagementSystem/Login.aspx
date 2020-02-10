<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Login.aspx.cs" Inherits="CircularManagementSystem.Login" %>

<asp:Content ID="loginHead" runat="server" ContentPlaceHolderID="head"></asp:Content>
<asp:Content ID="contentHeader" runat="server" ContentPlaceHolderID="ContentMaster" runtat="server">
    <h1>Employee Login:</h1>
    <table>
        <tr>
            <td>User name: </td>
            <td>
                <asp:TextBox ID="txtUserId" placeholder="Enter email address" type="text" runat="server" name="username" />
                <asp:RegularExpressionValidator ID="UserIdValidator" runat="server" ControlToValidate="txtUserId"
                 ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                 Display = "Dynamic" ErrorMessage = "Invalid email address"/>
                <asp:RequiredFieldValidator ID="UserIdFieldValidator" runat="server" ControlToValidate="txtUserId"
                 ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />
            </td>
        </tr>
        <tr>
            <td>Password: </td>
            <td>
                <asp:TextBox ID="Password" placeholder="Enter password" type="password" runat="server" name="password" />
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="Password" ID="PasswordValidator" ValidationExpression="([0-9-A-Z-a-z-!@#$%^&*()_+=\[{\]};:<>|./?,-].{5,15})" runat="server" Forecolor="Red" ErrorMessage="Invalid Password"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Submit" value="submit" runat="server" OnClick="Submit_Click" Text="Submit" /></td>
        </tr>
    </table>
</asp:Content>
