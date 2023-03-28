<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnnualTarget.aspx.cs" Inherits="ManPowerWeb.AnnualTarget" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4">
            <h2>Annual Targets</h2>

            <div class="mt-3">
                <div class="row mb-3 ms-1">

                    <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-3">

                                <asp:Literal ID="Literal1" runat="server" Text="Year"></asp:Literal>
                            </div>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="form-control form-control-user">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-3">

                                <asp:Literal ID="Literal2" runat="server" Text="Month"></asp:Literal>
                            </div>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control form-control-user">
                                    <asp:ListItem Value="">Select Month</asp:ListItem>
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
                <div class="row mb-3 ms-1 mt-4">

                    <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="Search" OnClick="btnSearch_Click" />
                            </div>

                            <div class="col-sm-6">
                                <asp:Button ID="btnShowAll" runat="server" CssClass="btn btn- btn-primary " Text="Show All" OnClick="btnShowAll_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mb-3 ms-1 mt-4">

                    <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-3">

                                <asp:Literal ID="Literal3" runat="server" Text="Status"></asp:Literal>
                            </div>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-control-user" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="">Select Status</asp:ListItem>
                                    <asp:ListItem Value="0">Not Recommended</asp:ListItem>
                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                    <asp:ListItem Value="2">Approved</asp:ListItem>
                                    <asp:ListItem Value="3">Reject</asp:ListItem>
                                    <asp:ListItem Value="4">All</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>




                </div>

                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-3 mt-4">
                        <asp:Button ID="btnAddNewTarget" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Add New Target" OnClick="btnAddNewTarget_Click" />
                    </div>
                </div>


            </div>
        </div>

        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" HeaderStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="ProgramTargetId" HeaderText="ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="TargetYear" HeaderText="YEAR" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
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
                    <asp:BoundField DataField="StartDate" HeaderText="START DATE" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="EndDate" HeaderText="END DATE" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />

                    <asp:BoundField DataField="Description" HeaderText="DESCRIPTION" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="Title" HeaderText="TITLE" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "0" ?true:false %>' Text="Not Send to Recommendation" ForeColor="Blue"> </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "1" ?true:false %>' Text="Pending" ForeColor="Blue"> </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "2" ?true:false %>' Text="Approved" ForeColor="Green"> </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "3" ?true:false %>' Text="Rejected" ForeColor="red"> </asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-success" Width="100px" Height="35px" OnClick="btnView_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


    </div>
</asp:Content>
