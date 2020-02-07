<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="DepartmentGridView.aspx.cs" Inherits="CircularManagementSystem.DepartmentGridView" %>
<asp:Content ID="Grid" runat="server" ContentPlaceHolderID="DepartmentView">
    <div>
        <asp:GridView ID="departmentGridView" runat="server"></asp:GridView>
    </div>
</asp:Content>