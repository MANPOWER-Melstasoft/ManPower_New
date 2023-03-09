<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourcePersonView.aspx.cs" Inherits="ManPowerWeb.ResourcePersonView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container" style="padding-left: 30px;">
        <h2>Resource Person</h2>
        <br />
        <br />

        <div class="row">
            <div class="col-3">
                <label>Resource Person Type : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="rptype" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>NIC :</label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="nic" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Name :</label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="name" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Designation :</label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="desig" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Work Place :</label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="workPlace" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Qualifications :</label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="qalifications" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Persnal Address :</label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="address" runat="server" Width="230px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Contact Number : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="contact" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Whatsapp Number : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="whatsapp" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Email : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="email" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-2">
                <asp:Button runat="server" ID="btnSave" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" ValidationGroup="1" />
            </div>
        </div>
        <br />

    </div>
</asp:Content>
