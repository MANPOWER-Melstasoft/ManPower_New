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

        <div class="row mb-3 ms-1">
            <div class="col-sm-3">
                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <asp:Button ID="btnSubmit" runat="server" Text="Send to Admin" CssClass="btn btn-primary" ValidationGroup="1" />
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
