<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransferReport.aspx.cs" Inherits="ManPowerWeb.TransferReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Transfer Detail Report</h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvTransferReport" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="CreatedUser" HeaderText="Created User" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="ActionTakenUser.Name" HeaderText="Action Taken User" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="ActionTakenDate" HeaderText="Action Taken Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Documents" HeaderText="Documents" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Reason" HeaderText="Reason" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
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
