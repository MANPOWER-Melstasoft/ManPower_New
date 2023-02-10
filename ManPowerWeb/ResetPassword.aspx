<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="ManPowerWeb.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="card o-hidden border-0 shadow-lg my-3">
        <div class="card-header d-flex align-items-center justify-content-center" style="height: 5%">
            <h5 class="text-center  mt-3 mb-3">Password Reset</h5>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="card-body">
                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">

                            <div class="row mb-3">
                                <div class="col-sm-6">
                                    <asp:Literal ID="lblUser" runat="server" Text="Select User"></asp:Literal>
                                </div>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlUser" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row mb-5">
                                <div class="col-sm-6">
                                    <asp:Literal ID="ltlUserType" runat="server" Text="Current User Type"></asp:Literal>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblUserType" runat="server" Text="" CssClass="form-control form-control-user"></asp:Label>
                                </div>
                            </div>


                            <div class="row mb-3">
                                <div class="col-sm-6">
                                    <label>Enter New Password : </label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtNewPasword" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="resetPass"
                                            ControlToValidate="txtNewPasword" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-3">
                                <div class="col-sm-6">
                                    <label>Re-Enter New Password : </label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtReNewPasword" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="resetPass"
                                            ControlToValidate="txtReNewPasword" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                        <asp:Label ID="lblMisMatchPwd" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="row mt-5 mb-4">
                                <div class="col-2">
                                    <asp:Button runat="server" ID="btnResetPassword" Text="Reset" ValidationGroup="resetPass" Autopostback="true" OnClick="btnResetPassword_Click" CssClass="btn btn-primary btn-user btn-block" />
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnResetPassword" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

</asp:Content>
