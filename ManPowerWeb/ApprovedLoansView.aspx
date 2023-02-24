<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovedLoansView.aspx.cs" Inherits="ManPowerWeb.ApprovedLoansView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="PrintPart " id="PrintPart">
                <% if (ddlLoanType.SelectedValue == "1")
                    { %>
                <div class="d-flex align-items-center justify-content-center">
                    <h2>SPECIAL LOAN APPLICATION</h2>

                </div>
                <% } %>
                <% if (ddlLoanType.SelectedValue == "2")
                    { %>
                <div class="d-flex align-items-center justify-content-center">

                    <h2>FESTIVAL LOAN APPLICATION</h2>

                </div>
                <% } %>
                <% if (ddlLoanType.SelectedValue == "3")
                    { %>
                <div class="d-flex align-items-center justify-content-center">

                    <h2>DISTRESS LOAN APPLICATION</h2>
                </div>
                <% } %>
                <%-----------------------------------------User details-----------------------------------%>
                <div class="card m-4 p-4">

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="lblName" runat="server" Text="Loan Type" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="lblLoanType" runat="server"></asp:Label>
                                    <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="form-control form-control-user d-none" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal1" runat="server" Text="Full Name :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtName" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal2" runat="server" Text="Position :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtPosition" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal4" runat="server" Text="Position Type :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtPositionType" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal3" runat="server" Text="Work Place :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtWorkPlace" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal5" runat="server" Text="Appointment Date :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtAppointmentDate" runat="server" TextMode="Date" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal6" runat="server" Text="Basic Salary :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtBasicSalary" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal7" runat="server" Text="Requesting Loan Amount :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtLoanAmount" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal8" runat="server" Text="Date Required :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtDateWanted" runat="server" TextMode="Date" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <% if (ddlLoanType.SelectedValue == "3")
                        { %>

                    <div class="row mb-5 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal9" runat="server" Text="Reason for Loan :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtLoanReason" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal10" runat="server" Text="Last Loan Date :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtLastLoan" runat="server" TextMode="Date" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>


                    <h4>Guarantor Details</h4>

                    <div class="table-responsive mb-5" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                        <asp:GridView Style="margin-top: 30px;" ID="gvGuarantor" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" AllowPaging="true" HeaderStyle-HorizontalAlign="center"
                            FooterStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Guarantor Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="Address" HeaderText="Guarantor Position" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="Position" HeaderText="Work place address of guarantor" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="AppointedDate" HeaderText="Appointed Date of Guarantor" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>No records</EmptyDataTemplate>

                        </asp:GridView>
                    </div>

                    <h4>If aplicant is a guarantor </h4>

                    <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                        <asp:GridView Style="margin-top: 30px;" ID="gvApplicantAsGurontor" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" AllowPaging="true" HeaderStyle-HorizontalAlign="center"
                            FooterStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                            <Columns>
                                <asp:BoundField DataField="OfficerName" HeaderText="Officer Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="Amount" HeaderText="Loan Amount" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="PeriodicalAmount" HeaderText="Periodical Amount" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="Interest" HeaderText="Interest" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>No records</EmptyDataTemplate>

                        </asp:GridView>
                    </div>
                </div>

                <%-----------------------------------------End User details-----------------------------------%>
                <div style="break-after: page"></div>
                <%---------------------------------------Fianace Department--------------------------%>

                <div class="card p-4 m-4">
                    <h3>Form For Finance Department</h3>
                    <div class="row ms-1 mb-5 mt-4">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Literal15" runat="server" Text="Last Loan Type :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="lblLastLoanType" runat="server"></asp:Label>
                                    <asp:DropDownList ID="ddlLastLoanType" runat="server" Enabled="false" CssClass="d-none"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Literal18" runat="server" Text="Last Loan Amount :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="txtLastLoanAmount" runat="server" Enabled="false"></asp:Label>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row ms-1 mb-5 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Literal19" runat="server" Text="Last Loan Date :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="txtlastLoanDate" runat="server" TextMode="Date" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="lblSlip" runat="server" Text="Salary Slip :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <a href="/SystemDocuments/SalarySlips/<%=SalarySlip%>" target="_blank">View PDF</a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row ms-1 mb-5">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Literal20" runat="server" Text="Payable Loan Amount :" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="txtPayableLoanAmount" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Literal21" runat="server" Text="Distress Loan Balance :" Font-Bold="true"> </asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="txtDistressLoanBalance" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row ms-1 mb-5">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Literal22" runat="server" Text="Premium Amount : " Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="txtPremiumAmount" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Literal23" runat="server" Text="Number of Installments :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="txtNumberOfInstallments" runat="server" TextMode="Number" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row ms-1 mb-5">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Literal24" runat="server" Text="Is Exceed 40% of Salary :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="txt40SalaryExceed" runat="server" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Literal25" runat="server" Text="Is Guarantor faithful :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="txtGuarantorFaith" runat="server" TextMode="Number" Enabled="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%---------------------------------------End Fianace Department--------------------------%>

                <div style="break-after: page"></div>

                <%---------------------------------------Data Form------------------------------------%>

                <div class="card m-4 p-4" style="padding-left: 50px; padding-top: 40px; padding-bottom: 40px;">
                    <h3>Form for Admin Department</h3>
                    <div style="height: 20px;"></div>
                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal11" runat="server" Text="Is Probation :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtIsprobation" runat="server"></asp:Label>

                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal12" runat="server" Text="Probability to permeanent after probation :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtIsPermenentAfterProbation" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal14" runat="server" Text="Is permanent :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtIsPermannet" runat="server"></asp:Label>

                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal13" runat="server" Text="Retire date :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtRetireDate" runat="server" TextMode="Date"></asp:Label>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal16" runat="server" Text="Is suspend? Details :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtIsSuspend" runat="server" TextMode="MultiLine"></asp:Label>

                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Literal17" runat="server" Text="Monthly Consolidated salary :" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="txtConsolidatedSalary" runat="server"></asp:Label>

                                </div>
                            </div>
                        </div>
                    </div>


                </div>
                <%---------------------------------------End Data Form------------------------------------%>

                <% } %>
            </div>

            <div class="m-4" runat="server">
                <asp:Button runat="server" ID="btnPrint" Text="Print Document" CssClass="btn btn-success" OnClientClick="javascript:printDiv()" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>
    </asp:UpdatePanel>

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
            setTimeout(function () { a.print(); }, 1000);
        }

    </script>
</asp:Content>

