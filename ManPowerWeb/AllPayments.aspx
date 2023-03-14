<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllPayments.aspx.cs" Inherits="ManPowerWeb.AllPayments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card mb-4 mt-4">
        <div class="row" style="padding-top: 20px; padding-bottom: 20px; padding-left: 20px;">
            <div class="col-4">
                <asp:TextBox ID="txtKeyWord" runat="server" placeholder="Enter Keyword" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control form-control-user" DataTextField="monthName" DataValueField="monthNumber"></asp:DropDownList>
            </div>
            <div class="col-2">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSearch_Click" />
            </div>
            <div class="col-2">
                <asp:Button ID="btnGetAll" runat="server" Text="Get All" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGetAll_Click" />
            </div>
        </div>
    </div>

    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Payments</h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvPayments" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Payment Id" />
                    <asp:BoundField DataField="VoucherNumber" HeaderText="Voucher No." />
                    <asp:BoundField DataField="VoucherDate" HeaderText="Voucher Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="PayeeName" HeaderText="Payee Name" />
                    <asp:BoundField DataField="PayeeAddress" HeaderText="Payee Address" />
                    <asp:BoundField DataField="VoucherStatus.StatusName" HeaderText="Status" />
                    <asp:TemplateField HeaderText="View Details">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-secondary" ID="btvView" runat="server" OnClick="btvView_Click">View Details</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
