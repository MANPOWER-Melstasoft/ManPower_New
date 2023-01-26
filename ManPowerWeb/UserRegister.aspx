<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="ManPowerWeb.UserRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="card o-hidden border-0 shadow-lg my-3">
        <div class="card-header d-flex align-items-center justify-content-center" style="height: 5%">
            <h5 class="text-center  mt-3 mb-3">Register User</h5>
        </div>
        <div class="card-body">
            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblName" runat="server" Text="Name"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlUserName" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlUserName_SelectedIndexChanged">
                            </asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlUserName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblUserName" runat="server" Text="User Name"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtUserName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblErrorUser" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblEmail" runat="server" Text="Email"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtEmail" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ControlToValidate="txtEmail" ErrorMessage="Invalid email address"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="1">Email is not valid</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
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

                <%-------------------------------------------------------------------------------------------------------------------------------------------------%>

                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblDesignation" runat="server" Text="Designation"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlDesignation" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblUserType" runat="server" Text="User Type"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlUserType" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlUserType" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblPosition" runat="server" Text="Position"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlPosition" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlPosition" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblDepartmentType" runat="server" Text="Department Type"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlDepartmentType" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control" Enabled="false">
                            </asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlDepartmentType" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblDepartmentUnit" runat="server" Text="District / DS Division"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlDepartmentUnit" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control" Enabled="false"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlDepartmentUnit" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblEmpNumber" runat="server" Text="Emp Number"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtEmpNumber" runat="server" CssClass="form-control form-control-user" TextMode="Number" Enabled="false"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtEmpNumber" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblEmpNumError" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


            <div class="row mb-3 ms-1">
                <div class="col-sm-3">
                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">
                            <asp:Button ID="btnRegister" runat="server" Text="Create User" CssClass="btn btn-primary btn-user btn-block" ValidationGroup="1" OnClick="btnRegister_Click" />
                        </div>
                        <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529" OnClick="btnReset_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 m-3">
                <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
            </div>
            <div class="col-sm-6 m-3">
                <asp:Label ID="lblManagerError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>

        </div>
    </div>

</asp:Content>
