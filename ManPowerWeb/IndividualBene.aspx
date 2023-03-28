<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndividualBene.aspx.cs" Inherits="ManPowerWeb.IndividualBene" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4">
            <h2>Individual Beneficiary Registration</h2>

            <div class="row mt-5 pl-3">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>NIC :</label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="nic" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="nic" ID="RequiredFieldValidator15" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="1" ID="RegularExpressionValidator3" ControlToValidate="nic" runat="server" ErrorMessage="Invalid NIC" ForeColor="Red" ValidationExpression="^([0-9]{9}[x|X|v|V]|[0-9]{12})$">
							Invalid NIC</asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Name : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="name" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="name" ID="RequiredFieldValidator16" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row mt-4 pl-3">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Gender : </label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddl1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Date of Birth : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="dob" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="dob" ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row mt-4 pl-3">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Personal Address : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="address" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="address" ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Email : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="email" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="address" ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="email" runat="server" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
					    Invalid Email</asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>



            <div class="row mt-4 pl-3">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Job Preference : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="jobType" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="jobType" ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Contact Number : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="contact" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="contact" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number."
                                ValidationExpression="^([0-9]{10})$" ControlToValidate="contact" ValidationGroup="1"
                                ForeColor="Red" Display="Dynamic">Invalid Mobile Number</asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4 pl-3">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Whatsapp Number : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="whatsapp" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="whatsapp" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Mobile Number."
                                ValidationExpression="^([0-9]{10})$" ControlToValidate="whatsapp" ValidationGroup="1"
                                ForeColor="Red" Display="Dynamic">Invalid Mobile Number</asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>School / Non School : </label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddl2" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddl2" ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

            <%if (ddl2.Text == "School")
                { %>

            <div class="row mt-4 pl-3">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Name of the School : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="sclName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="sclName" ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Address of the School : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="sclAddress" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="sclAddress" ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4 pl-3">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Grade : </label>
                        </div>
                        <div class="col-6">

                            <asp:TextBox ID="grade" runat="server" CssClass="form-control form-control-user" AutoPostBack="true" OnTextChanged="grade_TextChanged" TextMode="Number"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="grade" runat="server" ErrorMessage="Invalid" MinimumValue="1" MaximumValue="13" Type="Integer" ForeColor="Red" ValidationGroup="1"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ControlToValidate="grade" ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Parent NIC : </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="parentNic" runat="server" CssClass="form-control form-control-user"></asp:TextBox>


                            <asp:RequiredFieldValidator ControlToValidate="parentNic" ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

            </div>

            <%} %>

            <div class="row mt-4 pl-3">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>From Program : </label>
                        </div>
                        <div class="col-6">
                            <asp:RadioButtonList ID="confirmation" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="confirmation" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <%if (confirmation.SelectedValue == "1")
                    { %>
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Select Program Plane : </label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddlPlan" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddlPlan" ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <%} %>
            </div>


            <div class="row mt-5">
                <div class="col-2">
                    <asp:Button runat="server" ID="Button2" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" BackColor="#212529" BorderColor="#212529" />
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

</asp:Content>
