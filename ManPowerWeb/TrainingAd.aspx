<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrainingAd.aspx.cs" Inherits="ManPowerWeb.TrainingAd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contrainer" style="margin-left: 200px; margin-right: 200px;">
        <asp:ListView ID="lvTrainingAd" runat="server">
            <ItemTemplate>
                <div class="card" style="align-items: center; padding-top: 20px;">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Post_img") %>' />
                    <h4 style="margin-top: 20px; margin-bottom: 20px;"><%# Eval("Title") %></h4>
                    <h6 style="margin-bottom: 20px;">From <%# Eval("Start_Date") %> To <%# Eval("End_date") %></h6>
                    <p><%# Eval("Content") %></p>

                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="row" style="margin-bottom: 30px; margin-top: 20px;">
            <div class="col d-flex flex-row-reverse">
                <asp:LinkButton ID="btnApply" runat="server" Style="width: 150px;" OnClick="btnApply_Click">Apply</asp:LinkButton>
            </div>
            <div class="col">
                <asp:LinkButton ID="btnReject" runat="server" Style="width: 150px;" OnClick="btnReject_Click">Cancel</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
