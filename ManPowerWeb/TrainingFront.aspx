<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrainingFront.aspx.cs" Inherits="ManPowerWeb.AddTrainingFront" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xl-3 col-md-6">
                <div class="card mb-4">
                    <div class="card-body">
                        <asp:Image ID="Image1" runat="server" Height="100%"
                            Width="220px" ImageUrl="~/SystemDocuments/TrainingImages/bottomimg2.jpg" />
                        <a class="small text-white stretched-link" href="ViewCases.aspx?name=1"></a>
                    </div>
                    <div class="card-footer">
                        <div class="text-center">How to create a CV 111</div>
                    </div>
                </div>
            </div>
            <asp:Literal ID="ltTraining" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
