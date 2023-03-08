<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME23UsersRender.aspx.cs" Inherits="ManPowerWeb.DME23UsersRender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <h2>DME23</h2>
    <div class="row mb-5">
        <div class="card">
            <div class="table-responsive">
                <asp:GridView ID="gvDme23" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Program_Name" HeaderText="program Name" />
                        <asp:BoundField DataField="annual_Count" HeaderText="Annual Target" />
                        <asp:BoundField DataField="quartly_count" HeaderText="Quarter Target" />
                        <asp:BoundField DataField="Monthly_count" HeaderText="Monthly Target" />
                        <asp:BoundField HeaderText="No. of Prog. Conducted" />
                        <asp:BoundField DataField="Date" HeaderText="Program Date" />
                        <asp:BoundField DataField="Location" HeaderText="Place" />
                        <asp:BoundField DataField="Male_Count" HeaderText="No. of Male beneficiaries" />
                        <asp:BoundField DataField="Female_Count" HeaderText="No. of Female beneficiaries" />
                        <asp:BoundField DataField="Total_Count" HeaderText="Total beneficiaries" />
                        <asp:BoundField DataField="Person" HeaderText="Resource Person Name" />
                        <asp:BoundField DataField="Work_Places" HeaderText="Res. person Working place" />
                        <asp:BoundField HeaderText="Res. person Subject Area/Topic" />
                        <asp:BoundField DataField="Vote_Number" HeaderText="Vote Number" />
                        <asp:BoundField DataField="Approved_Amount" HeaderText="Expenditure" />
                        <asp:BoundField DataField="Financial_Source" HeaderText="Financial Source" />
                        <asp:BoundField HeaderText="Job Refferal Count" />
                        <asp:BoundField HeaderText="Job Placement Count" />
                        <asp:BoundField HeaderText="Training Refferal Count" />
                        <asp:BoundField HeaderText="Self Employers Count" />
                        <asp:BoundField HeaderText="Reasons for Difference" />
                        <asp:BoundField HeaderText="Remark" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
