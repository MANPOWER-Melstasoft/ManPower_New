<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ManPowerWeb.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <div>

        <!-- Page Heading -->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h2 mb-0 text-gray-800">Dashboard</h1>
        </div>

        <!-- Content Row -->
        <div class="row">

            <% if (Session["UserTypeId"].ToString() == "1" || Session["UserTypeId"].ToString() == "2"
                                              || Session["UserTypeId"].ToString() == "3" || Session["UserTypeId"].ToString() == "8")
                {
            %>

            <!-- No of Employees -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <% if (lblNumberOfEmp.Text.ToString() != "0")
                        {
                    %>
                    <a href="UserList.aspx" style="text-decoration: none; cursor: pointer">
                        <%} %>
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                        No of Employees
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                                        <asp:Label ID="lblNumberOfEmp" runat="server" Text="N/A"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-users fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                        <% if (lblNumberOfEmp.Text.ToString() != "0")
                            {
                        %>
                    </a>
                    <%} %>
                </div>
            </div>

            <!-- Completed Programs -->
            <div class="col-xl-3 col-md-6 mb-4">
                <% if (lblCompletedProgrm.Text.ToString() != "0")
                    {
                %>
                <a href="CompletedPrograms.aspx" style="text-decoration: none; cursor: pointer">
                    <%} %>
                    <div class="card border-left-warning shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                        Completed Programs
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                                        <asp:Label ID="lblCompletedProgrm" runat="server" Text="N/A"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <% if (lblCompletedProgrm.Text.ToString() != "0")
                        {
                    %>
                </a>
                <%} %>
            </div>

            <%--<!-- This month Targets -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel6">
                    <ContentTemplate>
                        <div class="card border-left-success shadow h-100 py-2" data-toggle="modal" data-target="#thisMonthTargets" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                            This month Targets
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblThisMonthTarget" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-list fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer6" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!-- Total Vote Allocation -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel5">
                    <ContentTemplate>
                        <div class="card border-left-info shadow h-100 py-2" data-toggle="modal" data-target="#totalVote" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                            Total Vote Allocation
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblVoteAmount" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer5" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!-- Total Programs -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel7">
                    <ContentTemplate>
                        <div class="card border-left-warning shadow h-100 py-2" data-toggle="modal" data-target="#totalProgrm" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                            Total Programs
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblTotalProgramms" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer7" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>


            <%} %>


            <% if (Session["UserTypeId"].ToString() == "3")
                {
            %>
            <!-- Recommendation 1 DME 21 -->
            <div class="col-xl-3 col-md-6 mb-4">
                <% if (lblrec1DME21.Text.ToString() != "0")
                    {%>
                <a href="Recommend1DME21.aspx" style="text-decoration: none; cursor: pointer">
                    <%} %>
                    <div class="card border-left-success shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                        Recommendation 1 DME 21
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                                        <asp:Label ID="lblrec1DME21" runat="server" Text="N/A"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-list fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <% if (lblrec1DME21.Text.ToString() != "0")
                        {%>
                </a>
                <%} %>
            </div>

            <!-- Recommendation 1 DME 22 -->
            <div class="col-xl-3 col-md-6 mb-4">
                <% if (lblrec1DME22.Text.ToString() != "0")
                    {%>
                <a href="dme22rec1.aspx" style="text-decoration: none; cursor: pointer">
                    <%} %>
                    <div class="card border-left-info shadow h-100 py-2" data-toggle="modal">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                        Recommendation 1 DME 22
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                                        <asp:Label ID="lblrec1DME22" runat="server" Text="N/A"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-list fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <% if (lblrec1DME22.Text.ToString() != "0")
                        { %>
                </a>
                <%} %>
            </div>

            <!-- Pending Annual Targets -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel5">
                    <ContentTemplate>
                        <div class="card border-left-primary shadow h-100 py-2" data-toggle="modal" data-target="#PenAnnulTarget" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                            Pending Annual Targets
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblPenAnnTar" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-list fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer5" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <%} %>




            <% if (Session["UserTypeId"].ToString() == "1")
                {
            %>
            <!-- Approve DME 21 -->
            <div class="col-xl-3 col-md-6 mb-4">
                <% if (lblApproveDme21.Text.ToString() != "0")
                    {%>
                <a href="approvedme21.aspx" style="text-decoration: none; cursor: pointer">
                    <%} %>
                    <div class="card border-left-success shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                        Approve DME 21
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                                        <asp:Label ID="lblApproveDme21" runat="server" Text="N/A"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-list fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <% if (lblApproveDme21.Text.ToString() != "0")
                        {%>
                </a>
                <%} %>
            </div>

            <!-- Approve DME 22 -->
            <div class="col-xl-3 col-md-6 mb-4">
                <% if (lblApproveDme22.Text.ToString() != "0")
                    {%>
                <a href="approvedme22.aspx" style="text-decoration: none; cursor: pointer">
                    <%} %>
                    <div class="card border-left-info shadow h-100 py-2" data-toggle="modal">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                        Approve DME 22
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                                        <asp:Label ID="lblApproveDme22" runat="server" Text="N/A"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-list fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <% if (lblApproveDme22.Text.ToString() != "0")
                        { %>
                </a>
                <%} %>
            </div>

            <!-- Recommendation Annual Targets -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel6">
                    <ContentTemplate>
                        <div class="card border-left-primary shadow h-100 py-2" data-toggle="modal" data-target="#RecAnnulTarget" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                            Recommendation Annual Targets
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblRecAnnualTar" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-list fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer6" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <%} %>



            <% if (Session["UserTypeId"].ToString() == "8")
                {
            %>
            <!-- Recommendation 2 DME 21 -->
            <div class="col-xl-3 col-md-6 mb-4">
                <% if (lblRec2Dme21.Text.ToString() != "0")
                    {%>
                <a href="recommend2dme21.aspx" style="text-decoration: none; cursor: pointer">
                    <%} %>
                    <div class="card border-left-success shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                        Recommendation 2 DME 21
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                                        <asp:Label ID="lblRec2Dme21" runat="server" Text="N/A"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-list fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <% if (lblRec2Dme21.Text.ToString() != "0")
                        {%>
                </a>
                <%} %>
            </div>

            <!-- Recommendation 2 DME 22 -->
            <div class="col-xl-3 col-md-6 mb-4">
                <% if (lblRec2Dme22.Text.ToString() != "0")
                    {%>
                <a href="Dme22rec2.aspx" style="text-decoration: none; cursor: pointer">
                    <%} %>
                    <div class="card border-left-info shadow h-100 py-2" data-toggle="modal">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                        Recommendation 2 DME 22
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                                        <asp:Label ID="lblRec2Dme22" runat="server" Text="N/A"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-list fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <% if (lblRec2Dme22.Text.ToString() != "0")
                        { %>
                </a>
                <%} %>
            </div>
            <%} %>



            <!-- Content Row -->
            <% if (Session["UserTypeId"].ToString() == "6"
                                            || Session["UserTypeId"].ToString() == "7" || Session["UserTypeId"].ToString() == "9")
                {
            %>
            <!-- This month Upcoming Programs -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel4">
                    <ContentTemplate>
                        <div class="card border-left-success shadow h-100 py-2" data-toggle="modal" data-target="#thisMonthProgram" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                            This month Upcoming Programs
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblUCTM" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-list fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer4" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!-- No Of Completed Programs -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel3">
                    <ContentTemplate>
                        <div class="card border-left-info shadow h-100 py-2" data-toggle="modal" data-target="#comProgram" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                            No Of Completed Programs
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblCP" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-tasks fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer3" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!-- Total Upcoming Programs -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel2">
                    <ContentTemplate>
                        <div class="card border-left-warning shadow h-100 py-2" data-toggle="modal" data-target="#upcomProgram" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                            Total Upcoming Programs
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblTUCP" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer2" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!--  New Program target-->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel1">
                    <ContentTemplate>
                        <div class="card border-left-primary shadow h-100 py-2" data-toggle="modal" data-target="#newProgramTarget" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                            New Program Target
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblNoOfNewPTarget" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-bullseye fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer1" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel8">
                    <ContentTemplate>
                        <div class="card border-left-primary shadow h-100 py-2" data-toggle="modal" data-target="#AnnualTargetRecommendationApproval" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                            Annual Target Recommendation Approval 
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblAnnualTargetRecommendationApproval" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-bullseye fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer8" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <%} %>


            <!-- Admin widgets -->
            <% if (Session["UserTypeId"].ToString() == "14")
                {
            %>
            <!-- Approved vehicle maintenances -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel12">
                    <ContentTemplate>
                        <div class="card border-left-primary shadow h-100 py-2" data-toggle="modal" data-target="#ApprovedVehicleMaintenances" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                            No of Approved vehicle maintenances
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblAppVehicle" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fa fa-car fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer12" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!-- Approved trainings -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel9">
                    <ContentTemplate>
                        <div class="card border-left-success shadow h-100 py-2" data-toggle="modal" data-target="#ApprovedTrainings" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                            No Of Approved trainings
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblAppTrain" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-list fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer9" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!-- Approved leaves -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel10">
                    <ContentTemplate>
                        <div class="card border-left-info shadow h-100 py-2" data-toggle="modal" data-target="#Approvedleaves" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                            No Of Approved leaves
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblAppLeave" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer10" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!-- Approved Resignations -->
            <div class="col-xl-3 col-md-6 mb-4">
                <asp:UpdatePanel runat="server" ID="updatePanel11">
                    <ContentTemplate>
                        <div class="card border-left-warning shadow h-100 py-2" data-toggle="modal" data-target="#ApprovedResignations" data-ui-class="a-fadeUp" style="cursor: pointer">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                            No Of Approved Resignations
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblAppResign" runat="server" Text="N/A"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Timer ID="timer11" runat="server" OnTick="timer1_Tick" Interval="120000"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <%} %>
        </div>



        <% if (Session["UserTypeId"].ToString() == "6" || Session["UserTypeId"].ToString() == "7"
                                         || Session["UserTypeId"].ToString() == "8" || Session["UserTypeId"].ToString() == "9")
            {
        %>
        <div class="card m-4 p-4">

            <div class="d-sm-flex align-items-center justify-content-between mt-2">
                <h3>Annual Target List
                </h3>
            </div>

            <div class="row">
                <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                    <asp:GridView Style="margin-top: 30px;" ID="gvAnnualTarget" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                        CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="gvAnnualTarget_PageIndexChanging"
                        ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                        <Columns>
                            <asp:BoundField DataField="ProgramTargetId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                            <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                            <asp:BoundField DataField="Outcome" HeaderText="Outcome" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                            <asp:BoundField DataField="NoOfProjects" HeaderText="No of Projects" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                            <asp:BoundField DataField="EstimatedAmount" HeaderText="Estimated Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="Rs {0:N2}" ApplyFormatInEditMode="true" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                            <asp:BoundField DataField="EndDate" HeaderText="End Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                        </Columns>
                        <EmptyDataTemplate>No Programs to Show </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <%} %>


        <% if (Session["UserTypeId"].ToString() == "1" || Session["UserTypeId"].ToString() == "2"
                                          || Session["UserTypeId"].ToString() == "3" || Session["UserTypeId"].ToString() == "8")
            {
        %>
        <div>
            <div class="d-sm-flex align-items-center justify-content-between mt-4">
                <h1 runat="server" id="DME21Heading" class="h4 mb-0 text-gray-800" visible="false">Users who haven't submitted DME 21 for Next Month

                </h1>
            </div>

            <div class="row">
                <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                    <asp:GridView Style="margin-top: 30px;" ID="gvUser" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                        CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="SystemUserId" HeaderText="ID" HeaderStyle-CssClass="table-dark" />
                            <asp:BoundField DataField="Name" HeaderText="NAME" HeaderStyle-CssClass="table-dark" />
                            <asp:BoundField DataField="EmpNumber" HeaderText="EMPLOYEE NUMBER" HeaderStyle-CssClass="table-dark" />
                            <asp:BoundField DataField="Email" HeaderText="EMAIL" HeaderStyle-CssClass="table-dark" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <%} %>
    </div>



    <%--dialog box thisMonthTargets--%>
    <div class="modal" id="thisMonthTargets" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View This month Targets</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvThisMonthTarget"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>

                                <asp:BoundField DataField="ProgramTargetId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Outcome" HeaderText="Outcome" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="NoOfProjects" HeaderText="No of Projects" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EstimatedAmount" HeaderText="Estimated Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="Rs {0:N2}" ApplyFormatInEditMode="true" />

                            </Columns>
                            <EmptyDataTemplate>No This month Targets To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>

    <%--dialog box totalVote--%>
    <div class="modal" id="totalVote" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View Total Vote Allocation</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvVoteAllocation"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="VoteNumber" HeaderText="Vote Number" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="Rs {0:N2}" ApplyFormatInEditMode="true" />
                            </Columns>

                            <EmptyDataTemplate>No Vote Allocation To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>

    <%--dialog box totalProgrm--%>
    <div class="modal" id="totalProgrm" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View Total Programs</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvTotalProgrms"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:BoundField DataField="ProgramTargetId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Outcome" HeaderText="Outcome" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="NoOfProjects" HeaderText="No of Projects" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EstimatedAmount" HeaderText="Estimated Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="Rs {0:N2}" ApplyFormatInEditMode="true" />
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                            </Columns>
                            <EmptyDataTemplate>No Programs to Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>




    <%--dialog box thisMonthProgram--%>
    <div class="modal" id="thisMonthProgram" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View This month Upcoming Programs</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvthisMonthProgram"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:BoundField DataField="ProgramTargetId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Outcome" HeaderText="Outcome" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="NoOfProjects" HeaderText="No of Projects" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EstimatedAmount" HeaderText="Estimated Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="Rs {0:N2}" ApplyFormatInEditMode="true" />
                            </Columns>
                            <EmptyDataTemplate>No This month Upcoming Programs To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>

    <%--dialog box comProgram--%>
    <div class="modal" id="comProgram" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View No Of Completed Programs</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvCompletedProgrm"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>

                                <asp:BoundField DataField="ProgramPlanId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="ProgramTargetId" HeaderText="Target Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="ProgramName" HeaderText="Program Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Location" HeaderText="Location" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="TotalEstimatedAmount" HeaderText="Estimated Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="Rs {0:N2}" ApplyFormatInEditMode="true" />
                                <asp:BoundField DataField="Coordinater" HeaderText="Coordinater" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />

                            </Columns>
                            <EmptyDataTemplate>No Completed Programs To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>

    <%--dialog box upcomProgram--%>
    <div class="modal" id="upcomProgram" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View Total Upcoming Programs</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvTotalUpComingProgrm"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:BoundField DataField="ProgramTargetId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Outcome" HeaderText="Outcome" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="NoOfProjects" HeaderText="No of Projects" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EstimatedAmount" HeaderText="Estimated Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="Rs {0:N2}" ApplyFormatInEditMode="true" />
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />

                            </Columns>
                            <EmptyDataTemplate>No Total Upcoming Programs To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>

    <%--dialog box newProgramTarget--%>
    <div class="modal" id="newProgramTarget" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View New Program Target</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvProgramTargetNotification"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Title" HeaderText="Program Target Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="RecommendedDate" HeaderText="Date Recommended" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_View" runat="server" CssClass="btn btn-success" ToolTip="Mark as Read" OnClick="btn_View_Click"><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No New Program Target To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>





    <%--Planing Admin--%>

    <%--dialog box RecAnnulTarget--%>
    <div class="modal" id="RecAnnulTarget" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View Recommendation Annual Targets</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvRecAnnualTar"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:BoundField DataField="ProgramTargetId" HeaderText="ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="TargetYear" HeaderText="YEAR" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="TargetMonth" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "1" ?true:false %>' Text="January">  </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "2" ?true:false %>' Text="February">  </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "3" ?true:false %>' Text="March"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "4" ?true:false %>' Text="April"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "5" ?true:false %>' Text="May"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "6" ?true:false %>' Text="June"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "7" ?true:false %>' Text="July"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "8" ?true:false %>' Text="August"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "9" ?true:false %>' Text="September"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "10" ?true:false %>' Text="October"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "11" ?true:false %>' Text="November"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "12" ?true:false %>' Text="December"> </asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Title" HeaderText="TITLE" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "0" ?true:false %>' Text="Not Send to Recommendation" ForeColor="Blue"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "1" ?true:false %>' Text="Pending" ForeColor="Blue"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "2" ?true:false %>' Text="Approved" ForeColor="Green"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "3" ?true:false %>' Text="Rejected" ForeColor="red"> </asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Targets to Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>







    <%--Planing User--%>

    <%--dialog box PenAnnulTarget--%>
    <div class="modal" id="PenAnnulTarget" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View Pending Annual Targets</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvPenAnnualTar"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:BoundField DataField="ProgramTargetId" HeaderText="ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="TargetYear" HeaderText="YEAR" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="TargetMonth" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "1" ?true:false %>' Text="January">  </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "2" ?true:false %>' Text="February">  </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "3" ?true:false %>' Text="March"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "4" ?true:false %>' Text="April"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "5" ?true:false %>' Text="May"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "6" ?true:false %>' Text="June"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "7" ?true:false %>' Text="July"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "8" ?true:false %>' Text="August"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "9" ?true:false %>' Text="September"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "10" ?true:false %>' Text="October"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "11" ?true:false %>' Text="November"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("TargetMonth").ToString() == "12" ?true:false %>' Text="December"> </asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Title" HeaderText="TITLE" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "0" ?true:false %>' Text="Not Send to Recommendation" ForeColor="Blue"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "1" ?true:false %>' Text="Pending" ForeColor="Blue"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "2" ?true:false %>' Text="Approved" ForeColor="Green"> </asp:Label>
                                        <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "3" ?true:false %>' Text="Rejected" ForeColor="red"> </asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Targets to Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>








    <%--Admin Widgets--%>

    <%--dialog box ApprovedVehicleMaintenances--%>
    <div class="modal" id="ApprovedVehicleMaintenances" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View No Of Approved Vehicle Maintenances</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvVehicleMain"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>

                                <asp:BoundField DataField="VehicleMeintenanceId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EmpId" HeaderText="EmpId" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="RequestDate" HeaderText="Request Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="ApprovedDate" HeaderText="Approved Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="VehicleNumber" HeaderText="Vehicle Number" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EstimatedCost" HeaderText="Estimated Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="Rs {0:N2}" ApplyFormatInEditMode="true" />

                            </Columns>
                            <EmptyDataTemplate>No This month Targets To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>

    <%--dialog box ApprovedTrainings--%>
    <div class="modal" id="ApprovedTrainings" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View Total Approved Trainings</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvTraininReq"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>

                                <asp:BoundField DataField="TrainingRequestsId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Trainingmain.Title" HeaderText="Title" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="SystemUser.Name" HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Created_Date" HeaderText="Created Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="Accepted_Date" HeaderText="Accepted Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />

                            </Columns>
                            <EmptyDataTemplate>No This month Targets To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>

    <%--dialog box Approvedleaves--%>
    <div class="modal" id="Approvedleaves" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View Total Approved Leaves</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvAppLeave"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:BoundField DataField="StaffLeaveId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="_EMployeeDetails.LastName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="LeaveDate" HeaderText="Leave Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" ApplyFormatInEditMode="true" />
                            </Columns>

                            <EmptyDataTemplate>No Vote Allocation To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>

    <%--dialog box ApprovedResignations--%>
    <div class="modal" id="ApprovedResignations" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">View Total Approved Resignations</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvAppResign"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:BoundField DataField="MainId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="employee.LastName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="ActionTakenDate" HeaderText="Approved Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MMM-yyyy}" />
                            </Columns>
                            <EmptyDataTemplate>No Programs to Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box--%>






    <%--dialog box Annual Target Recommendation Approval--%>
    <div class="modal" id="AnnualTargetRecommendationApproval" role="dialog">
        <div class="modal-dialog modal-lg modal-fullscreen-lg-down">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center">

                    <h4 class="modal-title">Completed Annual Target Recommendation</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:GridView runat="server" ID="gvAnnualTargetSendToRecommendation"
                            Style="margin-top: 30px;" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">

                            <Columns>
                                <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Title" HeaderText="Program Target Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="RecommendedBy" HeaderText="Approved By" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="RecommendedDate" HeaderText="Date Approved" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_View_Annual_Target_Recommendation" runat="server" CssClass="btn btn-success" ToolTip="Mark as Read" OnClick="btn_View_Annual_Target_Recommendation_Click"><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No New Completed Annual Target Recommendation To Show </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <%--end dialog box Annual Target Recommendation Approval--%>
</asp:Content>
