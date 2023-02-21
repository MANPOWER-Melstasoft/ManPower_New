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

        <% } %>

        <div class="row mb-3 ms-1 mt-4">
            <div class="col-2">
                <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-outline-success" Style="width: 150px;" OnClick="btnApprove_Click" />
            </div>
            <div class="col-2">
                <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-outline-danger" Style="width: 150px;" OnClick="btnReject_Click" />
            </div>
        </div>


    </div>
</asp:Content>
