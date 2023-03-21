<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnnualTargetView.aspx.cs" Inherits="ManPowerWeb.AnnualTargetView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container mb-3" id="mainContainer" runat="server">


        <div class="card ml-4 p-4">
            <h2>View Annual Targets</h2>
            <br />
            <div class="form-group">

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal1" runat="server" Text="Year"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtlYear" runat="server" CssClass="form-control form-control-user" Width="250px" Enabled="false">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal2" runat="server" Text="Target"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:RadioButtonList ID="rbTarget" runat="server" AutoPostBack="true" Enabled="false">
                                    <asp:ListItem Value="1">District Level</asp:ListItem>
                                    <asp:ListItem Value="2">DS Division Level</asp:ListItem>
                                    <%--   <div class="mr-5">
                                    <%--<asp:RadioButton ID="rbDistrictLevel" runat="server" Text="District Level" GroupName="Target" />-%>
                                </div>
                                <div>
                                    <%--<asp:RadioButton ID="rbDsDivisonLevel" runat="server" Text="DS Division Level" GroupName="Target" />
                                </div>--%>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>

                <%--     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal3" runat="server" Text="District"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control form-control-user" Width="250px" AutoPostBack="true" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <%--    <%if (rbTarget.SelectedValue == "2")
                                { %>--%>

                    <div class="col-sm-6" id="hideDiv" runat="server">
                        <div class="row mb-3" runat="server" id="rowDsDivision">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal4" runat="server" Text="DS Division"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlDSDivision" runat="server" CssClass="form-control form-control-user" Width="250px" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <%--       <%} %>--%>
                </div>
                <%--   </ContentTemplate>
                </asp:UpdatePanel>--%>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal5" runat="server" Text="Position"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control form-control-user" Width="250px" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal6" runat="server" Text="Officer Name"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblofficer" runat="server" CssClass="form-control form-control-user" Width="250px" ReadOnly="true">
                                </asp:Label>
                            </div>
                        </div>
                    </div>
                </div>


                <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal7" runat="server" Text="Program Type"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlProgramType" runat="server" CssClass="form-control form-control-user" Width="250px" Enabled="false">
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal9" runat="server" Text="Program"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control form-control-user" Width="250px" Enabled="false">
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>

                </div>


                <div class="row mb-3 ms-1">

                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal8" runat="server" Text="Instructions"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtInstructions" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal10" runat="server" Text="Description"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row mb-3 ms-1">

                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal17" runat="server" Text="Vote"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtVote" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal23" runat="server" Text="Type"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblType" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:Label>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="row mb-3 ms-1" runat="server" id="divMonth">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal19" runat="server" Text="Start Date"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtStratDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="Date" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal20" runat="server" Text="End Date"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtEndDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="Date" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>


                <%--//=================================--%>



                <h5>Target: physical / financial :</h5>
                <br />


                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3" runat="server" id="rowMonth" visible="false">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal11" runat="server" Text="Month"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control form-control-user" Width="250px" Enabled="false">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                </div>


                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal14" runat="server" Text="Physical Count"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPhysicalCount" Width="250px" runat="server" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal15" runat="server" Text="Financial Count"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtFinancialCount" runat="server" CssClass="form-control form-control-user" Width="250px" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>

                <h5>Expected Output :</h5>
                <br />

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal12" runat="server" Text="Output"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtOutput" runat="server" CssClass="form-control form-control-user" Width="250px" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal22" runat="server" Text="Output Description"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtOutputDes" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>


                            </div>
                        </div>

                    </div>
                </div>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal13" runat="server" Text="Outcome"></asp:Literal>

                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtOutcome" runat="server" CssClass="form-control form-control-user" Width="250px" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal21" runat="server" Text="Outcome Description"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtOutcomeDes" runat="server" CssClass="form-control form-control-user" Width="250px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>


                            </div>
                        </div>

                    </div>
                </div>
                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal16" runat="server" Text="Remarks"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control form-control-user" Width="250px" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-3 ms-1" runat="server" id="rowRejectRemarks" visible="false">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal18" runat="server" Text="Reject Remarks"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtRejectRemarks" runat="server" CssClass="form-control form-control-user" Width="250px" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>



                <div class="row mb-3 ms-1">
                    <div class="col-sm-6 d-flex">
                        <div class="col-sm-4">
                            <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="btnBack_Click" />
                        </div>

                        <div class="col-sm-6">
                            <button runat="server" type="button" id="btnSendToRecommendation" class="btn btn-primary btn-user btn-block" data-toggle="modal" data-target="#myModal" visible="false">Send to Recomendation</button>

                        </div>

                    </div>

                </div>
            </div>
        </div>

    </div>


    <%---------------------dialog box----------------------%>



    <!-- Trigger the modal with a button -->

    <!-- Modal -->
    <div class="modal fade-out" id="myModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">Recommondation</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <label><b>Recommondation Type</b></label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control form-control-user">
                            <asp:ListItem Value="1">Send to recommondation</asp:ListItem>
                            <%--<asp:ListItem Value="2">Send to approval</asp:ListItem>--%>
                        </asp:DropDownList>


                        <br />
                        <br />

                        <label><b>Officer Name</b></label>

                        <asp:DropDownList ID="ddlOficerRecomended" runat="server" CssClass="form-control form-control-user"></asp:DropDownList>
                    </div>




                </div>
                <div class="modal-footer">

                    <div class="col-4">
                        <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn btn-success btn-user btn-block" OnClick="btnSend_Click" />
                    </div>


                </div>
            </div>

        </div>
    </div>


    <%--------------end of dialog box--------------------%>
</asp:Content>
