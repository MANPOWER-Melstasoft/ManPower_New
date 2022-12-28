<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DMe21FrontRender.aspx.cs" Inherits="ManPowerWeb.DMe21FrontRender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div cssclass="table-responsive">
        <asp:GridView ID="gvDme21Render" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="StartTime.Date" HeaderText="Date" />
                <asp:BoundField DataField="_TaskType.TaskTypeName" HeaderText="Work Type" />
                <asp:BoundField DataField="TaskDescription" HeaderText="Performed Duty" />
                <asp:BoundField DataField="WorkLocation" HeaderText="Work Attended place" />
            </Columns>
        </asp:GridView>
    </div>
    <div style="margin-top: 20px; margin-bottom: 20px; text-align: end">
        <asp:LinkButton ID="btnBack" runat="server" Style="width: 250px;" CssClass="btn btn-outline-secondary" OnClick="btnBack_Click">Back</asp:LinkButton>
    </div>
</asp:Content>
