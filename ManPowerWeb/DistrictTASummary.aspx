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
                        <asp:BoundField DataField="Target_Id" HeaderText="Program Target Id" />
                        <asp:BoundField DataField="Plan_Id" HeaderText="Program Plan Id" />
                        <asp:BoundField DataField="Name" HeaderText="Program Name" />
                        <asp:TemplateField HeaderText="Project Type">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("program_type_id").ToString()=="2"?true:false%>' Text="Physical"></asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("program_type_id").ToString()=="1"?true:false%>' Text="Online"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Projects" HeaderText="Target" />
                        <asp:BoundField DataField="Count" HeaderText="Achievment" />
                        <asp:BoundField DataField="No_of_Beneficiaries" HeaderText="No. of beneficiaries" />
                        <asp:BoundField DataField="Locations" HeaderText="Location" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
