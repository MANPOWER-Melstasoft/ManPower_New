<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTraining.aspx.cs" Inherits="ManPowerWeb.AddTrainingRequest" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Add Training</h2>
        <div class="card-body">
            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblStartDate" runat="server" Text="Start Date :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <input id="txtStartDate" runat="server" cssclass="form-control form-control-user" type="date" style="width: 100%; height: 40px; border-radius: 5px; padding-left: 10px;"></input>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtStartDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblTitle" runat="server" Text="Title :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtTitle" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="Literal2" runat="server" Text="Image :"></asp:Literal>
                        </div>
                        <div class="col-md-6" style="text-align: center">
                            <asp:FileUpload ID="FileUploader" runat="server" Style="padding-top: 10px;"></asp:FileUpload>
                        </div>
                    </div>
                    <div class="row mb-3" style="padding-top: 20px;">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-secondary btn-user " BackColor="#51E567 " BorderColor="#51E567" Style="width: 200px;" OnClick="btnSave_Click" ValidationGroup="1" />
                        </div>
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-secondary btn-user " BackColor="#565656" BorderColor="#565656" Style="width: 200px;" OnClick="btnBack_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="Literal3" runat="server" Text="End Date :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <input id="txtEndDate" runat="server" cssclass="form-control form-control-user" type="date" style="width: 100%; height: 40px; border-radius: 5px; padding-left: 10px;"></input>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtEndDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblDescription" runat="server" Text="Description :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtDescription" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblCount" runat="server" Text="Member Count :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtCount" runat="server" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtCount" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
