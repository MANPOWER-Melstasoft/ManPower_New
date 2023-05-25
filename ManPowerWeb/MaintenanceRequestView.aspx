<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintenanceRequestView.aspx.cs" Inherits="ManPowerWeb.MaintenanceRequestView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>

    <div class="container">
        <div class="card p-4 mb-5">
            <h2>Maintenance Request View</h2>

            <div class="row mt-5 mb-3">
                <div class="col-4">
                    <label>Date : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="date" runat="server" name="date" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>


            <div class="row mt-3  mb-3">
                <div class="col-4">
                    <label>Maintenance Category : </label>
                </div>
                <div class="col-8">
                    <asp:DropDownList ID="ddlCategory" runat="server" name="place" Width="250px" CssClass="form-control form-control-user" Enabled="false"></asp:DropDownList>
                </div>
            </div>


            <% if (ddlCategory.SelectedValue == "4")
                { %>
            <div class="row mt-3  mb-3">
                <div class="col">
                    <div class="row">
                        <div class="col-4">
                            <label>Insurance Start Date : </label>
                        </div>
                        <div class="col-8">
                            <asp:TextBox ID="txtStartDate" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="row">
                        <div class="col-4">
                            <label>Insurance End Date : </label>
                        </div>
                        <div class="col-8">
                            <asp:TextBox ID="txtEndDate" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <%} %>
            <div class="row mt-3  mb-3">
                <div class="col-4">
                    <label>Requested By : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="requestedBy" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>


            <div class="row mt-3  mb-3">
                <div class="col-4">
                    <label>Vehicle Number :</label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="vNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>




            <%if (ddlCategory.SelectedValue != "2")
                { %>

            <div class="row mt-3  mb-3">
                <div class="col-4">
                    <label>Vehicle Meter :</label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtMeter" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <%} %>


            <%if (ddlCategory.SelectedValue == "3")
                { %>
            <div class="row mt-3 mb-3">
                <div class="col-4">
                    <label>Previous Vehicle Meter :</label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtPrevMeter" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <%} %>

            <div class="row mt-3  mb-3">
                <div class="col-4">
                    <label>Mileage :</label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtMiladge" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>


            <div class="row mt-3 mb-3">
                <div class="col-4">
                    <label>Description : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="description" runat="server" name="place" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>


            <div class="row mt-3">
                <div class="col-4">
                    <label>Upload Document View : </label>
                </div>
                <div class="col-8">
                    <a id="UploadDoclink" runat="server">
                        <asp:Label ID="Label2" runat="server" />
                    </a>
                </div>
            </div>

            <div class="row mt-3 mb-3">
                <div class="col-4">
                    <label>Is Approved : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="approval" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>



            <%if (ddlCategory.SelectedValue == "2")
                { %>
            <div class="row mt-3">
                <div class="col-4">
                    <label>Engineer Recommendation : </label>
                </div>
                <div class="col-8">
                    <asp:CheckBox runat="server" ID="chkEnginerrReommendation" CssClass="customCheckbox" />
                </div>
            </div>

            <div class="row mt-3" runat="server" id="rowEngFileUploader" visible="false">
                <div class="col-4">
                    <label>Engineer Recommendation Document : </label>
                </div>
                <div class="col-8">
                    <a id="Doclink" runat="server">
                        <asp:Label ID="Label1" runat="server" />
                    </a>
                </div>
            </div>


            <%} %>

            <div class="row mt-4 mb-3">
                <div class="col-2">
                    <asp:Button runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-primary btn-user btn-block" />
                </div>
            </div>

        </div>
    </div>

    <style>
        .customCheckbox input[type="checkbox"] {
            /* Set your desired width and height here */
            width: 20px;
            height: 20px;
        }
    </style>
</asp:Content>
