<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="AddEmployee.aspx.cs" Inherits="CircularManagementSystem.AddEmployee" %>
<asp:Content ID="AddEmployeePage" runat="server" ContentPlaceHolderID="contentMaster">
       <asp:HyperLink ID="EmployeeGrid" runat="server" NavigateUrl="~/EmployeeGridView.aspx" Text="ViewEmployees" align="right"></asp:HyperLink>
            <asp:HyperLink ID="Grid" runat="server" NavigateUrl="~/DepartmentGridView.aspx" Text="ViewAndAddDepartment" align="right"></asp:HyperLink>
        <div>
            <h1>Employee Registration</h1>
            <table>
                <tr>
                    <td>EmployeeName:</td>
                    <td>
                        <asp:TextBox ID="txtemployeename" type="text" runat="server" name="employeeName"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="NameValid" ValidationExpression="^[a-zA-Z'.\s]{1,50}" runat="server" ErrorMessage="Enter valid name" ControlToValidate="txtemployeename" ForeColor="Red"></asp:RegularExpressionValidator></td> </tr>
                <tr>
                    <td>EmployeePhoneNumber</td>
                    <td>
                        <asp:TextBox ID="employeephoneNumber" type="text" runat="server" name="employeePhone"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="phoneNumberValidator" runat="server" ControlToValidate="employeephoneNumber" ErrorMessage="Enter valid phone Number"  ValidationExpression="[6-9]{1}[0-9]{9}"/>
                    </td>
                </tr>
                <tr>
                    <td>Department:</td>
                    <td>
                        <asp:DropDownList ID="departmentList" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="departmentValidator" runat="server" ControlToValidate="departmentList"
                ErrorMessage="Value Required!" InitialValue="--Select--"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Choose Reporting Manager:</td>
                    <td>
                        <asp:DropDownList ID="managerList" runat="server">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem>CEO</asp:ListItem>
                            <asp:ListItem>ProjectManager</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ManagerValidator" runat="server" ControlToValidate="managerList"
                ErrorMessage="Value Required!" InitialValue="--Select--"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Enter Designation:</td>
                    <td>
                        <asp:DropDownList ID="empDesignation" runat="server">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem>CEO</asp:ListItem>
                            <asp:ListItem>ProjectManager</asp:ListItem>
                            <asp:ListItem>Tester</asp:ListItem>
                            <asp:ListItem>Junior Application developer</asp:ListItem>
                            <asp:ListItem>Senior Application developer</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="DesignationValidator" runat="server" ControlToValidate="empDesignation"
                ErrorMessage="Value Required!" InitialValue="--Select--"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Enter Email Id:</td>
                    <td>
                        <asp:TextBox ID="txtEmailId" runat="server" type="text" name="employeeMail">
                        </asp:TextBox><asp:RegularExpressionValidator ID="EmailIdValidator" runat="server" ControlToValidate="txtEmailId"
                 ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                 Display = "Dynamic" ErrorMessage = "Invalid email address"/>
                <asp:RequiredFieldValidator ID="EmailIdFieldValidator" runat="server" ControlToValidate="txtEmailId"
                 ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="submitButton" runat="server" OnClick="Submit_Button" value="Submit" Text="Submit" /></td>
                </tr>
            </table>
        </div>
    </asp:Content>
