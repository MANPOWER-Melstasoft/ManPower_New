<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProgramTargetView.aspx.cs" Inherits="ManPowerWeb.ProgramTargetView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mb-3" id="mainContainer" runat="server">
            <h2>View Program Target</h2>
            <br /><br />
            <div class="form-group">

                <%--<div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal1" runat="server" Text="Year"></asp:Literal>
                            </div>
                             <div class="col-md-4">
                                <asp:TextBox ID="year" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>--%>

                    <%--<div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal2" runat="server" Text="Target"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="select" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal3" runat="server" Text="District"></asp:Literal>
                            </div>
                             <div class="col-md-4">
                                <asp:TextBox ID="des" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6" id="hideDiv" runat="server">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal4" runat="server" Text="DS Division"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="ds" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal5" runat="server" Text="Position"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="position" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal6" runat="server" Text="Officer Name"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="officer" runat="server" Width="250px" CssClass="form-control form-control-user"  ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>--%>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal7" runat="server" Text="Program Type"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="type" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal9" runat="server" Text="Program"></asp:Literal>
                            </div>
                           <div class="col-md-4">
                                <asp:TextBox ID="programName" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
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

                </div>



                <%--//=================================--%>


                <br />
                <h5><b>Target: physical / financial :</b></h5>
                <br />

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal2" runat="server" Text="Year"></asp:Literal>
                            </div>
                             <div class="col-md-4">
                                <asp:TextBox ID="year" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-4">
                                <asp:Literal ID="Literal11" runat="server" Text="Month"></asp:Literal>
                            </div>
                             <div class="col-md-4">
                                <asp:TextBox ID="month" runat="server" Width="250px" CssClass="form-control form-control-user" ReadOnly="true"></asp:TextBox>
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

                <br />

                <h5><b>Expected Output :</b></h5>
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


                <div class="row mb-3 ms-1">
                    <div class="col-sm-6 d-flex">
                        <div class="col-sm-6">
                            <asp:Button runat="server" ID="btnCancel" Text="Go to Annual Targets" OnClick="ToAnnualTarget" CssClass="btn btn-primary btn-user btn-block"  />
                        </div>
                        <div class="col-sm-6">
                            <asp:Button runat="server" ID="Button1" Text="Go to Upcoming Programs" OnClick="ToUpcommingProgram" CssClass="btn btn-primary btn-user btn-block"  />
                        </div>
                    </div>

                </div>
            </div>
    </div>

</asp:Content>
