<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransfersRetirementResignation.aspx.cs" Inherits="ManPowerWeb.TransfersRetirementResignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="card p-4">
                    <h2>Transfers </h2>

                    <div class="mt-3">

                        <div class="row mb-3 ms-1 mt-3">

                            <div class="col-sm-2">
                                <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control form-control-user" OnSelectedIndexChanged="ddltype_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-control-user" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>

                            <div class="col-sm-2"></div>

                            <div class="col-sm-4 align-content-end">
                                <asp:Button ID="btnAddNewTarget" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Add New Transfers" OnClick="btnAddNewTarget_Click" />
                            </div>
                        </div>


                    </div>
                </div>

                <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">

                    <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                        CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" HeaderStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="MainId" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                            <asp:BoundField DataField="RequestType.RequestTypeName" HeaderText="Request Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />

                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status" HeaderStyle-CssClass="table-dark">
                                <ItemTemplate>
                                    <asp:Label runat="server" Visible='<%#Eval("Status.StatusName").ToString() == "Pending" ?true:false %>' Text="Pending" ForeColor="Blue"> </asp:Label>
                                    <asp:Label runat="server" Visible='<%#Eval("Status.StatusName").ToString() == "Approved" ?true:false %>' Text="Approved" ForeColor="Green"> </asp:Label>
                                    <asp:Label runat="server" Visible='<%#Eval("Status.StatusName").ToString() == "Reverse" ?true:false %>' Text="Reverse" ForeColor="Orange"> </asp:Label>
                                    <asp:Label runat="server" Visible='<%#Eval("Status.StatusName").ToString() == "Rejected" ?true:false %>' Text="Rejected" ForeColor="red"> </asp:Label>
                                    <asp:Label runat="server" Visible='<%#Eval("Status.StatusName").ToString() == "Send to Approval" ?true:false %>' Text="Send to Approval" ForeColor="Black"> </asp:Label>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
