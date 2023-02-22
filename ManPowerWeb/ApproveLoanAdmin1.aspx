<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveLoanAdmin1.aspx.cs" Inherits="ManPowerWeb.ApproveLoanAdmin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card-body">

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="lblName" runat="server" Text="Loan Type"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal1" runat="server" Text="Full Name"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal2" runat="server" Text="Position"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal4" runat="server" Text="Position Type"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtPositionType" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal3" runat="server" Text="Work Place"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtWorkPlace" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal5" runat="server" Text="Appointment Date"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtAppointmentDate" runat="server" CssClass="form-control form-control-user" TextMode="Date" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal6" runat="server" Text="Basic Salary"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal7" runat="server" Text="Requesting Loan Amount"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal8" runat="server" Text="Date Required"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtDateWanted" runat="server" CssClass="form-control form-control-user" TextMode="Date" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <% if (ddlLoanType.SelectedValue == "3")
            { %>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal9" runat="server" Text="Reason for Loan"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtLoanReason" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal10" runat="server" Text="Last Loan Date"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtLastLoan" runat="server" CssClass="form-control form-control-user" TextMode="Date" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>


        <h4>Guarantor Details</h4>

        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
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

        <%---------------------------------------Data Form------------------------------------%>

        <div class="card" style="padding-left: 50px; padding-top: 40px; padding-bottom: 40px;">
            <h2>Form for Admin Department</h2>
            <div style="height: 20px;"></div>
            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal11" runat="server" Text="Is Probation"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtIsprobation" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                                ControlToValidate="txtIsprobation" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal12" runat="server" Text="Probability to permeanent after probation"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtIsPermenentAfterProbation" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal14" runat="server" Text="Is permanent"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtIsPermannet" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                ControlToValidate="txtIsPermannet" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal13" runat="server" Text="Retire date"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtRetireDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                ControlToValidate="txtRetireDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal16" runat="server" Text="Is suspend? Details"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtIsSuspend" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="1"
                                ControlToValidate="txtIsSuspend" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal17" runat="server" Text="Monthly Consolidated salary"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtConsolidatedSalary" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                                ControlToValidate="txtConsolidatedSalary" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-2">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-outline-primary" Style="width: 150px;" ValidationGroup="1" OnClick="btnSubmit_Click" />
            </div>
        </div>
        <%---------------------------------------End Data Form------------------------------------%>

        <% } %>


        <div class="row mb-3 ms-1 mt-4">
            <div class="col-2">
                <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-outline-success" Style="width: 150px;" OnClick="btnApprove_Click" />
            </div>
            <div class="col-2">
                <button runat="server" id="btnModalReject" type="button" class="btn btn-outline-danger" style="width: 150px;" data-toggle="modal" data-target="#exampleModalCenter" visible="true">Reject</button>
            </div>
        </div>

        <%---------------------dialog box----------------------%>

        <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Reject Loan</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <center>
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-4">
                                    <label>Reason to reject </label>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtrejectReason" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </center>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-outline-danger" Style="width: 150px;" OnClick="btnReject_Click" />
                    </div>
                </div>
            </div>
        </div>


        <%--------------end of dialog box--------------------%>
    </div>
</asp:Content>
