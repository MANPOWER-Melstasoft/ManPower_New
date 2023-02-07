<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewNewlyAddedProgramTarget.aspx.cs" Inherits="ManPowerWeb.ViewNewlyAddedProgramTarget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card p-4 mb-4 ">
            <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                <asp:GridView runat="server" ID="gvProgramTargetNotification"
                    Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center">

                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Program Target Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="RecommendedDate" HeaderText="Date Recommended" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
