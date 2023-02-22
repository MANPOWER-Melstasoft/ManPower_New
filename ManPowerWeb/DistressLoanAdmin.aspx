<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DistressLoanAdmin.aspx.cs" Inherits="ManPowerWeb.DistressLoanAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card m-4 p-4">
        <h2>Distress Loan Admin Section</h2>
        <div class="table-responsive mt-4" style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView runat="server" ID="gvLoan" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="center"
                FooterStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                <Columns>
                    <asp:BoundField DataField="LoanDetailsId" HeaderText="Id" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="EmployeeId" HeaderText="Employee ID" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="FullName" HeaderText="Employee Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="LoanAmount" HeaderText="Loan Amount" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Date Request" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="ApprovalStatusId" HeaderText="Status" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="BtnView" CssClass="btn btn-success" OnClick="BtnView_Click">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>No records</EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>

    <div class="card m-4 p-4">

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal5" runat="server" Text="Loan Detail Id"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtLoandetailId" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal9" runat="server" Text="Is Probation"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtIsprobation" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal10" runat="server" Text="Is permeanent after probation"></asp:Literal>
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
                        <asp:Literal ID="Literal11" runat="server" Text="Retire date"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtRetireDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>


        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal12" runat="server" Text="Is permanent"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtIsPermannet" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal6" runat="server" Text="Permanent From"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtPermanentDaterom" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal14" runat="server" Text="Is suspend"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtIsSuspend" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal13" runat="server" Text="Monthly Consolidated salary"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtConsolidatedSalary" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>


        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal1" runat="server" Text="Is gurontor for a loan"></asp:Literal>

                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtIsGurantor" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal2" runat="server" Text="Last Loan Date"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtLastLoanDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>


        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal3" runat="server" Text="Last Loan Type"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtLastLoanType" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal4" runat="server" Text="Last Loan Amount"></asp:Literal>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox ID="txtLastLoanAmount" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-3">
                <div class="row mb-3 ms-1">
                    <div class="col">
                        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnApprove_Click" />
                    </div>
                    <div class="col">
                        <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" data-toggle="modal" data-target="#exampleModalCenter" />
                    </div>
                </div>
            </div>
        </div>


    </div>
    <%---------------------dialog box----------------------%>

    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Reject Loan By Finance</h5>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="txtrejectReason" ValidationGroup="3" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </center>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnRejectReason" Text="Reject" OnClick="btnRejectReason_Click" CssClass="btn btn-danger" Width="100px" ValidationGroup="3" />
                </div>
            </div>
        </div>
    </div>

    <%--------------end of dialog box--------------------%>
</asp:Content>
