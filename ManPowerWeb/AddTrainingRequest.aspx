<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTrainingRequest.aspx.cs" Inherits="ManPowerWeb.AddTrainingRequest" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Training Request</h2>
        <div class="card-body">
            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblDate" runat="server" Text="Date :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <input id="txtDate" runat="server" cssclass="form-control form-control-user" type="date" style="width: 100%; height: 40px; border-radius: 5px; padding-left: 10px;"></input>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblEmployNo" runat="server" Text="Employee Number :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlEmployNo" runat="server" CssClass="form-control form-control-user"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="Literal1" runat="server" Text="Training Category :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlTrainingCategory" runat="server" CssClass="form-control form-control-user"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblContact" runat="server" Text="Contact Number"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtContactNumber" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="PhoneNumber is not  valid"
                                    ControlToValidate="txtContactNumber" ValidationExpression="[0-9]{10}" ValidationGroup="1">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblPassword" runat="server" Text="Password"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-user" TextMode="Password"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtPassword" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control form-control-user" TextMode="Password"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtConfirmPassword" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblErrorPassword" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
