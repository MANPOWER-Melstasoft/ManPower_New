<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME21.aspx.cs" Inherits="ManPowerWeb.DME21" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <h2>DME21</h2>
    <div class="row mb-5">
        <div class="col-sm-6">
            <asp:Label>Year : <%=Year%></asp:Label>
        </div>
        <div class="col-sm-6">
            <asp:Label>Month : <%=Month%></asp:Label>
        </div>
    </div>
    <div cssclass="table-responsive card" style="text-align: center">
        <asp:GridView ID="DME21GridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="StartTime.Date" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="_TaskType.TaskTypeName" HeaderText="Work Type" />
                <asp:BoundField DataField="TaskDescription" HeaderText="Performed Duty" />
                <asp:BoundField DataField="WorkLocation" HeaderText="Work Attended place" />
                <asp:TemplateField HeaderText="Add DME21">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="btn btn-outline-secondary" ID="btnAdd" runat="server" OnClick="btnAdd_Click">Add DME21</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit DME21">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="btn btn-outline-secondary" ID="btnEdit" runat="server" OnClick="btnEdit_Click">Edit DME21</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Add New Row">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="btn btn-outline-secondary" ID="btnAddRow" runat="server" OnClick="btnAdd_Click1"><i class="fa fa-plus" aria-hidden="true" ></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div style="margin-top: 20px; margin-bottom: 20px; text-align: end">
        <asp:LinkButton ID="btnApproval" runat="server" OnClick="btnApproval_Click" Style="width: 250px;">Send to Approval</asp:LinkButton>
    </div>
</asp:Content>
