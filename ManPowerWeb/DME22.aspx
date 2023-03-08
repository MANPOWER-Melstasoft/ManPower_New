<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME22.aspx.cs" Inherits="ManPowerWeb.DME22" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">DME22</h2>
        <div class="row mb-5" style="margin-left: 100px;">
            <div class="col-sm-4">
                <asp:Label>Year : </asp:Label>
                <asp:DropDownList ID="ddlYear" runat="server" Style="width: 200px; height: 40px; padding-left: 10px;"></asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <asp:Label>Month : </asp:Label>
                <asp:DropDownList ID="ddlMonth" runat="server" Style="width: 200px; height: 40px; padding-left: 10px;" DataTextField="monthName" DataValueField="monthNumber"></asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-lg btn-outline-primary" Style="width: 200px;" OnClick="btnSearch_Click">Search</asp:LinkButton>
            </div>
        </div>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="DME22GridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="TaskYearMonth.Year" HeaderText="Year" />
                    <asp:BoundField DataField="TaskYearMonth.Month" HeaderText="Month" />
                    <asp:BoundField DataField="_ProjectStatus.ProjectStatusName" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-secondary" ID="btnAction" runat="server" OnClick="btnAction_Click1">Get Action</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
