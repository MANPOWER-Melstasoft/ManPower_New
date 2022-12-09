<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME37.aspx.cs" Inherits="ManPowerWeb.DME37" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="card ml-4 p-4 mb-4">
            <h2>DME 37</h2>
            <div class="card-body">
                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Date">Date</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="txtDate" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal1">Address</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtAddress" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal2">WebSite Link</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">

                            <asp:TextBox ID="txtWebSite" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtWebSite" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtWebSite" ErrorMessage="Invalid Website Link" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal3">Business Registation Number</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="txtRegNo" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtRegNo" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal4">Vacancy Type / JobPosition</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="txtVacancyType" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtVacancyType" ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal5">Career Path/Achived Hightest Position</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:DropDownList runat="server" CssClass="btn btn-primary dropdown-toggle" ID="ddlCareerPath">
                                <asp:ListItem>Mangement</asp:ListItem>
                                <asp:ListItem>Skilled</asp:ListItem>
                                <asp:ListItem>Non-Skilled</asp:ListItem>
                                <asp:ListItem>Technical</asp:ListItem>
                                <asp:ListItem>Non-Technical</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal6">Level</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:DropDownList ID="ddlLevel" CssClass="btn btn-primary dropdown-toggle" runat="server">
                                <asp:ListItem>Top Level</asp:ListItem>
                                <asp:ListItem>Middle Level</asp:ListItem>
                                <asp:ListItem>Lower Level</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal7">Salary Level</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="txtSalaryLevel" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtSalaryLevel" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>



                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal9">Number Of Vacancies</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">

                            <asp:TextBox ID="txtNumberOfVacancies" TextMode="Number" min="0" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtNumberOfVacancies" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>




                <%--contact person details--%>

                <h5><b>Contact Person Details</b></h5>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal10">Name</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtName" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal11">Position</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtPosition" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal12">Contact Number</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control form-control-user" placeholder="EX: 07XX XXX XXX"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtContact" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Mobile Number."
                                ValidationExpression="^([0-9]{10})$" ControlToValidate="txtContact" ValidationGroup="1"
                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal13">Whatsapp Number</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="txtWhatsapp" runat="server" CssClass="form-control form-control-user" placeholder="EX: 07XX XXX XXX"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtWhatsapp" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number."
                                ValidationExpression="^([0-9]{10})$" ControlToValidate="txtWhatsapp" ValidationGroup="1"
                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Literal runat="server" ID="Literal14">Email</asp:Literal>

                        </div>
                        <div class="form-group col-md-3">

                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtEmail" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtEmail" runat="server" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="form-row">
                        <div class="form-group col-md-2">
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="btnBack_Click" />


                        </div>
                        <div class="form-group col-md-2">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary btn-user btn-block" OnClick="btnAdd_Click" ValidationGroup="1" />

                        </div>
                    </div>
                </div>
            </div>
        </div>




    </div>


</asp:Content>
