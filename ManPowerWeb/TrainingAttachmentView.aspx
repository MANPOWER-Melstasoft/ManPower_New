<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrainingAttachmentView.aspx.cs" Inherits="ManPowerWeb.TrainingAttachmentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <asp:GridView ID="gvAttachments" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Attachment" HeaderText="Attachments" />
            <asp:TemplateField HeaderText="View">
                <ItemTemplate>
                    <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-info" Width="100px" target="new"
                        a href='<%#"/SystemDocuments/TrainingRequestsAttachment/"+DataBinder.Eval(Container.DataItem,"Attachment") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
