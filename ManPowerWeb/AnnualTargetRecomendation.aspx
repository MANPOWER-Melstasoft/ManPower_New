<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnnualTargetRecomendation.aspx.cs" Inherits="ManPowerWeb.AnnualTargetRecomendation" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mb-3">
        <div class="card p-4">
            <h2>Annual Target Recommendation</h2>

            <div class="row mb-3 ms-1 mt-4">
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-4">
                            <asp:Literal ID="Literal1" runat="server" Text="Status"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control form-control-user" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Pending</asp:ListItem>
                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>


            </div>





            <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="ProgramTargetId" HeaderText="ID" HeaderStyle-CssClass="table-dark"></asp:BoundField>
                        <asp:BoundField DataField="TargetYear" HeaderText="YEAR" HeaderStyle-CssClass="table-dark"></asp:BoundField>

                        <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="TargetMonth">
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
                        <asp:BoundField DataField="Title" HeaderText="Project" HeaderStyle-CssClass="table-dark"></asp:BoundField>


                        <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "0" ?true:false %>' Text="Pending" ForeColor="Blue"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "1" ?true:false %>' Text="Approved" ForeColor="Green"> </asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("IsRecommended").ToString() == "2" ?true:false %>' Text="Rejected" ForeColor="red"> </asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" CssClass="btn btn-success btn-user btn-block" runat="server" Width="100px" Height="35px" Text="View" OnClick="btnView_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
