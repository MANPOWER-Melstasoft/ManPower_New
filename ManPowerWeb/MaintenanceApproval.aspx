<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintenanceApproval.aspx.cs" Inherits="ManPowerWeb.MaintenanceApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4 mb-5">


            <h2>Vehicle Maintenance Requests Approvals</h2>


            <div class="row mt-4 mb-3">
                <div class="col-6">
                    <div class="row">
                        <div class="col-3">
                            <label>Category : </label>
                        </div>
                        <div class="col-7">
                            <asp:DropDownList ID="ddlCategory" Width="250px" runat="server" CssClass="dropdown-toggle form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                        <div class="col-3">
                            <label>Date :</label>
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="date" runat="server" name="date" Width="250px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-6">

                    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSearch_Click" Style="width: 120px;" />

                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-facebook" OnClick="btnReset_Click" Style="width: 120px;" />
                </div>
            </div>


            <div class="table-responsive mt-3" style="width: 100%;">
                <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField HeaderText="Requested Date" DataField="RequestDate" HeaderStyle-CssClass="table-dark" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Requested User" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Eval("Employee.EmpInitials") + " " + Eval("Employee.LastName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Vehicle Number" DataField="VehicleNumber" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Description" DataField="RequestDescription" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status" HeaderStyle-CssClass="table-dark">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "0" ?true:false %>' Text="Not Recommended" ForeColor="Blue"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "1" ?true:false %>' Text="Pending Recommendation To Transport Officer" ForeColor="Black"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "2" ?true:false %>' Text="Pending Recommendation To Assistant Director" ForeColor="Green"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "3" ?true:false %>' Text="Pending Approval To Director" ForeColor="red"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "4" ?true:false %>' Text="Request Approved" ForeColor="red"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "5" ?true:false %>' Text="Request Rejected By TO" ForeColor="red"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "6" ?true:false %>' Text="Request Rejected By AD" ForeColor="red"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "7" ?true:false %>' Text="Request Rejected By Director" ForeColor="red"> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="File Number" DataField="FileNo" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
                                    a href='<%#"MaintenanceApprovalView.aspx?id="+DataBinder.Eval(Container.DataItem,"VehicleMeintenanceId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
