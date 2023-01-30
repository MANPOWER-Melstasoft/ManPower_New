<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpecialProgram.aspx.cs" Inherits="ManPowerWeb.SpecialProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container"></div>
    <div class="card ml-4 p-4">
        <h2><b>Add Special Program</b></h2>
        <div class="mt-5">

            <div class="row mb-3 ms-1">

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">

                            <asp:Literal ID="Literal1" runat="server" Text="Date :"></asp:Literal>
                        </div>
                        <div class="col-6">
                            <asp:TextBox runat="server" ID="txtDate" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <asp:Label runat="server" ID="lblDate" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDate" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">

                            <asp:Literal ID="Literal2" runat="server" Text="Location :"></asp:Literal>
                        </div>
                        <div class="col-6">
                            <asp:TextBox runat="server" ID="txtLocation" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLocation" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>


                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>

            </div>

            <div class="row mb-3 ms-1">

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">

                            <asp:Literal ID="Literal6" runat="server" Text="Description :"></asp:Literal>
                        </div>
                        <div class="col-6">
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDescription" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Button runat="server" ID="btnSave" Text="Save Speicial Program" CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="1" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
