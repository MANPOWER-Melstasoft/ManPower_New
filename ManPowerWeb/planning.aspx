<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="planning.aspx.cs" Inherits="ManPowerWeb.planning" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="card  p-4">
            <h2><b>Program Planning</b></h2>
            <div class="mt-3">
                <div class="row mb-3 ms-1">

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal3" runat="server" Text="Year"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control form-control-user">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal4" runat="server" Text="Month"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddlMonth" CssClass="form-control form-control-user">
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
                            <div class="col-md-2">
                            </div>
                        </div>
                    </div>



                </div>

                <div class="row mb-3 ms-1">

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col">

                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click"></asp:Button>
                            </div>
                            <div class="col">

                                <asp:Button runat="server" ID="btnShowAll" CssClass="btn btn-primary" Text="Show All" OnClick="btnShowAll_Click"></asp:Button>
                            </div>

                        </div>
                    </div>





                </div>



            </div>

        </div>



        <div class="table-responsive">
            <asp:GridView ID="gvAnnaualPlan" runat="server" AutoGenerateColumns="false" CssClass=" table-responsive table-bordered mt-4 ParentGrid"
                DataKeyNames="ProgramTargetId" OnRowDataBound="gvAnnaualPlan_RowDataBound" GridLines="None" HeaderStyle-CssClass="GridHeader" HeaderStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <a href="javascript:collapseExpand('ProgramTargetId-<%# Eval("ProgramTargetId") %>');">
                                <img alt="Details" id="imageProgramTargetId-<%# Eval("ProgramTargetId") %> " src="img/plus.png" border="0" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="_ProgramTarget.ProgramTargetId" HeaderText="Id" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.Description" HeaderText="Description" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.TargetYear" HeaderText="Target Year" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.TargetMonth" HeaderText="Target Month" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.StartDate" HeaderText="Start Date" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.EndDate" HeaderText="Start Date" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.EstimatedAmount" HeaderText="Estimate Amount" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.Instractions" HeaderText="Instruction" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="_ProgramTarget.NoOfProjects" HeaderText="No of Projects" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                    <asp:TemplateField HeaderText="Planned Count" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPlannedCount"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ACTION" HeaderStyle-Width="300px" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnAddPlan" CssClass="btn btn-success" OnClick="btnAddPlan_Click">Add Program Plan</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan="10">
                                    <div id="ProgramTargetId-<%# Eval("ProgramTargetId") %>" style="display: none; position: relative">
                                        <asp:GridView ID="gvPlanDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive ChildGrid" EmptyDataText="No Item Found" DataKeyNames="ProgramTargetId">
                                            <Columns>
                                                <asp:BoundField DataField="ProgramPlanId" HeaderStyle-CssClass="table-dark" HeaderText="Program Plan Id" />
                                                <asp:BoundField DataField="ProgramName" HeaderStyle-CssClass="table-dark" HeaderText="Program Name" />
                                                <asp:BoundField DataField="Date" HeaderStyle-CssClass="table-dark" HeaderText="Date" />
                                                <asp:BoundField DataField="Location" HeaderStyle-CssClass="table-dark" HeaderText="Location" />
                                                <asp:BoundField DataField="MaleCount" HeaderStyle-CssClass="table-dark" HeaderText="Male Count" />
                                                <asp:BoundField DataField="FemaleCount" HeaderStyle-CssClass="table-dark" HeaderText="Female Count" />
                                                <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible='<%#Eval("ProjectStatusId").ToString() == "1" ?true:false %>' Text="Pending" ForeColor="red"> </asp:Label>
                                                        <asp:Label runat="server" Visible='<%#Eval("ProjectStatusId").ToString() == "2" ?true:false %>' Text="In Progress" ForeColor="Blue"> </asp:Label>
                                                        <asp:Label runat="server" Visible='<%#Eval("ProjectStatusId").ToString() == "3" ?true:false %>' Text="Hold" ForeColor="Yellow"> </asp:Label>
                                                        <asp:Label runat="server" Visible='<%#Eval("ProjectStatusId").ToString() == "4" ?true:false %>' Text="Complete" ForeColor="Green"> </asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ACTION" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" CommandName="Edit" ID="btnEdit" CssClass="btn btn-warning" OnClick="btnEdit_Click" Enabled='<%#Eval("ProjectStatusId").ToString() != "4" ?true:false %>'>Edit</asp:LinkButton>
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

                imageID.src = "img/minus.png";

            }

        }

    </script>




    <style type="text/css">
        .ChildGrid td {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
            text-align: center;
            border-color: black
        }

        .ChildGrid th {
            color: White;
            font-size: 10pt;
            line-height: 200%;
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: center;
            background-color: #67778e !important;
            color: white;
        }

        .ParentGrid td {
            background-color: white;
            color: black;
            font-size: 10pt;
            line-height: 200%;
            text-align: center;
        }

        .ParentGrid th {
            color: White;
            font-size: 10pt;
            line-height: 200%;
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: center;
        }
    </style>

</asp:Content>
