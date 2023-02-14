<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveLoan.aspx.cs" Inherits="ManPowerWeb.ApproveLoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server">
        <Columns>
            <asp:BoundField HeaderText="Id" />
            <asp:BoundField HeaderText="Employee Name" />
            <asp:BoundField HeaderText="Date Request" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="BtnView">View</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
