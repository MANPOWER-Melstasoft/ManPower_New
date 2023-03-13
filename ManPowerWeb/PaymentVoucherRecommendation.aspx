<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentVoucherRecommendation.aspx.cs" Inherits="ManPowerWeb.PaymentVoucherRecommendation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
    <div class="card m-4 p-4">
        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView Style="margin-top: 30px;" ID="gvPaymentVoucher" runat="server" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" AllowPaging="true" PageSize="5" HeaderStyle-HorizontalAlign="Center"
                ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="Supplier.Name" HeaderText="Supplier Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="VoucherNumber" HeaderText="Voucher Number" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="PayeeName" HeaderText="PayeeName" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-success" Width="100px" Height="35px" OnClick="btnView_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>No records</EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <div class="card m-4 p-4">
        <h2>Payment Voucher Details</h2>
        <div class="card-body">

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="lblName" runat="server" Text="Supplier"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtSupplier" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtSupplier" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal1" runat="server" Text="Voucher Number"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtVNumber" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtVNumber" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal5" runat="server" Text="Voucher Date"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtVDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtVDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal4" runat="server" Text="Payee Name"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtPName" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtPName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal2" runat="server" Text="Payee Address"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtPAddres" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtPAddres" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal6" runat="server" Text="Cheque Number"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtChequeNumber" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtChequeNumber" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal3" runat="server" Text="Total Amount"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtTotalAmount" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div hidden="hidden">
                <%-- Voucher Autorized --%>

                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal7" runat="server" Text="Is Voucher Autorized"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbIsVoucherAuthorized" runat="server" AutoPostBack="true">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                </asp:RadioButtonList>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="1"
                                        ControlToValidate="rbIsVoucherAuthorized" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <% if (rbIsVoucherAuthorized.SelectedValue == "1")
                    { %>

                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal8" runat="server" Text="Voucher Autorized Date"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtVAutorizedDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="1"
                                        ControlToValidate="txtVAutorizedDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal9" runat="server" Text="Voucher Autorized Name"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtVAutorizedName" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="1"
                                        ControlToValidate="txtVAutorizedName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <% } %>

                <%-- Voucher Autorized End--%>


                <%-- Payee Autorized --%>

                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal10" runat="server" Text="Is Pay Autorized"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbPayAutorized" runat="server" AutoPostBack="true">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                </asp:RadioButtonList>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="1"
                                        ControlToValidate="rbPayAutorized" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <% if (rbPayAutorized.SelectedValue == "1")
                    { %>
                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal11" runat="server" Text="Pay Autorized Date"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtPayAutorizedDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="1"
                                        ControlToValidate="txtPayAutorizedDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal12" runat="server" Text="Pay Autorized Name"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtPayAutorizedName" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="1"
                                        ControlToValidate="txtPayAutorizedName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <% } %>

                <%-- Payee Autorized End--%>

                <%-- Cancel Autorized --%>

                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal13" runat="server" Text="Is Cancel"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbIsCanceled" runat="server" AutoPostBack="true">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                </asp:RadioButtonList>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="1"
                                        ControlToValidate="rbIsCanceled" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <% if (rbIsCanceled.SelectedValue == "1")
                    { %>
                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal14" runat="server" Text="Cancel Date"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtCancelDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="1"
                                        ControlToValidate="txtCancelDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal15" runat="server" Text="Cancel Name"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtCancelName" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ValidationGroup="1"
                                        ControlToValidate="txtCancelName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <% } %>

                <%-- Cancel End--%>
            </div>


            <h3>Bank Details</h3>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal17" runat="server" Text="Bank Name"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal18" runat="server" Text="Bank Branch Name"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtBankBranch" runat="server" CssClass="form-control form-control-user"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>


            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal16" runat="server" Text="Bank Account"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtBankAcc" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="row mb-3  mt-5">

                    <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger mr-3" OnClick="btnReject_Click" />
                    <asp:Button ID="btnApprove" runat="server" Text="Send to Approval" CssClass="btn btn-success btn-user " OnClick="btnApprove_Click" />
                </div>
            </div>
            <div class="col-sm-6 m-3">
                <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
            </div>

        </div>
    </div>
</asp:Content>
