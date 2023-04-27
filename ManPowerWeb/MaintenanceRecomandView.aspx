<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintenanceRecomandView.aspx.cs" Inherits="ManPowerWeb.MaintenanceRecomandView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4 mb-5">
            <h2>Maintenance Request Recommendation</h2>



            <div class="row mt-5 mb-3">
                <div class="col-4">
                    <label>File Number : </label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtFielNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtFielNo" ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                </div>
            </div>


            <div class="row mt-3 mb-3">
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
                    <asp:DropDownList ID="ddlCategory" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:DropDownList>
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
                    <asp:Button runat="server" ID="Button3" Text="Back" OnClick="isClicked" CssClass="btn btn-primary btn-user btn-block" />
                </div>
                <div class="col-2" id="butonA" runat="server">
                    <asp:Button runat="server" ID="acceptBtn" Text="Approve" OnClick="Accept" CssClass="btn btn-success btn-user btn-block" ValidationGroup="1" />
                </div>
                <div class="col-2" id="butonR" runat="server">
                    <button type="button" class="btn btn-danger btn-user btn-block" data-toggle="modal" data-target="#exampleModalCenter">Reject</button>
                </div>

            </div>


            <%------------------- model ----------------------%>

            <!-- Modal -->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <center>
                                <div class="row">
                                    <div class="col-4">
                                        <label>Reason to reject :</label>
                                    </div>
                                    <div class="col-10">
                                        <asp:TextBox ID="rejectReason" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine" ValidationGroup="1"></asp:TextBox>
                                    </div>
                                </div>
                            </center>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <asp:Button runat="server" ID="Button1" Text="Reject" OnClick="Reject" CssClass="btn btn-danger" Width="100px" />
                        </div>
                    </div>
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
