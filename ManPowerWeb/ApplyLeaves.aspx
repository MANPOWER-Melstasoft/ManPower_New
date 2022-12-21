<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplyLeaves.aspx.cs" Inherits="ManPowerWeb.ApplyLeaves" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card ml-4 p-4">
            <h2><b>Apply Leave</b></h2>
            <div class="mt-3">
                <div class="row mb-3 ms-1">

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-6">

                                <asp:Literal ID="Literal3" runat="server" Text="Date Of Commencing Leave"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox runat="server" ID="txtDateCommencing" CssClass="form-control form-control-user" TextMode="Date">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-6">

                                <asp:Literal ID="Literal4" runat="server" Text="Number Of Dates"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox runat="server" ID="txtNoOfDates" CssClass="form-control form-control-user" TextMode="Number" min="0">
                                </asp:TextBox>

                            </div>

                        </div>
                    </div>



                </div>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-6">

                                <asp:Literal ID="Literal1" runat="server" Text="Date of Resuming"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox runat="server" ID="txtDateResuming" CssClass="form-control form-control-user">
                                </asp:TextBox>

                            </div>

                        </div>
                    </div>



                </div>
                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-6">

                                <asp:Literal ID="Literal2" runat="server" Text="Leave Type"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlLeaveType" CssClass="form-control form-control-user">
                                </asp:DropDownList>

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

                            </div>

                        </div>
                    </div>



                </div>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row">

                            <div class="col-md-6">
                                <asp:Button runat="server" ID="btnApplyLeave" Text="Apply Leave " CssClass="form-control form-control-user btn-primary"></asp:Button>

                            </div>

                        </div>
                    </div>



                </div>
            </div>

        </div>
    </div>
</asp:Content>
