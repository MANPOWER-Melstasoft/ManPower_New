<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecommendTransfersRetirementResignationView.aspx.cs" Inherits="ManPowerWeb.RecommendTransfersRetirementResignationView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mb-3" id="mainContainer" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <div class="card ml-4 p-4">
            <h2>
                <asp:Label ID="heading" runat="server" Text="N/A"></asp:Label>
            </h2>
            <br />
            <div class="form-group">

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <div class="row mb-3 ms-1 mt-4">
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal1" runat="server" Text="Emp Number : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblEmpNumber" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal2" runat="server" Text="Emp Name : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblEmpName" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row mb-3 ms-1 mt-4">
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal3" runat="server" Text="Current Work Place : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblDepartment" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal4" runat="server" Text="Designation : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblDesignation" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">

                                        <asp:Literal ID="Literal17" runat="server" Text="Request Type : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblRequestType" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%----------------------------------transferDiv------------------------------------------%>

                        <div runat="server" id="transferDiv" visible="false">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal5" runat="server" Text="Transfer Type : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTransferType" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="lblDepartmentType" runat="server" Text="Preferred Work Place : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblNewDapartment" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-3 ms-1" id="FromToDate" runat="server" visible="false">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal21" runat="server" Text="From Date : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="fromDate" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal22" runat="server" Text="To Date : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="toDate" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal6" runat="server" Text="Reason : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTransferReason" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%----------------------------------retirementDiv------------------------------------------%>

                        <div runat="server" id="retirementDiv" visible="false">
                            <div class="row mb-3">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal19" runat="server" Text="First Appointment Date : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblJoinedDate" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">

                                            <asp:Literal ID="Literal20" runat="server" Text="DOB : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblDob" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal7" runat="server" Text="Retirement Type : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblRetirementType" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <%if (lblRetirementType.Text == "Other")
                                    { %>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal9" runat="server" Text="Other : "></asp:Literal>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="lblRetirementOther" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <%} %>
                            </div>

                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal12" runat="server" Text="Reason : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblRetirementReason" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal13" runat="server" Text="Remark : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblRetirementRemark" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <%----------------------------------resignationDiv------------------------------------------%>

                        <div runat="server" id="resignationDiv" visible="false">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">

                                            <asp:Literal ID="Literal8" runat="server" Text="Date : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblResignationDate" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">

                                            <asp:Literal ID="Literal10" runat="server" Text="Reason : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblResignationReason" runat="server" Text="N/A" Width="250px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row mb-5">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal11" runat="server" Text="Upload Documnents"></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblDocument" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                    <%if (lblDocument.Text != "" && lblDocument.Text != null)
                                        { %>
                                    <div class="col-sm-4">
                                        <asp:Button runat="server" ID="btnView" Text="View Document" CssClass="btn btn-secondary btn-user btn-block" OnClick="btnView_Click" />
                                    </div>
                                    <%}  %>
                                </div>
                            </div>
                        </div>


                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal14" runat="server" Text="Update Status : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddlUpdateStatus" runat="server" Width="250px" CssClass="form-control form-control-user" AutoPostBack="true" OnSelectedIndexChanged="ddlUpdateStatus_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="1" ControlToValidate="ddlUpdateStatus" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div id="sendtoapp" runat="server" visible="false">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal18" runat="server" Text="Action : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlAction" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="1" ControlToValidate="ddlAction" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal21" runat="server" Text="Assign User : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlAssignUser" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="1" ControlToValidate="ddlAssignUser" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>

                        <div id="reverse" runat="server" visible="false">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal15" runat="server" Text="Reason : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlReverseReason" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="1" ControlToValidate="ddlReverseReason" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="lblReveresRemerks" runat="server" Text="Remark : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtReverseRemarks" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="reject" runat="server" visible="false">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <div class="row mb-3">
                                        <div class="col-sm-4">
                                            <asp:Literal ID="Literal16" runat="server" Text="Reject Remark : "></asp:Literal>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtRejectRemark" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6 d-flex">
                                <div class="col-sm-4">
                                    <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="btnBack_Click" />
                                </div>
                                <div class="col-sm-4">
                                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmit_Click" ValidateRequestMode="Enabled" ValidationGroup="1" />
                                </div>
                            </div>
                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnView" />
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                        <asp:PostBackTrigger ControlID="btnBack" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>

</asp:Content>
