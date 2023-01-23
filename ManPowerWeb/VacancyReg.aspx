<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VacancyReg.aspx.cs" Inherits="ManPowerWeb.VacancyReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4 ml-4">
            <h2>Company / Vacancy Registration Details</h2>



            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Name </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="txtName" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtName" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>



                <div class="col-6">
                    <div class="row ">
                        <div class="col-4">
                            <asp:Literal ID="Literal2" runat="server" Text="Address"></asp:Literal>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="address" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="address" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                        </div>
                    </div>

                </div>
            </div>

            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Website Link </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="link" runat="server" name="place" CssClass="form-control form-control-user" TextMode="Url"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Business Registration Number</label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="regNo" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="regNo" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
            </div>



            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Vacancy Type / Job Position</label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="vanacnyType" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="vanacnyType" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Carrer Path / Achived Highest Position </label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddlPositions" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlPositions" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
            </div>


            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Level</label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddlLevel" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlLevel" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Salary Level</label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="salary" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="salary" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
            </div>

            <div class="row pl-3 mt-5 ">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Number of Vacancies  </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="NoOfVacancy" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="NoOfVacancy" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row ">
                        <div class="col-4">
                            <asp:Literal ID="Literal1" runat="server" Text="Date"></asp:Literal>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="date" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="date" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="row pl-3 mt-5">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>District</label>
                                </div>
                                <div class="col-6">
                                    <asp:RadioButtonList ID="rbDepartmentLocationType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbDepartmentLocationType_SelectedIndexChanged">
                                        <asp:ListItem Value="1">District Level</asp:ListItem>
                                        <asp:ListItem Value="2">DS Division Level</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="rbDepartmentLocationType" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row pl-3  mb-5">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>District</label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlDistrict" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>DS Division </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlDsDivision" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                    <%if (rbDepartmentLocationType.SelectedValue == "2")
                                        { %>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddlDsDivision" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <%} %>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <h4><b>Contact Person Details</b></h4>


            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Name </label>
                        </div>
                        <div class="col-6">

                            <asp:TextBox ID="name" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="name" runat="server" ValidationGroup="1" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Position  </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="position" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Contact Number</label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="contact" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Whatsapp Number</label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="whatsapp" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Email</label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="email" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-2">
                            <asp:Button runat="server" ID="Button3" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" />
                        </div>
                        <div class="col-2">
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click" ValidationGroup="1" />
                        </div>
                        <div class="col-2">
                            <asp:Button runat="server" ID="Button1" Text="Clear" CssClass="btn btn-primary btn-user btn-block" OnClick="btnClear_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
