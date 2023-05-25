﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalFilesListView.aspx.cs" Inherits="ManPowerWeb.PersonalFilesListView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="container">
                <h2>Personal Files Management -
            <asp:Label ID="lblEmpNo" runat="server"></asp:Label>
                </h2>


                <div>
                    <div class="row mt-5 pl-2 mb-2">
                        <h4><b>Personal Details</b></h4>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>File Number : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="fileNo" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="fileNo" ID="RequiredFieldValidator21" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-2">
                            <label>Full Name : </label>
                        </div>
                        <div class="col-2">
                            <asp:DropDownList ID="ddlMR" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="nameOfInitials" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="nameOfInitials" ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="10" ID="RegularExpressionValidator13" ControlToValidate="nameOfInitials" runat="server" ForeColor="Red" ValidationExpression="^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$">
									Invalid Name</asp:RegularExpressionValidator>
                        </div>

                    </div>


                    <div class="row mt-5">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Initials : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="initial" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="initial" ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Last Name : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="lname" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="lname" ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="10" ID="RegularExpressionValidator12" ControlToValidate="lname" runat="server" ForeColor="Red" ValidationExpression="^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$">
									Invalid Name</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Date of Birth : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="dob" runat="server" CssClass="form-control form-control-user" TextMode="Date" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="dob" ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <%if (dob.Text != "")
                            {
                                DateTime calcPensionDate = Convert.ToDateTime(dob.Text).AddYears(60);
                                pensionDate.Text = calcPensionDate.ToString(); %>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Pension Date : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="pensionDate" ReadOnly="true" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <%} %>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>NIC : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="nic" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="nic" ID="RequiredFieldValidator25" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="emp" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="emp" ID="RegularExpressionValidator8" ControlToValidate="nic" runat="server" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="^([0-9]{9}[x|X|v|V]|[0-9]{12})$">
							Invalid NIC</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>NIC Issued Date : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="nicIssuedDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Designation : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlEmpDesignation" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlEmpDesignation" ID="RequiredFieldValidator29" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="emp" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Marital Status : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Gender : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-5">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Passport Number : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="empPassport" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RegularExpressionValidator ValidationGroup="emp" ID="RegularExpressionValidator2" ControlToValidate="empPassport" runat="server" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="^(?!^0+$)[a-zA-Z0-9]{3,20}$">
							        Invalid Passport</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-5">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Current Working Palce :</label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlDistrict" ID="RequiredFieldValidator54" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-6" runat="server" id="DsDiv" visible="false">
                            <div class="row">
                                <div class="col-4">
                                    <label>DS Division : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlDS" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <%--<div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>ED Completion Date : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="txtEDComDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtEDComDate" ID="RequiredFieldValidator30" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>--%>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Salary Number : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="txtSalaryNum" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtSalaryNum" ID="RequiredFieldValidator32" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>W & OP Number : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="vnop" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="vnop" ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <%--  </div>


            <div class="row mt-4">--%>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Appointment letter Number : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="appointmenLetterNo" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="appointmenLetterNo" ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>



                    <div class="row justify-content-end mt-3 mr-5">
                        <div class="col-2">
                            <asp:Button runat="server" ID="btnUpdatePersonal" Text="Update" CssClass="btn btn-success btn-user btn-block" OnClick="btnUpdatePersonal_Click" ValidationGroup="10" />
                        </div>
                    </div>


                </div>

                <%--------------------------------------------------------------------------------------------------------------%>


                <div>

                    <div class="row mt-5 pl-2 mb-2">
                        <h4><b>Contact Details</b></h4>
                    </div>

                    <div class="row mt-4">

                        <div class="col-2">
                            <label>Address : </label>
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="address" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="address" ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="Contact" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>

                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Mobile Phone : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="EmpMobilePhone" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="EmpMobilePhone" ID="RequiredFieldValidator52" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="Contact" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Mobile Number."
                                        ValidationExpression="^([0-9]{10})$" ControlToValidate="EmpMobilePhone" ValidationGroup="Contact"
                                        ForeColor="Red" Display="Dynamic">Invalid Telephone Number</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Telephone (Landline): </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="telephone" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ControlToValidate="telephone" ID="RequiredFieldValidator31" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="10" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    --%><asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid Mobile Number."
                                        ValidationExpression="^([0-9]{10})$" ControlToValidate="telephone" ValidationGroup="Contact"
                                        ForeColor="Red" Display="Dynamic">Invalid Telephone Number</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Office Phone : : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="officephone" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ErrorMessage="Invalid Mobile Number."
                                        ValidationExpression="^([0-9]{10})$" ControlToValidate="officephone" ValidationGroup="Contact"
                                        ForeColor="Red" Display="Dynamic">Invalid Telephone Number</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Postal Code : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="postalCode" runat="server" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
                                    <asp:RegularExpressionValidator ValidationGroup="Contact" ID="RegularExpressionValidator9" ControlToValidate="postalCode" runat="server" ForeColor="Red" ValidationExpression="^\d+$">
                                Invalid Postal Code
                                    </asp:RegularExpressionValidator>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Personal Email : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="email" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="email" ID="RequiredFieldValidator33" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="Contact" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="Contact" ID="RegularExpressionValidator4" ControlToValidate="email" runat="server" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
							Invalid Email</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row justify-content-end mt-3 mr-5">
                        <div class="col-2">
                            <asp:Button runat="server" ID="btnUpdateContact" Text="Update" CssClass="btn btn-success btn-user btn-block" OnClick="btnUpdateContact_Click" ValidationGroup="Contact" />
                        </div>
                    </div>

                </div>



                <%--------------------------------------------------------------------------------------------------------------%>


                <div>
                    <div class="row mt-5 pl-2 mb-2">
                        <h4><b>Employee Services Details</b></h4>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-5">
                                    <label>Service Type : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlService" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-5">
                                    <label>Date of Appointment: </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="appointmentDate" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="appointmentDate" ID="RequiredFieldValidator47" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="empService" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-5">
                                    <label>Date Assumed Duty : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="dateAssumedDuty" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="dateAssumedDuty" ID="RequiredFieldValidator48" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="empService" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-5">
                                    <label>Is Confirmed : </label>
                                </div>
                                <div class="col-6">
                                    <asp:RadioButtonList ID="confirmation" runat="server" AutoPostBack="true">
                                        <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="confirmation" ValidationGroup="empService" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <%if (int.Parse(confirmation.SelectedValue) == 1)
                            { %>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-5">
                                    <label>Confirmed Date: </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="confirmedDate" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <%} %>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-5">
                                    <asp:Label ID="lblebg3" runat="server">EB Completed Date Grade 3 : </asp:Label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="txtEBDate1" runat="server" AutoPostBack="true" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%if (!string.IsNullOrEmpty(txtEBDate1.Text))
                            { %>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-5">
                                    <label>EB Completed Date Grade 2 : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="txtEBDate2" runat="server" AutoPostBack="true" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%} %>
                    </div>
                    <%if (!string.IsNullOrEmpty(txtEBDate2.Text))
                        { %>
                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-5">
                                    <label>EB Completed Date Grade 1 : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="txtEBDate3" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%} %>
                </div>


                <%--------------------------------------------------------------------------------------------------------------%>


                <div>
                    <div class="row mt-5 pl-2 mb-2">
                        <h4><b>Employee Emergency Contact Details</b></h4>
                    </div>
                    <asp:Panel ID="pnl1" runat="server">
                        <div class="row mt-5">
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-4">
                                        <label>Name : </label>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="ecName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-6">
                                <div class="row">
                                    <div class="col-4">
                                        <label>Home Telephone Number : </label>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="landLine" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Mobile Number."
                                            ValidationExpression="^([0-9]{10})$" ControlToValidate="landLine" ValidationGroup="5"
                                            ForeColor="Red" Display="Dynamic">Invalid Mobile Number</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row mt-4">
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-4">
                                        <label>Relationship To Employee : </label>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="ecRelationship" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-6">
                                <div class="row">
                                    <div class="col-4">
                                        <label>Office Phone Number : </label>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="ecOfficePhone" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Mobile Number."
                                            ValidationExpression="^([0-9]{10})$" ControlToValidate="ecOfficePhone" ValidationGroup="5"
                                            ForeColor="Red" Display="Dynamic">Invalid Mobile Number</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row mt-4">
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-4">
                                        <label>Address of Emergancy Contact Person : </label>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="ecAddress" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-6">
                                <div class="row">
                                    <div class="col-4">
                                        <label>Mobile Number : </label>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="ecMobile" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number."
                                            ValidationExpression="^([0-9]{10})$" ControlToValidate="ecMobile" ValidationGroup="5"
                                            ForeColor="Red" Display="Dynamic">Invalid Mobile Number</asp:RegularExpressionValidator>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Label ID="Empty" runat="server" Visible="false" Font-Bold="true" ForeColor="Red">No Records</asp:Label>
                </div>

                <%--------------------------------------------------------------------------------------------------------------%>


                <div>
                    <div class="row mt-5 pl-2 mb-2">
                        <h4><b>Employment History Details</b></h4>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Select Previous Work Place : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlEmpDetails" runat="server" OnSelectedIndexChanged="ddlEmpDetails_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%if (ddlEmpDetails.SelectedValue != "")
                        {  %>


                    <div class="row mt-5">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Contract Type : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddContract" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Designation : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-5">

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Start Date : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="sDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>End Date : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="eDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-5">


                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Is Resigned : </label>
                                </div>
                                <div class="col-6">
                                    <asp:RadioButtonList ID="reseg" runat="server">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-4">
                        <%if (reseg.SelectedValue == "1")
                            {  %>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Retired Date : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="retiredDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%}%>
                    </div>
                    <%} %>
                </div>

                <%--------------------------------------------------------------------------------------------------------------%>


                <div>
                    <div class="row mt-5 pl-2 mb-2">
                        <h4><b>Dependant Details</b></h4>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Select Dependant : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlDependantList" runat="server" OnSelectedIndexChanged="ddlDependantList_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%if (ddlDependantList.SelectedValue != "")
                        {  %>
                    <div class="row mt-5">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Dependant Type : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlDependant" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Relationship : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="dependantRelationship" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>First Name : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="dependantFname" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Last Name : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="dependantLname" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Date of Birth: </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="depDob" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Birth Certificate Number : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="bcNumber" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Passport Number : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="ppNumber" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Any Kind of Special Sickness : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="sickness" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>



                    <%if (ddlDependant.SelectedValue == "1")
                        { %>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Marriage Date : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="mDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Marriage Certificate Number : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="mCertificateNo" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Nic Number : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="depNic" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RegularExpressionValidator ValidationGroup="3" ID="RegularExpressionValidator10" ControlToValidate="depNic" runat="server" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="^([0-9]{9}[x|X|v|V]|[0-9]{12})$">
									Invalid NIC</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Working Company : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="workingCompany" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>City : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="city" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%} %>

                    <div id="depRowId" runat="server">
                        <div class="row mt-4">
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-4">
                                        <label>ID : </label>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="depId" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%} %>
                </div>

                <%--------------------------------------------------------------------------------------------------------------%>


                <div>
                    <div class="row mt-5 pl-2 mb-2">
                        <h4><b>Education Details</b></h4>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Select Education Type : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlEducationDetailsList" runat="server" OnSelectedIndexChanged="ddlEducation_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%if (ddlEducationDetailsList.SelectedValue != "")
                        {  %>

                    <div class="row mt-5">
                        <%-- <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Education Type : </label>
                                </div>
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlEducation" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>--%>



                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Institute / School / University : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="uni" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Index Number: </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="index" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Year : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="year" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>



                    <%if (ddlEducationDetailsList.SelectedValue == "4" || ddlEducationDetailsList.SelectedValue == "5")
                        {  %>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Attempt : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="attempt" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Subject : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="sub" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Stream : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="stream" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Grade : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="grade" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                    <%} %>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Status : </label>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox ID="status" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div id="eduRowId" runat="server">
                        <div class="row mt-4">
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-4">
                                        <label>ID : </label>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="eduId" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <div class="row">
                                <div class="col-4">
                                    <label>Uploaded File : </label>
                                </div>
                                <div class="col-6">
                                    <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control-file" Visible="false"></asp:FileUpload>
                                    <asp:Label ID="lblfileUpload" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%} %>
                </div>

                <div class="row mt-5 mb-5">
                    <div class="col-3">
                        <h4>Status - 
                <asp:Label ID="lblstatus" runat="server"></asp:Label>
                        </h4>
                    </div>
                    <div class="col-2">
                        <asp:Button ID="btnActiveInAc" runat="server" Text="Back" CssClass="btn btn-danger btn-user btn-block" OnClick="btnActiveInAc_Click" />
                    </div>
                </div>

                <div class="row mt-5 mb-5">
                    <div class="col-2">
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="btnBack_Click" />
                    </div>
                </div>

            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpdatePersonal" />
            <asp:PostBackTrigger ControlID="btnUpdateContact" />
            <asp:PostBackTrigger ControlID="btnActiveInAc" />
            <asp:PostBackTrigger ControlID="btnBack" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
