<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrainingAd.aspx.cs" Inherits="ManPowerWeb.TrainingAd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="contrainer" style="margin-left: 200px; margin-right: 200px;">
        <asp:ListView ID="lvTrainingAd" runat="server">
            <ItemTemplate>
                <div class="card" style="align-items: center; padding-top: 20px;">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Post_img") %>' Height="100%" Width="100%" />
                    <h4 style="margin-top: 20px; margin-bottom: 20px;"><%# Eval("Title") %></h4>
                    <h6 style="margin-bottom: 20px;">From <%# Eval("Start_Date") %> To <%# Eval("End_date") %></h6>
                    <p><%# Eval("Content") %></p>

                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="row d-flex justify-content-center" style="margin-bottom: 30px; margin-top: 20px;">
            <div class="col-3">
                <asp:LinkButton ID="btnBack" runat="server" Style="width: 150px;" CssClass="btn btn-outline-primary" OnClick="btnBack_Click">Back</asp:LinkButton>
            </div>
            <div class="col-3">
                <asp:LinkButton ID="btnApply" runat="server" Style="width: 150px;" OnClick="btnApply_Click">Apply</asp:LinkButton>
            </div>
            <div class="col-3">
                <asp:LinkButton ID="btnReject" runat="server" Style="width: 150px;" OnClick="btnReject_Click">Cancel</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
