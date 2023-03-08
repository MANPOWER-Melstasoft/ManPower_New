<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="ManPowerWeb.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
        <asp:GridView Style="margin-top: 30px;" ID="gvUser" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="SystemUserId" HeaderText="ID" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="Name" HeaderText="NAME" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="EmpNumber" HeaderText="EMPLOYEE NUMBER" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="Email" HeaderText="EMAIL" HeaderStyle-CssClass="table-dark" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
