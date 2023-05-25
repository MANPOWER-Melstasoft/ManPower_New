<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveReportAll.aspx.cs" Inherits="ManPowerWeb.LeaveReportAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>

    <div class="container">
        <div class="card p-4">
            <h2>Leave Report All</h2>

            <div class="mt-3">

                <div class="row mb-3 ms-1 mt-3">

                    <div class="col-sm-2">
                        District :
                    </div>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control form-control-user" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>

                    <div class="col-sm-2">
                        Employee Name :
                    </div>
                    <div class="col-sm-2">
                        <asp:TextBox ID="empName" runat="server" CssClass="form-control form-control-user" AutoPostBack="true">
                        </asp:TextBox>
                    </div>

                    <div class="col-sm-2">
                        Employee ID :
                    </div>
                    <div class="col-sm-2">
                        <asp:TextBox ID="empID" runat="server" CssClass="form-control form-control-user" AutoPostBack="true">
                        </asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-9"></div>
                    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSearch_Click" Style="width: 120px;" />

                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-facebook" OnClick="btnReset_Click" Style="width: 120px;" />

                </div>
            </div>

            <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">

                <asp:GridView ID="gvLeaveReport" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center"
                    EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="_EMployeeDetails.EmployeeId" HeaderText="Employee Id" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="_EMployeeDetails.NameWithInitials" HeaderText="Employee Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="district.Name" HeaderText="District" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="dsDivition.Name" HeaderText="DS Divition" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="NoOfLeaves" HeaderText="No Of Leaves" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ReasonForLeave" HeaderText="Reason" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-info" Width="100px" Height="35px" OnClick="btnView_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No records</EmptyDataTemplate>
                </asp:GridView>

            </div>
            <div style="margin-bottom: 40px; margin-left: 20px; margin-top: 20px;">
                <button runat="server" id="btnRun" onserverclick="btnExportExcel_Click" class="btn btn-success" title="Export To Excel">
                    <i class="fa fa-file-export" style="margin-right: 10px"></i>Export To Excel
                </button>

            </div>
        </div>
    </div>
</asp:Content>
