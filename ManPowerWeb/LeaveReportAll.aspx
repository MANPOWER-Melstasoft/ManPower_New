<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveReportAll.aspx.cs" Inherits="ManPowerWeb.LeaveReportAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="card">

        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Leave Report All</h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">

            <asp:GridView ID="gvLeaveReport" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="_EMployeeDetails.EmployeeId" HeaderText="Employee Id" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="_EMployeeDetails.NameWithInitials" HeaderText="Employee Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="district.Name" HeaderText="District" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="dsDivition.Name" HeaderText="DS Divition" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="NoOfLeaves" HeaderText="No Of Leaves" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-info" Width="100px" Height="35px" OnClick="btnView_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
        <div style="margin-bottom: 40px; margin-left: 20px; margin-top: 20px;">
            <button runat="server" id="btnRun" onserverclick="btnExportExcel_Click" class="btn btn-success" title="Export To Excel">
                <i class="fa fa-file-export" style="margin-right: 10px"></i>Export To Excel
            </button>

        </div>
    </div>

</asp:Content>
