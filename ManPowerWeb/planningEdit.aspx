<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="planningEdit.aspx.cs" Inherits="ManPowerWeb.planningEdit" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container"></div>
    <div class="card ml-4 p-4">
        <h2><b>Edit Program Plan</b></h2>
        <div class="mt-3">
            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal3" runat="server" Text="Program Name"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtProgramName" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtProgramName" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>


                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal4" runat="server" Text="Manager"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtManger" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>


                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>



            </div>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal1" runat="server" Text="Date "></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtDate" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <asp:Label runat="server" ID="lblDate" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDate" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal2" runat="server" Text="Location"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtLocation" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLocation" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>


                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>



            </div>


            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal10" runat="server" Text="Estimate Amount"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtEstimateAmount" CssClass="form-control form-control-user" TextMode="Number" Enabled="false"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal5" runat="server" Text="Budget"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtBudget" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>
                            <asp:Label runat="server" ID="lblBudget" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtBudget" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>


            </div>

            <h5><b>Count</b></h5>


            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal6" runat="server" Text="Male Count"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtMaleCount" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtMaleCount" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal7" runat="server" Text="Female Count"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtFemaleCount" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFemaleCount" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>


            </div>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal8" runat="server" Text="Resource Person"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlResourcePerson" CssClass="form-control form-control-user"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal9" runat="server" Text="Upload Documnents"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:FileUpload ID="Uploader" CssClass="btn" runat="server" AllowMultiple="true" />
                            <asp:Label ID="lblListOfUploadedFiles" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click1" ValidationGroup="1" />
                            <asp:Button runat="server" ID="btnComplete" Text="Complete" CssClass="btn btn-success" OnClick="btnComplete_Click" />

                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
