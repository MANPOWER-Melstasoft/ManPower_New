<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndividualBeneList.aspx.cs" EnableEventValidation="false" Inherits="ManPowerWeb.IndividualBeneList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>

    <div class="container">
        <div class="card p-4">
            <h2>Individual Beneficiaries List</h2>

            <div class="row mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-3">
                            <label>Date of birth : </label>
                        </div>
                        <div class="col-6 ">
                            <asp:TextBox ID="dob" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>School / Non-School : </label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddlScl" runat="server" AutoPostBack="true" CssClass="form-control form-control-user"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-6">
                    <div class="row">
                        <div class="col-3">
                            <label>Gender : </label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddlGen" runat="server" AutoPostBack="true" CssClass="form-control form-control-user"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4 p-2">
                <asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" AutoPostBack="true" CssClass="btn btn-primary" />
            </div>

            <button runat="server" id="btnRun" onserverclick="btnExportExcel_Click" class="btn btn-success col-3 mt-3" title="Export To Excel">
                <i class="fa fa-file-export" style="margin-right: 10px"></i>Export To Excel
            </button>

            <div class="table-responsive mt-5 mb-4">
                <asp:Label ID="lblMSG" runat="server" Text="" CssClass="ml-2"></asp:Label>
                <asp:Table ID="tblBene" runat="server" CssClass="table table-bordered"></asp:Table>
            </div>

            <div class="table-responsive mt-5" style="width: 100%;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None">
                    <%--AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10"--%>
                    <%--<Columns>
                        <asp:BoundField HeaderText="Id" DataField="BenificiaryId" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Name" DataField="InduvidualBeneficiaryName" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="NIC" DataField="BeneficiaryNic" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Gender" DataField="BeneficiaryGender" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Date Of Birth" DataField="DateOfBirth" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:BoundField HeaderText="Address" DataField="PersonalAddress" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Email" DataField="BeneficiaryEmail" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Job Preference" DataField="JobPreference" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Contact Number" DataField="ContactNumber" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Whatsapp Number" DataField="WhatsappNumber" HeaderStyle-CssClass="table-dark" />
                        <asp:TemplateField HeaderText="Is School Student" HeaderStyle-CssClass="table-dark">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("IsSchoolStudent").ToString() == "1" ?true:false %>' Text="Yes"></asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsSchoolStudent").ToString() == "0" ?true:false %>' Text="No"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="School Name" DataField="SchoolName" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:BoundField HeaderText="School Address" DataField="AddressOfSchool" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="School Grade" DataField="SchoolGrade" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Parent NIC" DataField="ParentNic" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Created User" DataField="systemCreatedUser.Name" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                    </Columns>--%>

                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="BenificiaryId" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Name" DataField="InduvidualBeneficiaryName" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="NIC" DataField="BeneficiaryNic" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Gender" DataField="BeneficiaryGender" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Date Of Birth" DataField="DateOfBirth" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:BoundField HeaderText="Address" DataField="PersonalAddress" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Email" DataField="BeneficiaryEmail" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Job Preference" DataField="JobPreference" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Contact Number" DataField="ContactNumber" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Whatsapp Number" DataField="WhatsappNumber" HeaderStyle-CssClass="table-dark" />
                        <asp:TemplateField HeaderText="Is School Student" HeaderStyle-CssClass="table-dark">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("IsSchoolStudent").ToString() == "1" ?true:false %>' Text="Yes"></asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsSchoolStudent").ToString() == "0" ?true:false %>' Text="No"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="School Name" DataField="SchoolName" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="School Address" DataField="AddressOfSchool" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="School Grade" DataField="SchoolGrade" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Parent NIC" DataField="ParentNic" HeaderStyle-CssClass="table-dark" />

                        <asp:BoundField HeaderText="CareerKeyTestId" DataField="CareerKeyTestId" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="R" DataField="R" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="I" DataField="I" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="A" DataField="A" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="S" DataField="S" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="E" DataField="E" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="C" DataField="C" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="ProvidedGuidance" DataField="ProvidedGuidance" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="CareerKeyTestHeldDate" DataField="CareerKeyTestHeldDate" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:BoundField HeaderText="CareerKeyTestProgramPlan" DataField="CareerKeyTestProgramPlan" HeaderStyle-CssClass="table-dark" />

                        <asp:BoundField HeaderText="TrainingRefferalsId" DataField="TrainingRefferalsId" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="InstituteName" DataField="InstituteName" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="TrainingCourse" DataField="TrainingCourse" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="ContactPerson" DataField="ContactPerson" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="TrainingRefferalsDate" DataField="TrainingRefferalsDate" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:BoundField HeaderText="TrainingRefferalsProgramPlan" DataField="E" HeaderStyle-CssClass="table-dark" />


                        <asp:BoundField HeaderText="JobRefferalsId" DataField="JobRefferalsId" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="CompanyName" DataField="CompanyName" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="CareerPath" DataField="CareerPath" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="JobPosition" DataField="JobPosition" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="CareerGuidance" DataField="CareerGuidance" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Remarks" DataField="Remarks" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="JobRefferalsDate" DataField="JobRefferalsDate" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:BoundField HeaderText="JobPlacementDate" DataField="JobPlacementDate" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:BoundField HeaderText="JobRefferalsProgramPlan" DataField="JobRefferalsProgramPlan" HeaderStyle-CssClass="table-dark" />

                    </Columns>

                </asp:GridView>
            </div>

        </div>
    </div>

</asp:Content>
