<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehicleMeintenanceSearch.aspx.cs" Inherits="ManPowerWeb.VehicleMeintenanceSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4 mb-5">

            <h2>Vehicle Maintenance</h2>


            <div class="row mt-4">
                <div class="col-6">
                    <div class="row">
                        <div class="col-3">
                            <label>Category : </label>
                        </div>
                        <div class="col-7">
                            <asp:DropDownList ID="ddlCategory" Width="250px" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                        <div class="col-5">
                            <label>Date :</label>
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="date" runat="server" name="date" Width="250px" TextMode="Date" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4">

                <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-success mr-3" OnClick="btnSearch_Click" />



                <asp:Button ID="Button3" runat="server" Text="Reset" CssClass="btn btn-facebook mr-3" OnClick="reset" />



                <a href="MaintenanceRequest.aspx">
                    <asp:Button ID="Button2" runat="server" Text="Request Maintenance" CssClass="btn btn-primary" OnClick="isClicked" />
                </a>

            </div>



            <div class="table-responsive" style="width: 100%;">
                <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Requested Date" DataField="RequestDate" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Vehicle Number" DataField="VehicleNumber" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Description" DataField="RequestDescription" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Status" DataField="IsApproved" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="File Number" DataField="FileNo" HeaderStyle-CssClass="table-dark" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
                                    a href='<%#"MaintenanceRequestView.aspx?id="+DataBinder.Eval(Container.DataItem,"VehicleMeintenanceId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
