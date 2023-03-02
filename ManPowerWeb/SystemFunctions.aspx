<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SystemFunctions.aspx.cs" Inherits="ManPowerWeb.SystemFunctions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="card o-hidden border-0 shadow-lg my-3">
        <div class="card-header d-flex align-items-center justify-content-center" style="height: 5%">
            <h5 class="text-center  mt-3 mb-3">System Fuctions</h5>
        </div>

        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm">
                            <div class="table-responsive" style="width: 100%;">

                                <asp:GridView ID="gvSystemFunctions" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                                    HeaderStyle-HorizontalAlign="Center" OnRowEditing="gvSystemFunctions_RowEditing" OnRowCancelingEdit="gvSystemFunctions_RowCancelingEdit"
                                    OnRowUpdating="gvSystemFunctions_RowUpdating">
                                    <Columns>

                                        <%-- <asp:BoundField DataField="AutFunctionId" HeaderText="ID" HeaderStyle-CssClass="table-dark" HeaderStyle-Width="10%">
                                            <HeaderStyle CssClass="table-dark"></HeaderStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="FunctionName" HeaderText="Name" HeaderStyle-CssClass="table-dark" HeaderStyle-Width="20%">
                                            <HeaderStyle CssClass="table-dark"></HeaderStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Url" HeaderText="URL" HeaderStyle-CssClass="table-dark" HeaderStyle-Width="20%">
                                            <HeaderStyle CssClass="table-dark"></HeaderStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="OrderNumber" HeaderText="ORDER" HeaderStyle-CssClass="table-dark" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="table-dark" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="MenuIcon" HeaderText="MenuIcon" HeaderStyle-CssClass="table-dark" HeaderStyle-Width="20%">
                                            <HeaderStyle CssClass="table-dark"></HeaderStyle>
                                        </asp:BoundField>--%>

                                        <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("AutFunctionId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="table-dark" HeaderStyle-Width="18%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("FunctionName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Url" HeaderStyle-CssClass="table-dark" HeaderStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUrl" runat="server" Text='<%#Eval("Url") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="DIVISION" HeaderStyle-CssClass="table-dark" HeaderStyle-Width="13%">

                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "1" ?true:false %>' Text="ADMIN" ForeColor="#cc00cc"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "2" ?true:false %>' Text="PROCRUEMENT" ForeColor="Yellow"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "3" ?true:false %>' Text="FINANCE" ForeColor="#ff9900"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "4" ?true:false %>' Text="PLANING" ForeColor="#009933"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "5" ?true:false %>' Text="IT" ForeColor="Blue"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "-1" ?true:false %>' Text="ALL" ForeColor="Black"> </asp:Label>
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "1" ?true:false %>' Text="ADMIN" ForeColor="#cc00cc"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "2" ?true:false %>' Text="PROCRUEMENT" ForeColor="Yellow"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "3" ?true:false %>' Text="FINANCE" ForeColor="#ff9900"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "4" ?true:false %>' Text="PLANING" ForeColor="#009933"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "5" ?true:false %>' Text="IT" ForeColor="Blue"> </asp:Label>
                                                <asp:Label runat="server" Visible='<%#Eval("division").ToString() == "-1" ?true:false %>' Text="ALL" ForeColor="Black"> </asp:Label>

                                                <asp:DropDownList ID="ddlDivision" runat="server">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="ADMIN" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="PROCRUEMENT" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="FINANCE" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="PLANING" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="IT" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="ALL" Value="-1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Order" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrderNum" runat="server" Text='<%#Eval("OrderNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblOrderNuml" runat="server" Text='<%#Eval("OrderNumber") %>'></asp:Label>
                                                <asp:TextBox ID="txtOrderNum" runat="server" Text='<%#Eval("OrderNumber") %>' Width="100%"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MenuIcon" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMenu" runat="server" Text='<%#Eval("MenuIcon") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblMenul" runat="server" Text='<%#Eval("MenuIcon") %>'></asp:Label>
                                                <asp:TextBox ID="txtMenu" runat="server" Text='<%#Eval("MenuIcon") %>' Width="100%"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField ItemStyle-HorizontalAlign="center">
                                            <HeaderStyle CssClass="table-dark" Width="20%"></HeaderStyle>

                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-info btn-user btn-block">
                                                    <i class="fa fa-pen" aria-hidden="true"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-warning" CommandName="Update" ToolTip="Update">
                                                    <i class="fa fa-check-square" aria-hidden="true"></i>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-danger" CommandName="Cancel" ToolTip="Cancel">
                                                    <i class="fa fa-times" aria-hidden="true"></i>
                                                </asp:LinkButton>
                                            </EditItemTemplate>

                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>
