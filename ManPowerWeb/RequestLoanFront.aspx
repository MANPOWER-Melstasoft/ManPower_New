<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestLoanFront.aspx.cs" Inherits="ManPowerWeb.RequestLoanFront" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Apply Loan</h2>
        <div class="card-body">
            <asp:Button ID="btnAdd" runat="server" Text="Apply Loan" CssClass="btn btn-secondary btn-user " BackColor="#565656" BorderColor="#565656" Style="width: 200px;" OnClick="btnAdd_Click" />
            <div class="table-responsive" style="margin-top: 20px;">
                <asp:GridView ID="gvAppliedLoan" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField DataField="LoanType.Loan_Type_Name" HeaderText="Loan Type" />
                        <asp:BoundField DataField="ApprovalType.StatusName" HeaderText="Approval Status" />
                        <asp:BoundField DataField="LoanAmount" HeaderText="Amount" />
                        <asp:BoundField DataField="CreatedDate" HeaderText="Applied Date" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
