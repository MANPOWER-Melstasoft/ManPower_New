<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserTrainingReport.aspx.cs" Inherits="ManPowerWeb.UserTrainingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4">
            <h2>User Training Reports</h2>

            <div class="mt-3">

                <div class="row mb-3 ms-1 mt-3">

                    <div class="col-sm-2">
                        Status :
                    </div>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-control-user" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvUserTrainingReport" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="TrainingRequestsId" HeaderText="Training Request ID" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.TrainingMainId" HeaderText="Training ID" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.Title" HeaderText="Title" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.Start_Date" HeaderText="Start Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Trainingmain.End_date" HeaderText="End Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="ProjectStatus.ProjectStatusName" HeaderText="Status" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
        </div>
        <div style="margin-bottom: 40px; margin-left: 20px; margin-top: 20px;">
            <button runat="server" id="btnRun" onserverclick="btnExportExcel_Click" class="btn btn-success" title="Export To Excel">
                <i class="fa fa-file-export" style="margin-right: 10px"></i>Export To Excel</button>

        </div>
    </div>
</asp:Content>
