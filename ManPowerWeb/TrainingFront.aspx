<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrainingFront.aspx.cs" Inherits="ManPowerWeb.AddTrainingFront" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <asp:Literal ID="ltTraining" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
