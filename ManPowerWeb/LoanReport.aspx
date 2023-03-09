<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoanReport.aspx.cs" Inherits="ManPowerWeb.LoanReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4 mb-4 mt-5">
            <h2>Loan Detail Summary</h2>

            <div class="mb-4 mt-4">
                <div class="row">
                    <div class="col-4">
                        <asp:TextBox ID="txtKeyWord" runat="server" placeholder="Search KeyWord" CssClass="form-control form-control-user"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSearch_Click" />
                    </div>
                    <div class="col-2">
                        <asp:Button ID="btnGetAll" runat="server" Text="Get All" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGetAll_Click" />
                    </div>
                </div>
            </div>
            <div class="table-responsive mt-4 mb-4">
                <asp:GridView ID="gvLoanReport" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Employee ID" />
                        <asp:BoundField DataField="Full_Name" HeaderText="Name" />
                        <asp:BoundField DataField="position" HeaderText="Designation" />
                        <asp:BoundField DataField="loan_type_name" HeaderText="Loan Type" />
                        <asp:BoundField DataField="loan_amount" HeaderText="Amount" />
                        <asp:BoundField DataField="created_date" HeaderText="Applied Date" />
                        <asp:BoundField DataField="approve_date" HeaderText="Approved Date" />
                        <asp:BoundField DataField="district" HeaderText="District" />
                        <asp:BoundField DataField="DSDivision" HeaderText="Division" />
                    </Columns>
                </asp:GridView>
            </div>

            <div>
                <button runat="server" id="btnRun" onserverclick="btnExportExcel_Click" class="btn btn-success" title="Export To Excel">
                    <i class="fa fa-file-export" style="margin-right: 10px"></i>Export To Excel
                </button>
            </div>
        </div>
    </div>
</asp:Content>
