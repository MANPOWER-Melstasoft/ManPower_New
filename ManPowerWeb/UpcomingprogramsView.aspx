<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpcomingprogramsView.aspx.cs" Inherits="ManPowerWeb.UpcomingprogramsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <h2>Completed Program</h2>
        <br />
        <br />


        <div class="row">
            <div class="col-3">
                <label>Name of the program:</label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="pName" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-3">
                <label>Place : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="place" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />


        <div class="row">
            <div class="col-3">
                <label>Program Conducted Date : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="date" runat="server" name="date" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Coordinating Officer : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="officer" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />
        <br />

        <h4><b>Number Of Beneficiaries </b></h4>
        <br />
        <div class="row">
            <div class="col-3">
                <label>Male Count : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="male" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Female Count : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="female" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Total : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="total" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />
        <br />


        <div class="row">
            <div class="col-3">
                <label>Financial Source : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="finSource" runat="server" CssClass="form-control form-control-user" Width="230px" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Outcome : </label>
            </div>
            <div class="col-4">
                <asp:TextBox ID="outcome1" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Output : </label>
            </div>
            <div class="col-4">
                <asp:TextBox ID="output1" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
            <div class="col-2">
                <label>Actual Output : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="output2" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-3">
                <label>Estimated Amount : </label>
            </div>
            <div class="col-4">
                <asp:TextBox ID="amt1" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
            <div class="col-2">
                <label>Actual Amount : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="amt2" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />



        <div class="row">
            <div class="col-3">
                <label>Is Approved : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="approval" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>
        <br />
        <br />

        <div class="row">
            <div class="col-2">
                <asp:Button runat="server" ID="Button3" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" />
            </div>
        </div>
        <br />

    </div>
</asp:Content>
