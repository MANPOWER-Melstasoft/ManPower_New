<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveAllocation.aspx.cs" Inherits="ManPowerWeb.LeaveAllocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>

    <div class="container">
        <asp:UpdatePanel runat="server" ID="updatepannel1">
            <ContentTemplate>
                <div class="card ml-4 p-4">
                    <h2><b>Leave Allocation</b></h2>
                    <div class="mt-3">
                        <div class="row mb-3 ms-1">

                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal3" runat="server" Text="Staff"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddlStaff" CssClass="form-control form-control-user">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal4" runat="server" Text="Leave Type"></asp:Literal>
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

                                        <asp:Literal ID="Literal1" runat="server" Text="Leave Entitlement"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">

                                        <asp:TextBox runat="server" ID="txtEntitlement" TextMode="Number" CssClass="form-control form-control-user">
                                        </asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtEntitlement" runat="server" ErrorMessage="Invalid Range" MinimumValue="0" MaximumValue="365" Type="Integer" ForeColor="Red"></asp:RangeValidator>

                                    </div>

                                </div>
                            </div>



                        </div>
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal2" runat="server" Text="Per Month Limit"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtPerMontLimit" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPerMontLimit" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtPerMontLimit" runat="server" ErrorMessage="Invalid Range" MinimumValue="0" MaximumValue="30" Type="Integer" ForeColor="Red"></asp:RangeValidator>

                                    </div>

                                </div>
                            </div>



                        </div>
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">

                                        <asp:Literal ID="Literal5" runat="server" Text="Per Month Limit Applied To"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtAppliedTo" CssClass="form-control form-control-user" TextMode="Date">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAppliedTo" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>


                                    </div>

                                </div>
                            </div>



                        </div>

                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row">

                                    <div class="col-md-6">
                                        <asp:Button runat="server" ID="btnSaveLeaveAllocation" Text="Save Leave Allocation" CssClass="form-control form-control-user btn-primary" OnClick="btnSaveLeaveAllocation_Click" ValidationGroup="1"></asp:Button>

                                    </div>

                                </div>
                            </div>



                        </div>
                    </div>

                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
