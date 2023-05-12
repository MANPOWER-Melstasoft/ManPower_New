<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EmployeePreviousWorkplace.aspx.cs" Inherits="ManPowerWeb.EmployeePreviousWorkplaces" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4">
            <h2>Enployee Previous WorkPlaces</h2>

            <div class="mt-3">

                <div class="row mb-3 ms-1 mt-3">

                    <div class="col-sm-2">
                        Employee Name :
                    </div>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-user" AutoPostBack="true">
                        </asp:TextBox>
                    </div>
                    <div class="col-sm-1"></div>

                    <div class="col-sm-2">
                        Employee ID :
                    </div>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtEmpID" runat="server" CssClass="form-control form-control-user" AutoPostBack="true"> 
                        </asp:TextBox>
                    </div>

                </div>
                <div class="row mb-3 ms-1 mt-3">

                    <div class="col-sm-8"></div>

                    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSearch_Click" Style="width: 120px;" />

                </div>
            </div>
        </div>

        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">

            <asp:GridView Style="margin-top: 30px;" ID="gvPreviousWorkplace" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" AllowPaging="true" PageSize="10" HeaderStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="TransfersRetirementResignationMainId" HeaderText="Transfer ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="employee.EmployeeId" HeaderText="Employee ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="employee.LastName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="employee.EmpInitials" HeaderText="Initials" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="departmentUnit.Name" HeaderText="Previous Workplace" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="departmentUnit2.Name" HeaderText="Current Workplace" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                </Columns>
            </asp:GridView>

            <div style="margin-bottom: 40px; margin-left: 20px; margin-top: 20px;">
                <button runat="server" id="btnExcell" onserverclick="btnExportExcel_Click" class="btn btn-success" title="Export To Excel">
                    <i class="fa fa-file-export" style="margin-right: 10px" visible="false"></i>Export To Excel
                </button>
            </div>

        </div>



    </div>
</asp:Content>

