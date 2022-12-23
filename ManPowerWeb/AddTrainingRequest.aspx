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
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
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
                            <asp:DropDownList ID="ddlTrainingCategory" runat="server" CssClass="form-control form-control-user">
                                <asp:ListItem Text="Foreign" Value="1" />
                                <asp:ListItem Text="Local" Value="0" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="Literal2" runat="server" Text="Upload University Application :"></asp:Literal>
                        </div>
                        <div class="col-md-6" style="text-align: center">
                            <asp:LinkButton ID="btnUpload" runat="server" CssClass="form-control form-control-user">Upload Document</asp:LinkButton>
                        </div>
                    </div>
                    <div class="row mb-3" style="padding-top: 20px;">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Button ID="btnSave" runat="server" Text="Submit to Approval" CssClass="btn btn-secondary btn-user " BackColor="#51E567 " BorderColor="#51E567" Style="width: 200px;" OnClick="btnSave_Click" />
                        </div>
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-secondary btn-user " BackColor="#565656" BorderColor="#565656" Style="width: 200px;" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblProgram" runat="server" Text="Program :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control form-control-user"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlProgram" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblInstitute" runat="server" Text="Institute :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtInstitute" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtInstitute" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblContent" runat="server" Text="Content :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtContent" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtContent" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
