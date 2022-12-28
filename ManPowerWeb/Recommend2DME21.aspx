<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recommend2DME21.aspx.cs" Inherits="ManPowerWeb.Recommend2DME21" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Approve DME21</h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvDME21Recommend2" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="_SystemUser.Name" HeaderText="Username" />
                    <asp:BoundField DataField="TaskYearMonth.Year" HeaderText="Year" />
                    <asp:BoundField DataField="TaskYearMonth.Month" HeaderText="Month" />
                    <asp:TemplateField HeaderText="Get Action">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-secondary" ID="btnAction" runat="server" OnClick="btnAction_Click">View Details</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
