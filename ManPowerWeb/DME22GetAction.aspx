<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME22GetAction.aspx.cs" Inherits="ManPowerWeb.DME22GetAction" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2 style="margin-bottom: 20px; margin-top: 20px;">DME22 Get Action</h2>
    </div>
    <div cssclass="table-responsive" style="text-align: center">
        <asp:GridView ID="DME22GetActionGridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="StartTime.Date" HeaderText="Date" />
                <asp:BoundField DataField="_TaskType.TaskTypeName" HeaderText="Work Type" />
                <asp:BoundField DataField="TaskDescription" HeaderText="Performed Duty" />
                <asp:BoundField DataField="WorkLocation" HeaderText="Work Attended place" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate runat="server">
                        <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="true" Style="width: 150px; height: 30px; padding-left: 10px;">
                            <asp:ListItem Text="Completed" Value="1" />
                            <asp:ListItem Text="Not Completed" Value="0" />
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remark">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:LinkButton CssClass="btn btn-outline-primary btn-lg btn-block" ID="btnSave" runat="server" OnClick="btnSave_Click">Save DME22</asp:LinkButton>
    </div>
</asp:Content>
