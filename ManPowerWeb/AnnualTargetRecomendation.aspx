<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnnualTargetRecomendation.aspx.cs" Inherits="ManPowerWeb.AnnualTargetRecomendation" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mb-3">
        <div class="card">
            <h2>Annual Target Recommendation</h2>

            <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="ProgramTargetId" HeaderText="ID" HeaderStyle-CssClass="table-dark"></asp:BoundField>
                        <asp:BoundField DataField="TargetYear" HeaderText="YEAR" HeaderStyle-CssClass="table-dark"></asp:BoundField>
                        <asp:BoundField DataField="TargetMonth" HeaderText="MONTH" HeaderStyle-CssClass="table-dark"></asp:BoundField>
                        <asp:BoundField DataField="Title" HeaderText="Project" HeaderStyle-CssClass="table-dark"></asp:BoundField>

                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" CssClass="btn btn-success btn-user btn-block" runat="server" Width="100px" Height="35px" Text="View" OnClick="btnView_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
