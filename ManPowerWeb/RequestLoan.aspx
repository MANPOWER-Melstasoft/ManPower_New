<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestLoan.aspx.cs" Inherits="ManPowerWeb.RequestLoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="Scriptmanger1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="Updatepanel" runat="server">
        <ContentTemplate>
            <div class="card o-hidden border-0 shadow-lg my-3 p-4">

                <h2>Request Loan</h2>

                <div class="card-body">

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="lblName" runat="server" Text="Loan Type"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="form-control form-control-user"></asp:DropDownList>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                                            ControlToValidate="ddlLoanType" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
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
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal2" runat="server" Text="Position"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtPosition" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
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
                                    <asp:TextBox ID="txtPositionType" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtPositionType" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal3" runat="server" Text="Work Place"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtWorkPlace" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtWorkPlace" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
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
                                    <asp:TextBox ID="txtAppointmentDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtAppointmentDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
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
                                    <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtBasicSalary" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal7" runat="server" Text="Requesting Loan Amount"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtLoanAmount" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
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
                                    <asp:TextBox ID="txtDateWanted" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtDateWanted" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1">
                        <div class="col-sm-3">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Send to Admin" CssClass="btn btn-primary" ValidationGroup="1" OnClick="btnSubmit_Click" />
                                </div>
                                <%--  <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529"  />
                        </div>--%>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 m-3">
                        <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
