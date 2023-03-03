<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlanningRecommendation1.aspx.cs" Inherits="ManPowerWeb.PlanningRecommendation1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card m-4 p-4">
        <h2>Program Plan Recommendation </h2>
        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView Style="margin-top: 30px;" ID="gvProgramPlan" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" AllowPaging="true" PageSize="5" HeaderStyle-HorizontalAlign="Center"
                ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                <Columns>
                    <asp:BoundField DataField="ProgramPlanId" HeaderText="ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="ProgramName" HeaderText="Program Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-success" Width="100px" Height="35px" OnClick="btnView_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>No records</EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <div class="card m-4 p-4">
        <h2>Program Plan Details</h2>
        <div class="mt-3">
            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal3" runat="server" Text="Program Name"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtProgramName" CssClass="form-control form-control-user"></asp:TextBox>


                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal4" runat="server" Text="Manager"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtManger" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>


                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>



            </div>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal1" runat="server" Text="Date "></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtDate" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal2" runat="server" Text="Location"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtLocation" CssClass="form-control form-control-user"></asp:TextBox>


                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>



            </div>


            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal10" runat="server" Text="Estimate Amount"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtEstimateAmount" CssClass="form-control form-control-user" TextMode="Number" Enabled="false"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal5" runat="server" Text="Budget"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtBudget" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>

                        </div>
                    </div>
                </div>


            </div>

            <%-- After Complete button content --%>

            <h5><b>Count</b></h5>
            <div class="row mb-3 ms-1">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal6" runat="server" Text="Male Count"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtMaleCount" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal7" runat="server" Text="Female Count"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtFemaleCount" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>

                        </div>
                    </div>
                </div>


            </div>


            <div class="row mb-3 ms-1">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal12" runat="server" Text="Total Count"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtTotalCount" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal8" runat="server" Text="Total Expenditure"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtExpenditure" CssClass="form-control form-control-user"></asp:TextBox>

                        </div>
                    </div>
                </div>




            </div>


            <div class="row mb-3 ms-1">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal13" runat="server" Text="Actual Output"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtActualOutput" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal14" runat="server" Text="Actual Outcome"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtActualOutcome" CssClass="form-control form-control-user"></asp:TextBox>

                        </div>
                    </div>
                </div>


            </div>


            <%-- End After Complete button Content--%>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal11" runat="server" Text="Resource Person"></asp:Literal>
                        </div>
                        <div class="col-md-4">

                            <div class="form-control form-control-user scroll_checkboxes">
                                <asp:CheckBoxList ID="chkList"
                                    runat="server" CssClass="form-control form-control-user"
                                    RepeatDirection="Vertical" RepeatColumns="1"
                                    BorderWidth="0" Datafield="description"
                                    DataValueField="value" Width="250px">
                                </asp:CheckBoxList>

                            </div>
                            <asp:Label ID="lblmsg" class="textcls" runat="server"></asp:Label>

                        </div>
                    </div>
                </div>

            </div>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal9" runat="server" Text="Upload Documnents"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:FileUpload ID="Uploader" CssClass="form-control form-control-user" runat="server" AllowMultiple="true" />
                            <asp:Label ID="lblListOfUploadedFiles" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-5">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-2">
                            <%--                            <asp:Button runat="server" ID="btnSendToRecommendation" Text="Send To Recommendation" CssClass="btn btn-success " OnClick="btnSendToRecommendation_Click" />--%>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
