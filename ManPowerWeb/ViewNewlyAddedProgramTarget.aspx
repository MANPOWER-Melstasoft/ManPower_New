<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewNewlyAddedProgramTarget.aspx.cs" Inherits="ManPowerWeb.ViewNewlyAddedProgramTarget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1"
        runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container">
                <div class="card p-4 mb-4 ">
                    <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                        <asp:GridView runat="server" ID="gvProgramTargetNotification"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Title" HeaderText="Program Target Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="RecommendedDate" HeaderText="Date Recommended" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_View" runat="server" CssClass="btn btn-success" ToolTip="Mark as Read" OnClick="btn_View_Click"><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No New Program Target To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
