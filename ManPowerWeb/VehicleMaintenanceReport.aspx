<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehicleMaintenanceReport.aspx.cs" Inherits="ManPowerWeb.VehicleMaintenanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Vehicle Maintenance Report</h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvVehicleMaintReport" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="RequestBy.Name" HeaderText="Requested User" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="RequestDate" HeaderText="Requested Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="VehicleNumber" HeaderText="Vehicle No." HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="RequestDescription" HeaderText="Description" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="EstimatedCost" HeaderText="Estimated Cost" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Attachment" HeaderText="Attachment" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="FileNo" HeaderText="File No." HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <%--<asp:BoundField DataField="CategoryId" HeaderText="Category" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />--%>
                    <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label runat="server" Visible='<%#Eval("CategoryId").ToString() == "2" ?true:false %>' Text="Repair">  </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("CategoryId").ToString() == "3" ?true:false %>' Text="Service">  </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="RecommendBy.Name" HeaderText="Recommended User" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="RecomandDate" HeaderText="Recommended Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="ApproveBy.Name" HeaderText="Approved User" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="ApprovedDate" HeaderText="Approved Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
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
