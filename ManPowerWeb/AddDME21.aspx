<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDME21.aspx.cs" Inherits="ManPowerWeb.AddDME21" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Add DME21</h2>
        <div class="row mb-5" style="text-align: center; width: 70%;">
            <div class="col-sm-6 my-auto" style="width: 10% !important;">
                <asp:Label CssClass="font-weight-bold" ID="Label1" runat="server" Text="Work Type"></asp:Label>
            </div>
            <div class="col-sm-6" style="width: 90%;">
                <asp:DropDownList Style="width: 80%; height: 40px; padding-left: 10px;" ID="ddlWorkType" runat="server" DataTextField="TaskTypeName" DataValueField="TaskTypeId" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>
        <div class="row mb-5" style="text-align: center; width: 70%; display: none" id="ProgramDisplay" runat="server">
            <div class="col-sm-6 my-auto">
                <asp:Label CssClass="font-weight-bold" ID="Label4" runat="server" Text="Program Name"></asp:Label>
            </div>
            <div class="col-sm-6" style="width: 90%;">
                <asp:DropDownList Style="width: 80%; height: 40px; padding-left: 10px;" ID="ddlProgram" runat="server" DataTextField="TaskTypeName" DataValueField="TaskTypeId"></asp:DropDownList>
            </div>
        </div>
        <div class="row mb-5" style="text-align: center; width: 70%; display: none">
            <div class="col-sm-6 my-auto">
                <asp:Label CssClass="font-weight-bold" ID="Label5" runat="server" Text="Performed Duty"></asp:Label>
            </div>
            <div class="col-sm-6" style="width: 90%;">
                <textarea style="width: 80%;" id="TextArea1" cols="20" rows="2"></textarea>
            </div>
        </div>
        <div class="row mb-5" style="text-align: center; width: 70%; display: none">
            <div class="col-sm-6 my-auto">
                <asp:Label CssClass="font-weight-bold" ID="Label6" runat="server" Text="Performed Duty"></asp:Label>
            </div>
            <div class="col-sm-6" style="width: 90%;">
                <textarea style="width: 80%;" id="TextArea1" cols="20" rows="2"></textarea>
            </div>
        </div>
        <div class="row mb-5" style="text-align: center; width: 70%;">
            <div class="col-sm-6 my-auto">
                <asp:Label CssClass="font-weight-bold" ID="Label2" runat="server" Text="Performed Duty"></asp:Label>
            </div>
            <div class="col-sm-6" style="width: 90%;">
                <textarea style="width: 80%;" id="TextArea1" cols="20" rows="2"></textarea>
            </div>
        </div>
        <div class="row mb-5" style="text-align: center; width: 70%;">
            <div class="col-sm-6 my-auto">
                <asp:Label CssClass="font-weight-bold" ID="Label3" runat="server" Text="Work Attended Place"></asp:Label>
            </div>
            <div class="col-sm-6" style="width: 90%;">
                <input style="width: 80%;" id="Text1" type="text" />
            </div>
        </div>
    </div>
</asp:Content>
