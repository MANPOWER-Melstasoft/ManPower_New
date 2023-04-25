<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintenanceRequestView.aspx.cs" Inherits="ManPowerWeb.MaintenanceRequestView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4 mb-5">

            <h2>Maintenance Request</h2>


            <%--            <div class="row">
                <div class="col-4">
                    <label>File Number : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="fielNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>--%>
            <br />

            <div class="row">
                <div class="col-4">
                    <label>Date : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="date" runat="server" name="date" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-4">
                    <label>Maintenance Category : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="category" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-4">
                    <label>Requested By : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="requestedBy" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-4">
                    <label>Vehicle Number :</label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="vNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-4">
                    <label>Vehicle Meter :</label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtMeter" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
            <br />

            <div class="row" id="RowvehiclePrevMeter" runat="server">
                <div class="col-4">
                    <label>Previous Vehicle Meter :</label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtPrevMeter" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
            <br />


            <div class="row">
                <div class="col-4">
                    <label>Mileage :</label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtMiladge" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-4">
                    <label>Description : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="description" runat="server" name="place" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <br />

            <br />

            <div class="row">
                <div class="col-4">
                    <label>Is Approved : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="approval" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
            <br />

            <br />

            <div id="reject" runat="server">
                <div class="row">
                    <div class="col-4">
                        <label>Rejected Reason : </label>
                    </div>
                    <div class="col-8">
                        <asp:TextBox ID="reason" runat="server" name="place" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
            </div>

            <div id="selection" runat="server">
                <div class="row">
                    <div class="col-4">
                        <label>Select the Officer : </label>
                    </div>
                    <div class="col-8">
                        <asp:DropDownList ID="ddlOfficer" Width="250px" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                    </div>
                </div>
                <br />
            </div>

            <div id="btnChange1" runat="server">
                <div class="row">
                    <div class="col-2">
                        <asp:Button runat="server" ID="Button3" Text="Back" OnClick="isClicked" CssClass="btn btn-primary btn-user btn-block" />
                    </div>
                    <div class="col-3">
                        <asp:Button runat="server" ID="appBtn" Text="Send to Approval" OnClick="approvalButton" CssClass="btn btn-success btn-user btn-block" />
                    </div>
                </div>
                <br />
            </div>

            <div id="btnChange2" runat="server">
                <div class="row">
                    <div class="col-2">
                        <asp:Button runat="server" ID="Button1" Text="Back" OnClick="isClicked" CssClass="btn btn-primary btn-user btn-block" />
                    </div>
                    <div class="col-2">
                        <asp:Button runat="server" ID="Button2" Text="Send" OnClick="sendToApproval" CssClass="btn btn-danger btn-user btn-block" />
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
