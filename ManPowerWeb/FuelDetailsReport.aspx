<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FuelDetailsReport.aspx.cs" Inherits="ManPowerWeb.FuelDetailsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4 mb-5">

            <h2>Vehicle Maintenance</h2>


            <div class="row mt-4">
                <div class="col-6">
                    <div class="row">
                        <div class="col-5">
                            <label>Vehicle Number</label>
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="txtVehicleNumber" runat="server" name="date" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                        <div class="col-5">
                            <label>Employee Name</label>
                        </div>
                        <div class="col-7">
                            <asp:DropDownList ID="ddlEmployee" runat="server" name="date" Width="250px" TextMode="Date" CssClass="form-control form-control-user"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-6">
                    <div class="row">
                        <div class="col-5">
                            <label>Start Date</label>
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="txtStartDate" runat="server" name="date" Width="250px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                        <div class="col-5">
                            <label>End Date</label>
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="txtEndDate" runat="server" name="date" Width="250px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-6">
                    <div class="row">
                        <div class="col-5">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-success mr-3" />



                            <asp:Button ID="btnGetAll" runat="server" Text="Get ALL" CssClass="btn btn-facebook mr-3" OnClick="btnGetAll_Click" />

                        </div>
                    </div>

                </div>
            </div>



            <div class="table-responsive mt-3" style="width: 100%;">
                <asp:GridView Style="margin-top: 30px;" ID="gvFuelDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None"
                    FooterStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger" HeaderStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="VehicleNumber" HeaderText="Vehicle Number" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField DataField="LitersCount" HeaderText="Liter Count" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField DataField="CreatedDate" HeaderText="Date" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}"></asp:BoundField>
                        <asp:BoundField DataField="OrderNumber" HeaderText="Order Number" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField DataField="FuelTypeName" HeaderText="Fuel Type" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                    </Columns>
                    <EmptyDataTemplate>No records</EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
