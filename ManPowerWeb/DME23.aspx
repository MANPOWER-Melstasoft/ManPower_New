<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME23.aspx.cs" Inherits="ManPowerWeb.DME23" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <h2>DME23</h2>
    <div class="row mb-5">
        <div class="col-4">
            <asp:Label runat="server">User Id : <%=UserId%></asp:Label>
        </div>
        <div class="col-4">
            <asp:Label runat="server">User Name : <%=OfficerName%></asp:Label>
        </div>
    </div>
    <div class="mb-4 mt-4">
        <div class="row">
            <div class="col-3">
                <asp:TextBox ID="txtName" runat="server" placeholder="Search by Program Name" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:DropDownList ID="ddlMonth" placeholder="Search by Month" runat="server" CssClass="form-control form-control-user" DataTextField="monthName" DataValueField="monthNumber"></asp:DropDownList>
            </div>
            <div class="col-2">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSearch_Click" />
            </div>
            <div class="col-2">
                <asp:Button ID="btnGetAll" runat="server" Text="Get All" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGetAll_Click" />
            </div>
        </div>
    </div>
    <div>
        <asp:Label ID="lblMSG" runat="server" Text=""></asp:Label>
    </div>
    <div class="card">
        <div class="table-responsive">
            <asp:GridView ID="gvDme23" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Program_Name" HeaderText="program Name" />
                    <asp:BoundField DataField="annual_Count" HeaderText="Annual Target" />
                    <asp:BoundField DataField="quartly_count" HeaderText="Quarter Target" />
                    <asp:BoundField DataField="Monthly_count" HeaderText="Monthly Target" />
                    <asp:BoundField HeaderText="No. of Prog. Conducted" />
                    <asp:BoundField DataField="Date" HeaderText="Program Date" />
                    <asp:BoundField DataField="Location" HeaderText="Place" />
                    <asp:BoundField DataField="Male_Count" HeaderText="No. of Male beneficiaries" />
                    <asp:BoundField DataField="Female_Count" HeaderText="No. of Female beneficiaries" />
                    <asp:BoundField DataField="Total_Count" HeaderText="Total beneficiaries" />
                    <asp:BoundField DataField="Person" HeaderText="Resource Person Name" />
                    <asp:BoundField DataField="Work_Places" HeaderText="Res. person Working place" />
                    <asp:BoundField HeaderText="Res. person Subject Area/Topic" />
                    <asp:BoundField DataField="Vote_Number" HeaderText="Vote Number" />
                    <asp:BoundField DataField="Approved_Amount" HeaderText="Expenditure" />
                    <asp:BoundField DataField="Financial_Source" HeaderText="Financial Source" />
                    <asp:BoundField HeaderText="Job Refferal Count" />
                    <asp:BoundField HeaderText="Job Placement Count" />
                    <asp:BoundField HeaderText="Training Refferal Count" />
                    <asp:BoundField HeaderText="Self Employers Count" />
                    <asp:BoundField HeaderText="Reasons for Difference" />
                    <asp:BoundField HeaderText="Remark" />
                </Columns>
            </asp:GridView>
        </div>
        <div style="margin-top: 20px; margin-bottom: 20px; margin-left: 10px;">

            <button runat="server" id="btnRun" onserverclick="btnExportExcel_Click" class="btn btn-success" title="Export To Excel">
                <i class="fa fa-file-export" style="margin-right: 10px"></i>Export To Excel
            </button>

        </div>
    </div>
</asp:Content>
