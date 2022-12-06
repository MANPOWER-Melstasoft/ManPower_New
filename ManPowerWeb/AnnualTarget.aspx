<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnnualTarget.aspx.cs" Inherits="ManPowerWeb.AnnualTarget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Literal ID="Literal1" runat="server" Text="Year"></asp:Literal>
                    <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                        <asp:ListItem>2020</asp:ListItem>
                        <asp:ListItem>2021</asp:ListItem>
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                    </asp:DropDownList>


                </div>
                <div class="form-group col-md-6">
                    <asp:Literal ID="Literal2" runat="server" Text="Month"></asp:Literal>
                    <asp:DropDownList ID="ddlMonth" runat="server">
                        <asp:ListItem Value="1">January</asp:ListItem>
                        <asp:ListItem Value="2">February</asp:ListItem>
                        <asp:ListItem Value="3">March</asp:ListItem>
                        <asp:ListItem Value="4">April</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">August</asp:ListItem>
                        <asp:ListItem Value="9">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>

                </div>
            </div>
            <div class="row mb-3 ms-1">
                <div class="col-sm-3">
                    <asp:Button ID="btnReset" runat="server" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529" Text="Search" />
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Add New Target" />
                </div>
            </div>
        </form>
        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover"
                CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="ProgramTargetId" HeaderText="ID" />
                    <asp:BoundField DataField="TargetYear" HeaderText="YEAR" />
                    <asp:BoundField DataField="TargetMonth" HeaderText="TARGET MONTH" />
                    <asp:BoundField DataField="StartDate" HeaderText="START DATE" />
                    <asp:BoundField DataField="Description" HeaderText="DESCRIPTION" />
                    <asp:BoundField DataField="Title" HeaderText="TITLE" />


                </Columns>
            </asp:GridView>
        </div>


    </div>

</asp:Content>
