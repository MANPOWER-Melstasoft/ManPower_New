<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecommendationLapsedLeave.aspx.cs" Inherits="ManPowerWeb.RecommendationLapsedLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card  p-4">
            <h2>Lapsed Leave Recommendation</h2>
        </div>

        <div class="table-responsive">
            <asp:GridView Style="margin-top: 30px;" ID="gvApproveLeave" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="gvApproveLeave_RowDataBound"
                AllowPaging="true" OnPageIndexChanging="gvApproveLeave_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="FROM DATE" DataField="FromTime" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="TO DATE" DataField="ToTime" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
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
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "6" ?true:false %>' Text="Send to Recommendation" ForeColor="YellowGreen">  </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "7" ?true:false %>' Text="Send to Recommendation Admin Clerk" ForeColor="YellowGreen">  </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "8" ?true:false %>' Text="Send to Recommendation Assistance Director" ForeColor="YellowGreen">  </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "9" ?true:false %>' Text="Send to Recommendation Director" ForeColor="YellowGreen">  </asp:Label>
                            <asp:Label runat="server" Visible='<%#Eval("LeaveStatusId").ToString() == "10" ?true:false %>' Text="Send to Recommendation DG" ForeColor="YellowGreen">  </asp:Label>

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
