<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnnualTargetRecomendation.aspx.cs" Inherits="ManPowerWeb.AnnualTargetRecomendation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mb-3">
        <div class="card">
            <h2>Annual Target Recommendation</h2>

            <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="ProgramTargetId" HeaderText="ID" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="TargetYear" HeaderText="YEAR" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="TargetMonth" HeaderText="MONTH" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="Title" HeaderText="Project" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="Title" HeaderText="Action" HeaderStyle-CssClass="table-dark" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" runat="server">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
