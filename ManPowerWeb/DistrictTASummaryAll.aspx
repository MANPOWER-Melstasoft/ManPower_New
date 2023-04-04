<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DistrictTASummaryAll.aspx.cs" Inherits="ManPowerWeb.DistrictTASummaryAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card p-4 mb-4 mt-5">
            <h2>Target Achievement District Vise Summary</h2>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-4 mt-4">
                        <div class="row">
                            <div class="col-4">
                                <asp:TextBox ID="txtLocation" runat="server" placeholder="Search by Location" CssClass="form-control form-control-user"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnGetAll" runat="server" Text="Get All" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGetAll_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="table-responsive mt-5 mb-4">
                        <asp:Label ID="lblMSG" runat="server" Text="" CssClass="ml-2"></asp:Label>
                        <asp:Table ID="tblTaSummary" runat="server" CssClass="table table-bordered"></asp:Table>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <div>

                <button runat="server" id="btnRun" onserverclick="btnExportExcel_Click" class="btn btn-success" title="Export To Excel">
                    <i class="fa fa-file-export" style="margin-right: 10px"></i>Export To Excel
                </button>

            </div>
        </div>
    </div>

</asp:Content>
