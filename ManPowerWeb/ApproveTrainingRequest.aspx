<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveTrainingRequest.aspx.cs" Inherits="ManPowerWeb.ApproveTrainingRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Approve/Reject Training Requests</h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvApproveTraining" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ProgramDate" HeaderText="Program Date" />
                    <asp:BoundField DataField="Employee_Id" HeaderText="Employee Id" />
                    <asp:BoundField DataField="Employee.fullName" HeaderText="Employee Name" />
                    <asp:BoundField DataField="Program.ProgramName" HeaderText="Program" />
                    <asp:BoundField DataField="Institute" HeaderText="Institute" />
                    <asp:BoundField DataField="Content" HeaderText="Content" />
                    <asp:TemplateField HeaderText="Approve">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-success" ID="btnApprove" runat="server" Style="width: 150px;" OnClick="btnApprove_Click">Approve</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reject">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-danger" ID="btnReject" runat="server" Style="width: 150px;" OnClick="btnReject_Click">Reject</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
