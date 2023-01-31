<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTransfersRetirementResignation.aspx.cs" Inherits="ManPowerWeb.AddTransfersRetirementResignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mb-3" id="mainContainer" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <div class="card ml-4 p-4">
            <h2>Add New Transfers / Retirement / Resignation</h2>
            <br />
            <div class="form-group">

                <div class="row mb-3 ms-1 mt-4">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal1" runat="server" Text="Emp Number : "></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblEmpNumber" runat="server" Text="N/A" Width="250px"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal2" runat="server" Text="Emp Name : "></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblEmpName" runat="server" Text="N/A" Width="250px"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-3 ms-1 mt-4">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal3" runat="server" Text="Department : "></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblDepartment" runat="server" Text="N/A" Width="250px"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal4" runat="server" Text="Designation : "></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblDesignation" runat="server" Text="N/A" Width="250px"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">

                                        <asp:Literal ID="Literal17" runat="server" Text="Request Type : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddlRequestType" runat="server" Width="250px" CssClass="form-control form-control-user" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="1" ControlToValidate="ddlRequestType" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <%----------------------------------transferDiv------------------------------------------%>

                        <div runat="server" id="transferDiv">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal5" runat="server" Text="Transfer Type : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlTransferType" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="1" ControlToValidate="ddlTransferType" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="lblDepartmentType" runat="server" Text="New Department : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlDepartment" Width="250px" runat="server" CssClass="form-control form-control-user">
                                            </asp:DropDownList>
                                            <div class="d-flex text-danger">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                                                    ControlToValidate="ddlDepartment" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal6" runat="server" Text="Reason : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtReason" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%----------------------------------retirementDiv------------------------------------------%>

                        <div runat="server" id="retirementDiv" visible="true">
                            <div class="row mb-3">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal19" runat="server" Text="Joined Date : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtJoinedDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="1" ControlToValidate="txtJoinedDate" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">

                                            <asp:Literal ID="Literal20" runat="server" Text="DOB : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtDob" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal7" runat="server" Text="Retirement Type : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlRetirementType" runat="server" CssClass="form-control form-control-user" Width="250px" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlRetirementType" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <%if (ddlRetirementType.SelectedItem.Text == "Other")
                                    { %>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal9" runat="server" Text="Other : "></asp:Literal>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtRetirementOther" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <%} %>
                            </div>


                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal12" runat="server" Text="Reason : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtRetirementReason" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal13" runat="server" Text="Remark : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtRetirementRemark" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%----------------------------------resignationDiv------------------------------------------%>

                        <div runat="server" id="resignationDiv" visible="false">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">

                                            <asp:Literal ID="Literal8" runat="server" Text="Date : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtResignationDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtResignationDate" ForeColor="Red">*</asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">

                                            <asp:Literal ID="Literal10" runat="server" Text="Reason : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtResignationReason" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="1" ControlToValidate="txtResignationReason" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="row mb-5">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal11" runat="server" Text="Upload Documnents"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:FileUpload ID="Uploader" CssClass="btn" runat="server" AllowMultiple="false" />

                            </div>
                        </div>
                    </div>
                </div>


                <div class="row mb-3 ms-1">
                    <div class="col-sm-6 d-flex">
                        <div class="col-sm-4">
                            <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="btnBack_Click" />
                        </div>
                        <div class="col-sm-4">
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click" ValidateRequestMode="Enabled" ValidationGroup="1" />
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
