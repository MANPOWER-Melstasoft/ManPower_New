<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalaryIncrements.aspx.cs" Inherits="ManPowerWeb.SalaryIncrements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Salary Increments</h2>
        <div class="row mb-5" style="margin-left: 100px;">
            <div class="col-sm-4">
                <asp:TextBox ID="txtkeyword" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSearch_Click">Search</asp:LinkButton>
            </div>
            <div class="col-sm-2">
                <asp:LinkButton ID="btnGetAll" runat="server" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGetAll_Click">Get All</asp:LinkButton>
            </div>
        </div>
        <div class="row mb-5" style="margin-left: 100px;">
            <div class="col-sm-3">
                <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-secondary btn-user btn-block" OnClick="btnAdd_Click">Add New Salary Increment</asp:LinkButton>
            </div>
        </div>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvSalaryIncrement" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id" />
                    <asp:BoundField DataField="Employee.LastName" HeaderText="Employee Name" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" />
                    <asp:BoundField DataField="Allowances" HeaderText="Allowances" />
                    <asp:BoundField DataField="TotalSalary" HeaderText="Total Salary" />
                    <asp:BoundField DataField="SalaryIncrementStatus.StatusName" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
