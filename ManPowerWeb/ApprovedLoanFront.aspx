<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovedLoanFront.aspx.cs" Inherits="ManPowerWeb.ApprovedLoanFront" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card p-4 m-4">
        <h2>Approved Loans</h2>
        <div class="table-responsive mt-3" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvApprove1Admin" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Position" HeaderText="Position" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="LoanType.Loan_Type_Name" HeaderText="Loan Type" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="ApprovalType.StatusName" HeaderText="Approval Status" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="LoanAmount" HeaderText="Amount" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Applied Date" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-success" ID="btnView" runat="server" OnClick="btnView_Click">View Details</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
