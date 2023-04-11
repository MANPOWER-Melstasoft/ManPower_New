<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrainingReport.aspx.cs" Inherits="ManPowerWeb.TrainingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Training Report</h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvTrainingReport" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Trainingmain.Title" HeaderText="Title" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.Content" HeaderText="Content" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="SystemUser.Name" HeaderText="Created User" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.Created_Date" HeaderText="Created Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.Member_Count" HeaderText="Member Count" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.Start_Date" HeaderText="Start Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.End_date" HeaderText="End Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.Post_img" HeaderText="Image" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
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
