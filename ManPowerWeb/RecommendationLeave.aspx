<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecommendationLeave.aspx.cs" Inherits="ManPowerWeb.RecommendationLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card  p-4">
            <h2>Leave Recommendation</h2>


            <div class="mt-3">


                <div class="row mb-3 ms-1">

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal3" runat="server" Text="HO DIvision"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlHo" runat="server" CssClass="form-control form-control-user">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal1" runat="server" Text="District"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control form-control-user" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>





                </div>
                <div class="row mb-3 ms-1">



                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal4" runat="server" Text="DS Division"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlDS" runat="server" CssClass="form-control form-control-user">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                            </div>
                        </div>
                    </div>



                </div>



                <div class="row mb-5 ms-1 mt-4">
                    <div class="col-sm-2">

                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Search" OnClick="btnSearch_Click" />


                    </div>
                </div>

            </div>


        </div>


        <div class="table-responsive">
            <asp:GridView Style="margin-top: 30px;" ID="gvApproveLeave" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="gvApproveLeave_RowDataBound"
                AllowPaging="true" OnPageIndexChanging="gvApproveLeave_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="CREATE DATE" DataField="CreatedDate" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="CONSUMING DATE" DataField="LeaveDate" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField=" _EMployeeDetails.EmployeeNIC" HeaderText="NIC" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField=" _EMployeeDetails.EmpInitials" HeaderText="INITIAL NAME" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField=" _EMployeeDetails.LastName" HeaderText="LAST NAME" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="STATUS" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "5" ?true:false %>' Text="Rejected" ForeColor="Red">  </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "2" ?true:false %>' Text="Send to Recommendation" ForeColor="YellowGreen">  </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "3" ?true:false %>' Text="Send to Approval" ForeColor="YellowGreen">  </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "1" ?true:false %>' Text="Pending" ForeColor="Green">  </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "4" ?true:false %>' Text="Approved" ForeColor="Blue">  </asp:Label>


                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="View" ID="btnView" CssClass="btn btn-success btn-user btn-block" Width="100px" Height="35px" OnClick="btnView_Click">

                            </asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>
