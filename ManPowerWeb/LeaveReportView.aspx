<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveReportView.aspx.cs" Inherits="ManPowerWeb.LeaveReportView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="card">

        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Leave Report for Emp -
            <asp:Label ID="lblEmpId" runat="server" Text="N/A"></asp:Label></h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">


            <asp:GridView ID="gvLeaveReport" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="StaffLeaveId" HeaderText="Id" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Day Type" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <asp:Label runat="server" Visible='<%#Eval("DayTypeId").ToString() == "1" ?true:false %>' Text="Morning Half Day" ForeColor="Blue"> </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("DayTypeId").ToString() == "2" ?true:false %>' Text="Evening Half Day" ForeColor="Green"> </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("DayTypeId").ToString() == "3" ?true:false %>' Text="Full Day" ForeColor="red"> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="leaveType.Name" HeaderText="Leave Type" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="_EMployeeDetails.NameWithInitials" HeaderText="Employee" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="LeaveDate" HeaderText="Leave Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="NoOfLeaves" HeaderText="No Of Leaves" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="FromTime" HeaderText="From Time" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="ToTime" HeaderText="To Time" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Is Half Day" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <asp:Label runat="server" Visible='<%#Eval("IsHalfDay").ToString() == "1" ?true:false %>' Text="Yes" ForeColor="Blue"> </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("IsHalfDay").ToString() == "0" ?true:false %>' Text="No" ForeColor="Green"> </asp:Label>
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
