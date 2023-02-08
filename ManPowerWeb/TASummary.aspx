<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TASummary.aspx.cs" Inherits="ManPowerWeb.TASummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <div class="card p-4 mb-4 mt-5">
            <h2>Target Achievement Individual Summary</h2>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-4 mt-4">
                        <div class="row">
                            <div class="col-4">
                                <asp:TextBox ID="txtName" runat="server" placeholder="Search by Name" CssClass="form-control form-control-user"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <asp:TextBox ID="txtLocation" runat="server" placeholder="Search by Location" CssClass="form-control form-control-user"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnGetAll" runat="server" Text="Get All" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGetAll_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="table-responsive mt-5 mb-4">
                        <asp:Table ID="tblTaSummary" runat="server" CssClass="table table-bordered"></asp:Table>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>



            <div class="table-responsive mt-4 mb-4">
                <asp:GridView ID="gvIndividualTASummary" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" OnDataBound="gvIndividualTASummary_DataBound" OnRowCreated="gvIndividualTASummary_RowCreated" OnRowDataBound="gvIndividualTASummary_RowDataBound">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <%--<asp:BoundField DataField="ProgramTargetId" HeaderText="Program Target Id" />
                        <asp:BoundField DataField="ProgramPlanId" HeaderText="Program Plan Id" />--%>

                        <asp:BoundField DataField="ProgramTargetName" HeaderText="Program Name" />
                        <asp:BoundField DataField="Target" HeaderText="Target" />

                        <%--  <asp:TemplateField HeaderText="Project Type">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("ProjectTypeId").ToString()=="2"?true:false%>' Text="Physical"></asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("ProjectTypeId").ToString()=="1"?true:false%>' Text="Online"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:BoundField DataField="OnlineCount" HeaderText="Online" />
                        <asp:BoundField DataField="PhysicalCount" HeaderText="Physical" />
                        <asp:BoundField HeaderText="Total" />

                        <%--<asp:BoundField DataField="Achievement" HeaderText="Achievment" />--%>

                        <asp:BoundField DataField="NoOfBeneficiary" HeaderText="No. of beneficiaries" />
                        <asp:BoundField DataField="OfficerName" HeaderText="Name" />
                        <asp:BoundField DataField="Location" HeaderText="Location" />
                    </Columns>
                </asp:GridView>
            </div>

            <div>

                <button runat="server" id="btnRun" onserverclick="btnExportExcel_Click" class="btn btn-success" title="Export To Excel">
                    <i class="fa fa-file-export" style="margin-right: 10px"></i>Export To Excel
                </button>

            </div>
        </div>
    </div>
</asp:Content>
