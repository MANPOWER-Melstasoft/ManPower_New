<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PositionTransfer.aspx.cs" Inherits="ManPowerWeb.PositionTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="card m-4 p-4">
        <h2>Position Transfer</h2>

        <div class="row mb-3 ms-1 mt-5">
            <div class="col">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal runat="server" ID="txtRetire" Text="Transfer To"></asp:Literal>
                    </div>
                    <div class="col-sm-6">
                        <asp:DropDownList runat="server" ID="ddlTransferTo" CssClass="form-control form-control-user" AutoPostBack="true" OnSelectedIndexChanged="ddlTransferTo_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlTransferTo" BackColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Literal runat="server" ID="txtTransfer" Text="Transfer From"></asp:Literal>
                    </div>
                    <div class="col-sm-6">
                        <asp:DropDownList runat="server" ID="ddlTransferFrom" CssClass="form-control form-control-user"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlTransferFrom" BackColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                    </div>
                </div>
            </div>
        </div>


        <div class="row mb-3 ms-1 mt-5">
            <div class="col">
                <div class="row">

                    <div class="col-sm-6">
                        <asp:Button runat="server" ID="btnTransfer" CssClass="btn btn-primary " Text="Transfer" OnClick="btnTransfer_Click" ValidationGroup="1"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
