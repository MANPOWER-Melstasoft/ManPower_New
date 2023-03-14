<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentVoucherReport.aspx.cs" Inherits="ManPowerWeb.PaymentVoucherReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>


    <div class="container">
        <div class="card p-4 mb-4 mt-5">
            <h2>Payment Voucher Report</h2>

            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-4 mt-4">
                        <div class="row">
                            <div class="col-4">
                                <asp:TextBox ID="txtName" runat="server" placeholder="Search by Name" CssClass="form-control form-control-user"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <asp:TextBox ID="txtLocation" runat="server" placeholder="Search by Location" CssClass="form-control form-control-user"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnGetAll" runat="server" Text="Get All" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGetAll_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="table-responsive mt-5 mb-4">
                        <asp:Label ID="lblMSG" runat="server" Text="" CssClass="ml-2"></asp:Label>
                        <asp:Table ID="tblTaSummary" runat="server" CssClass="table table-bordered"></asp:Table>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>--%>



            <div class="table-responsive mt-4 mb-4">
                <asp:GridView ID="gvPaymentVoucher" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None"
                    ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Supplier.Name" HeaderText="Supplier Name" />
                        <%--  <asp:TemplateField HeaderText="Project Type">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("ProjectTypeId").ToString()=="2"?true:false%>' Text="Physical"></asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("ProjectTypeId").ToString()=="1"?true:false%>' Text="Online"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="VoucherNumber" HeaderText="Voucher Number" />
                        <asp:BoundField DataField="VoucherDate" HeaderText="Voucher Date" DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField="PayeeName" HeaderText="Payee Name" />
                        <asp:BoundField DataField="PayeeAddress" HeaderText="Payee Address" />
                        <asp:BoundField DataField="ChequeNumber" HeaderText="Cheque Number" />
                        <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="Rs {0:N2}" />

                        <asp:BoundField DataField="BankAccount" HeaderText="Bank Account" />
                        <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                        <asp:BoundField DataField="Bank Branch" HeaderText="Bank Branch" />
                        <asp:BoundField DataField="VoucherStatus.StatusName" HeaderText="Voucher Status" />

                    </Columns>
                    <EmptyDataTemplate>No Payment Vouchers to Show </EmptyDataTemplate>
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
