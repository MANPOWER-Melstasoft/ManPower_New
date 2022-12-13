<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="planning.aspx.cs" Inherits="ManPowerWeb.planning" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="card ml-4 p-4">
            <h2><b>Program Planning</b></h2>
            <div class="mt-3">
                <div class="row mb-3 ms-1">

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal3" runat="server" Text="Annual Plan"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtAnnualPlanCount" CssClass="form-control form-control-user"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal4" runat="server" Text="Program Plan"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtProgramPlanCount" CssClass="form-control form-control-user"></asp:TextBox>

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

                                <asp:Literal ID="Literal1" runat="server" Text="Not Program "></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtNotProgramCount" CssClass="form-control form-control-user"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal2" runat="server" Text="Completed Plan"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtCompletedCount" CssClass="form-control form-control-user"></asp:TextBox>

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

                                <asp:Literal ID="Literal5" runat="server" Text="Search"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddlSearch" CssClass="form-control form-control-user"></asp:DropDownList>
                            </div>
                        </div>
                    </div>





                </div>
            </div>

        </div>

        <%--        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView Style="margin-top: 30px;" ID="gvAnnualPlan" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" OnRowDataBound="gvAnnualPlan_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <img alt="" style="cursor: pointer; margin-top: -6px" src="images/plus.png" />
                            <asp:Panel ID="pnlPlandetails" runat="server">
                                <asp:GridView runat="server" ID="gvPlanDetails" CssClass="table table-responsive ChildGrid" EmptyDataText="No Data found">
                                    <Columns>
                                        <asp:BoundField DataField="Description" HeaderText="PROGRAM NAME" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                        <asp:BoundField HeaderText="REPORTING MANGER" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />

                                        <asp:BoundField HeaderText="DATE" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                        <asp:TemplateField HeaderText="ACTION" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center">
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Description" HeaderText="PROGRAM NAME" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField HeaderText="REPORTING MANGER" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />

                    <asp:BoundField HeaderText="DATE" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:TemplateField HeaderText="ACTION" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnAddPlan" CssClass="btn btn-success" OnClick="btnAddPlan_Click">Add Program Plan</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnEdit" CssClass="btn btn-warning" OnClick="btnEdit_Click">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>--%>

        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView ID="gvAnnaualPlan" runat="server" AutoGenerateColumns="false" CssClass=" table-responsive table-bordered mt-4"
                DataKeyNames="ProgramTargetId" OnRowDataBound="gvAnnaualPlan_RowDataBound" GridLines="None" HeaderStyle-CssClass="GridHeader" headerstyle->
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <a href="javascript:collapseExpand('ProgramTargetId-<%# Eval("ProgramTargetId") %>');">
                                <img alt="Details" id="imageProgramTargetId-<%# Eval("ProgramTargetId") %> " src="img/plus.png" border="0" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="_ProgramTarget.Description" HeaderText="Description" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.TargetYear" HeaderText="Target Year" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.TargetMonth" HeaderText="Target Month" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField HeaderText="Target Count" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField HeaderText="Planned Count" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:TemplateField HeaderText="ACTION" HeaderStyle-Width="300px" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnAddPlan" CssClass="btn btn-success" OnClick="btnAddPlan_Click">Add Program Plan</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan=" 100%">
                                    <div id="ProgramTargetId-<%# Eval("ProgramTargetId") %>" style="display: none; position: relative; left: 25px">
                                        <asp:GridView ID="gvPlanDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive ChildGrid" EmptyDataText="No Item Found">
                                            <Columns>
                                                <asp:BoundField DataField="Date" HeaderStyle-CssClass="table-dark" HeaderText="Date" />
                                                <asp:BoundField DataField="Location" HeaderStyle-CssClass="table-dark" HeaderText="Location" />
                                                <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible='<%#Eval("ProjectStatusId").ToString() == "1" ?true:false %>' Text="Pending" ForeColor="red"> </asp:Label>
                                                        <asp:Label runat="server" Visible='<%#Eval("ProjectStatusId").ToString() == "2" ?true:false %>' Text="In Progress" ForeColor="Blue"> </asp:Label>
                                                        <asp:Label runat="server" Visible='<%#Eval("ProjectStatusId").ToString() == "3" ?true:false %>' Text="Hold" ForeColor="Yellow"> </asp:Label>
                                                        <asp:Label runat="server" Visible='<%#Eval("ProjectStatusId").ToString() == "4" ?true:false %>' Text="Complete" ForeColor="Green"> </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ACTION" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnEdit" CssClass="btn btn-warning" OnClick="btnEdit_Click" Enabled='<%#Eval("ProjectStatusId").ToString() != "4" ?true:false %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>




    <script type="text/javascript">

        function collapseExpand(obj) {

            var gvObject = document.getElementById(obj);

            var imageID = document.getElementById('image' + obj);



            if (gvObject.style.display == "none") {

                gvObject.style.display = "inline";

                imageID.src = "img/minus.png";

            }

            else {

                gvObject.style.display = "none";

                imageID.src = "img/plus.png";

            }

        }

    </script>

</asp:Content>
