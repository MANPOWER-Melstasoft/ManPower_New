<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplyLeaves.aspx.cs" Inherits="ManPowerWeb.ApplyLeaves" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <asp:UpdatePanel runat="server" ID="updatepannel1">
            <ContentTemplate>
                <div class="card ml-4 p-4">
                    <h2><b>Apply Leave</b></h2>
                    <div class="mt-3">

                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal2" runat="server" Text="Leave Type"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddlLeaveType" CssClass="form-control form-control-user" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlLeaveType" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                </div>
                            </div>



                        </div>
                        <% if (ddlLeaveType.SelectedValue != "4")
                            { %>
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal6" runat="server" Text="Day Type"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddlDayType" CssClass="form-control form-control-user">
                                            <asp:ListItem Value="1">Morning-Half</asp:ListItem>
                                            <asp:ListItem Value="2">Evening-Half</asp:ListItem>
                                            <asp:ListItem Value="3">Full Day</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlDayType" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>

                                </div>
                            </div>



                        </div>
                        <% } %>

                        <%--Starttime and EndTime--%>
                        <% if (ddlLeaveType.SelectedValue == "4")
                            { %>
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal8" runat="server" Text="From"></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtFrom" TextMode="Time" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtFrom" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>

                                </div>
                            </div>

                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal9" runat="server" Text="To"></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtTo" TextMode="Time" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtTo" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>


                                    </div>

                                </div>
                            </div>



                        </div>
                        <% } %>

                        <%--  --%>
                        <div class="row mb-3 ms-1">

                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal3" runat="server" Text="Date Of Commencing Leave"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">

                                        <asp:TextBox runat="server" ID="txtDateCommencing" CssClass="form-control form-control-user" TextMode="Date">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDateCommencing" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:Label runat="server" ID="lblDate" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <% if (ddlLeaveType.SelectedValue != "4")
                            { %>
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal4" runat="server" Text="Number Of Dates"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">

                                        <asp:TextBox runat="server" ID="txtNoOfDates" CssClass="form-control form-control-user" TextMode="Number" Step="0.5" min="0" AutoPostBack="true" OnTextChanged="txtNoOfDates_TextChanged">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNoOfDates" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                        <asp:RangeValidator runat="server" ControlToValidate="txtNoOfDates" ErrorMessage="Invalid number"
                                            Type="Integer" MinimumValue="1" MaximumValue="1000" ForeColor="Red"></asp:RangeValidator>

                                    </div>

                                </div>
                            </div>



                        </div>
                        <% } %>

                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal1" runat="server" Text="Date of Resuming"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">

                                        <asp:TextBox runat="server" ID="txtDateResuming" TextMode="Date" CssClass="form-control form-control-user" Enabled="false">
                                        </asp:TextBox>
                                        <% if (ddlLeaveType.SelectedValue != "4")
                                            { %>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDateResuming" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                        <% } %>
                                    </div>

                                </div>
                            </div>



                        </div>

                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal5" runat="server" Text="Reason for Leave"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">

                                        <asp:TextBox runat="server" ID="txtLeaveReason" CssClass="form-control form-control-user" TextMode="MultiLine">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtLeaveReason" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>


                                    </div>

                                </div>
                            </div>
                        </div>


                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal7" runat="server" Text="Upload Leave Form"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:FileUpload ID="Uploader" CssClass="btn" runat="server" AllowMultiple="true" />
                                        <asp:Label ID="lblListOfUploadedFiles" runat="server" />
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">

                                    <div class="col-md-6">
                                        <asp:Button runat="server" ID="btnApplyLeave" Text="Apply Leave " CssClass="form-control form-control-user btn-primary" OnClick="btnApplyLeave_Click" ValidationGroup="1"></asp:Button>

                                    </div>

                                    <div class="col-md-6">
                                        <asp:Button runat="server" ID="btnLeaveBalance" Text="View My Leave Balance " CssClass="form-control form-control-user btn-success" OnClick="btnLeaveBalance_Click"></asp:Button>

                                    </div>

                                </div>
                            </div>



                        </div>
                    </div>

                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnApplyLeave" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
