<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME23Users.aspx.cs" Inherits="ManPowerWeb.DME23Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>DME23 - All Users</h2>
        <div class="card">
            <div class="table-responsive" style="width: 100%; padding-left: 20px; padding-right: 20px;">

                <asp:GridView Style="margin-top: 30px;" ID="gvDME23Users" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None" AllowPaging="true" PageSize="10" HeaderStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="SystemUserId" HeaderText="System User Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="EmpNumber" HeaderText="Employee No." ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact No." ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                        <asp:TemplateField HeaderText="View DME23" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" runat="server" Text="View DME23" CssClass="btn btn-success" OnClick="btnView_Click" Width="150px" Height="35px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>

</asp:Content>
