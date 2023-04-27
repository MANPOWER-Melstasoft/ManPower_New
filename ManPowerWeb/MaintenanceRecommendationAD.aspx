﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintenanceRecommendationAD.aspx.cs" Inherits="ManPowerWeb.MaintenanceRecommendationAD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4 mb-5">

            <h2>Vehicle Maintenance Requests Recomandation AD</h2>


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
                    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-success mr-3" OnClick="Button1_Click" Style="width: 120px;" />

                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-facebook" OnClick="btnReset_Click" Style="width: 120px;" />
                </div>
            </div>

            <div class="table-responsive mt-3" style="width: 100%;">
                <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField HeaderText="Requested Date" DataField="RequestDate" HeaderStyle-CssClass="table-dark" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Requested User" HeaderStyle-CssClass="table-dark">
                            <ItemTemplate>
                                <%# Eval("Employee.EmpInitials") + " " + Eval("Employee.LastName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Vehicle Number" DataField="VehicleNumber" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Description" DataField="RequestDescription" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status" HeaderStyle-CssClass="table-dark">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "0" ?true:false %>' Text="Pending" ForeColor="Blue"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "1" ?true:false %>' Text="Send to Approval" ForeColor="Black"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "2" ?true:false %>' Text="Approved" ForeColor="Green"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsApproved").ToString() == "3" ?true:false %>' Text="Rejected" ForeColor="red"> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="File Number" DataField="FileNo" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
                                    a href='<%#"MaintenanceRecommendationADView.aspx?id="+DataBinder.Eval(Container.DataItem,"VehicleMeintenanceId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
