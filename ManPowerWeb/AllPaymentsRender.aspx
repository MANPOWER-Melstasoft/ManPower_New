<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllPaymentsRender.aspx.cs" Inherits="ManPowerWeb.AllPaymentsRender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card m-4 p-4">
        <div id="PrintPart">
            <h2>Payment Voucher Details</h2>
            <div class="card-body">

                <div class="row mb-5 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="lblName" runat="server" Text="Supplier"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="txtSupplier" runat="server" CssClass="form-control form-control-user"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal1" runat="server" Text="Voucher Number"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="txtVNumber" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-5 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal5" runat="server" Text="Voucher Date"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="txtVDate" runat="server" CssClass="form-control form-control-user" Enabled="false" TextMode="Date"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal4" runat="server" Text="Payee Name"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="txtPName" runat="server" CssClass="form-control form-control-user" Enabled="false" TextMode="MultiLine"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-5 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal2" runat="server" Text="Payee Address"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="txtPAddres" runat="server" CssClass="form-control form-control-user" Enabled="false" TextMode="MultiLine"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal6" runat="server" Text="Cheque Number"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="txtChequeNumber" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-5 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal3" runat="server" Text="Total Amount"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="txtTotalAmount" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <h3>Bank Details</h3>

                <div class="row mb-5 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal17" runat="server" Text="Bank Name"></asp:Literal>
                            </div>

                            <div class="col-md-6">

                                <asp:Label ID="txtBankName" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:Label>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal18" runat="server" Text="Bank Branch Name"></asp:Literal>
                            </div>

                            <div class="col-md-6">

                                <asp:Label ID="txtBankBranch" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:Label>

                            </div>
                        </div>
                    </div>
                </div>


                <div class="row mb-5 ms-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal16" runat="server" Text="Bank Account"></asp:Literal>
                            </div>

                            <div class="col-md-6">


                                <asp:Label ID="txtBankAcc" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:Label>
                                <div class="d-flex text-danger">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div class="row mb-3  mt-5">

                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary mr-3" Style="width: 150px;" OnClick="btnBack_Click" />
                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-success btn-user " Style="width: 150px;" OnClientClick="javascript:printDiv()" />
            </div>
        </div>
    </div>
    <script language="javascript" type="text/javascript">

        function printDiv() {
            var divContents = document.getElementById("PrintPart").innerHTML;
            var a = window.open('', '');
            a.document.write('<html><head>' +

                '<style>' +
                ' @media print {' +
                '   .parent {' +
                'overflow: scroll;' +
                'display: block;' +
                ' }' +
                ' .pb_after  { page -break-after: always!important; }' +
                ' }    ' +
                '</style > ' +

                '<link rel="icon" type="image/x-icon" href="img/favicon.png" />' +
                '<link href="css/sb-admin-2.min.css" rel="stylesheet">' +
                '<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">' +
                '<link rel = "stylesheet" href = "https://www.w3schools.com/w3css/4/w3.css" media="print">' +
                '<link href="https://cdn.jsdelivr.net/npm/simple-datatables@latest/dist/style.css" rel="stylesheet" media=\"print\"/>' +
                '<link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" media="print">' +
                '<link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" media="print">' +
                '</head>');
            a.document.write('<body > ');
            a.document.write(divContents);
            a.document.write('</body></html>');
            a.document.close();
            a.print();
            setTimeout(function () { a.print(); }, 4000);
        }

    </script>
</asp:Content>
