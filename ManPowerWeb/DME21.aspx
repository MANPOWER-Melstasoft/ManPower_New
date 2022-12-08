<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME21.aspx.cs" Inherits="ManPowerWeb.DME21" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>DME21</h2>
    <div class="row mb-5">
        <div class="col-sm-6">
            <asp:Label>Year : <%=Year%></asp:Label>
        </div>
        <div class="col-sm-6">
            <asp:Label>Month : <%=Month%></asp:Label>
        </div>
    </div>
    <div cssclass="table-responsive">
        <asp:GridView ID="DME21GridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="date" HeaderText="Date" />
                <asp:BoundField HeaderText="Work Type" />
                <asp:BoundField HeaderText="Performed Duty" />
                <asp:BoundField HeaderText="Work Attended place" />
                <asp:TemplateField HeaderText="Add DME21">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="btn btn-outline-secondary" ID="btnAdd" runat="server">Add DME21</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
