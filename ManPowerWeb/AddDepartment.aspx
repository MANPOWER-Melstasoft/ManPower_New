<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="ManPowerWeb.AddDepartmentUnit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card o-hidden border-0 shadow-lg my-3">
        <div class="card-header d-flex align-items-center justify-content-center" style="height: 5%">
            <h5 class="text-center  mt-3 mb-3">Add District/DS Division</h5>
        </div>

        <div class="card-body">
            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">

                    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>

                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblDepartment" runat="server" Text="Select Department"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" CssClass="btn btn-outline-dark dropdown-toggle form-control"
                                OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                            </asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlDepartment" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <%if (ddlDepartment.SelectedItem.Value == "2")
                        {%>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblDistrict" runat="server" Text="District"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDistrict" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtDistrict" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <%
                        } %>

                    <%if (ddlDepartment.SelectedItem.Value == "3")
                        {%>

                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblDistrict2" runat="server" Text="District"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlDistrict" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblDsDivision" runat="server" Text="DS Division"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDsDivision" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtDsDivision" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <%
                        } %>

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
                            <asp:Literal ID="lblFax" runat="server" Text="FAX"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtFax" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtFax" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="PhoneNumber is not  valid"
                                    ControlToValidate="txtContactNumber" ValidationExpression="[0-9]{10}" ValidationGroup="1">
                                </asp:RegularExpressionValidator>--%>
                            </div>
                        </div>
                    </div>

                </div>

                <%-------------------------------------------------------------------------------------------------------------------------------------------------%>

                <div class="col-sm-6">

                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblAddLine1" runat="server" Text="Address Line 01"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtAddLine1" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtAddLine1" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblAddLine2" runat="server" Text="Address Line 02"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtAddLine2" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtAddLine2" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblAddLine3" runat="server" Text="Address Line 03"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtAddLine3" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtAddLine3" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


            <div class="row mb-3 ms-1">
                <div class="col-sm-3">
                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">
                            <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="btn btn-primary btn-user btn-block" ValidationGroup="1" OnClick="btnCreate_Click" />
                        </div>
                        <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529" OnClick="btnReset_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 m-3">
                <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
                <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>

        </div>
    </div>

</asp:Content>
