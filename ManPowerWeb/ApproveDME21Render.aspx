<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveDME21Render.aspx.cs" Inherits="ManPowerWeb.ApproveDME21Render" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div cssclass="table-responsive">
        <asp:GridView ID="gvDME21Approve" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="StartTime.Date" HeaderText="Date" />
                <asp:BoundField DataField="_TaskType.TaskTypeName" HeaderText="Work Type" />
                <asp:BoundField DataField="TaskDescription" HeaderText="Performed Duty" />
                <asp:BoundField DataField="WorkLocation" HeaderText="Work Attended place" />
                <asp:BoundField DataField="TaskAmendments" HeaderText="Remark" />
            </Columns>
        </asp:GridView>
    </div>
    <div style="margin-top: 20px; margin-bottom: 20px; text-align: center">
        <asp:LinkButton ID="btnApprove" CssClass="btn btn-outline-success" runat="server" OnClick="btnApprove_Click" Style="width: 250px;">Approve DME21</asp:LinkButton>
    </div>
    <div style="margin-top: 20px; margin-bottom: 20px; text-align: center">
        <asp:LinkButton ID="btnReject" CssClass="btn btn-outline-danger" runat="server" OnClick="btnReject_Click" Style="width: 250px;">Reject DME21</asp:LinkButton>
    </div>
</asp:Content>
