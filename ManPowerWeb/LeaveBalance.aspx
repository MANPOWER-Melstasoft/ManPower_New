<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveBalance.aspx.cs" Inherits="ManPowerWeb.LeaveBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4">
            <div>
                <h3>Leave Balance</h3>
                <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                    <asp:GridView Style="margin-top: 30px;" ID="gvLeaveBalance" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                        CellPadding="4" GridLines="None" AllowPaging="true" HeaderStyle-HorizontalAlign="center" ShowFooter="true" OnRowDataBound="gvLeaveBalance_RowDataBound"
                        FooterStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                        <Columns>
                            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="Entitlement" HeaderText="Entitlement" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="ApprovedLeaves" HeaderText="Approved Leaves" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="PendingApproval" HeaderText="Pending Leaves" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="LeaveBalannce" HeaderText="Leave Balance" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>No records</EmptyDataTemplate>

                    </asp:GridView>
                </div>
            </div>
            <div class="mt-3">
                <h3>Previous Year Leave Balance</h3>
                <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                    <asp:GridView Style="margin-top: 30px;" ID="gvPreLeave" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                        CellPadding="4" GridLines="None" AllowPaging="true" HeaderStyle-HorizontalAlign="center" ShowFooter="true" OnRowDataBound="gvLeaveBalance_RowDataBound"
                        FooterStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                        <Columns>
                            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="Entitlement" HeaderText="Entitlement" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="ApprovedLeaves" HeaderText="Approved Leaves" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="PendingApproval" HeaderText="Pending Leaves" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField DataField="LeaveBalannce" HeaderText="Leave Balance" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>No records</EmptyDataTemplate>

                    </asp:GridView>
                </div>
            </div>
            <div class="row mb-5 ms-1 mt-4">
                <div class="col-sm-2">
                    <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="btnBack_Click" />

                </div>
            </div>
        </div>

    </div>
</asp:Content>
