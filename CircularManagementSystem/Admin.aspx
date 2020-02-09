<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Admin.aspx.cs" Inherits="CircularManagementSystem.Admin" %>
<asp:Content ID="Login" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="AddEmployee" ContentPlaceHolderID="contentLogin" runat="server">
    <asp:HyperLink ID="EmployeeGrid" runat="server" NavigateUrl="~/GridView.aspx" Text="EmployeeView"></asp:HyperLink>
            <asp:HyperLink ID="Grid" runat="server" NavigateUrl="~/DepartmentGridView.aspx" Text="DepartmentView"></asp:HyperLink>
</asp:Content>