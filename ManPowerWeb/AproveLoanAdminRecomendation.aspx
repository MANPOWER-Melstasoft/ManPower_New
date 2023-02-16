<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AproveLoanAdminRecomendation.aspx.cs" Inherits="ManPowerWeb.AproveLoanAdminRecomendation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card p-4 m-4">
        <h2>Loan Admin Recommendation</h2>
        <asp:GridView runat="server">
            <Columns>
                <asp:BoundField HeaderText="Id" />
                <asp:BoundField HeaderText="Employee Name" />
                <asp:BoundField HeaderText="Date Request" />
                <asp:BoundField HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="BtnView">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="card m-4  p-4">

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
                            <asp:Literal ID="Literal7" runat="server" Text="Appeal Amount"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtAppealAmount" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>

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
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtDateWanted" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row mb-3 ms-1 mt-4">
                <div class="col-sm-3">
                    <div class="row mb-3 ms-1">
                        <div class="col-4">
                            <asp:Button ID="btnApproval" runat="server" Text="Approve" CssClass="btn btn-primary" />
                        </div>

                        <div class="col-4">
                            <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
