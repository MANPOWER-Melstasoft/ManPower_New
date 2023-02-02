<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DistrictTASummary.aspx.cs" Inherits="ManPowerWeb.DistrictTASummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Target Achievement District Vise Summary</h2>
    <div class="row mb-5">
        <div class="card">
            <div class="table-responsive">
                <asp:GridView ID="gvTASummary" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ProgramTargetId" HeaderText="Program Target Id" />
                        <asp:BoundField DataField="ProgramPlanId" HeaderText="Program Plan Id" />
                        <asp:BoundField DataField="ProgramTargetName" HeaderText="Program Name" />
                        <asp:TemplateField HeaderText="Project Type">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("ProjectTypeId").ToString()=="2"?true:false%>' Text="Physical"></asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("ProjectTypeId").ToString()=="1"?true:false%>' Text="Online"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Target" HeaderText="Target" />
                        <asp:BoundField DataField="Achievement" HeaderText="Achievment" />
                        <asp:BoundField DataField="NoOfBeneficiary" HeaderText="No. of beneficiaries" />
                        <asp:BoundField DataField="Location" HeaderText="Location" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
