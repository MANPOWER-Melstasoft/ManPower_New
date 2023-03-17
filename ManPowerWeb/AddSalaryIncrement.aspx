<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSalaryIncrement.aspx.cs" Inherits="ManPowerWeb.AddSalaryIncrement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">INCREMENT CERTIFICATE FORM</h2>
        <div class="row mb-5" style="margin-left: 100px;">
            <asp:Label ID="Label1" runat="server" Text="I here by certify that the under mentioned officers/employees
                borne on the establishment of the has/have discharged his/their duties satisfactory and earned the increment-noted 
                against his/their respectivenames"></asp:Label>
        </div>
        <div class="card-body">
            <div class="row mb-3 ms-1 mt-3" style="margin-left: 70px;">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="lblName" runat="server" Text="Employee"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control form-control-user" DataTextField="LastName" DataValueField="EmployeeId"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlEmployee" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal1" runat="server" Text="Basic Salary"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtSalary" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mb-3 ms-1 mt-3" style="margin-left: 70px;">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal2" runat="server" Text="Allowances"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtAllowances" runat="server" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtAllowances" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal3" runat="server" Text="Total Salary"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtToal" runat="server" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtToal" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mb-5" style="margin-left: 100px;">
            <div class="col-sm-3">
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-secondary btn-user btn-block" ValidationGroup="1" OnClick="btnSave_Click">Save and Send to Fianance</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
