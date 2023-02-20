<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalFilesList.aspx.cs" Inherits="ManPowerWeb.PersonalFilesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <div class="card p-4 mb-4 mt-5">
            <h2>Personal Files List</h2>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-2 mt-4">
                        <div class="row">
                            <div class="col-4">
                                <asp:TextBox ID="txtName" runat="server" placeholder="Search by Name" CssClass="form-control form-control-user"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txtName" ID="RequiredFieldValidator21" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSearch_Click" ValidationGroup="1" />
                            </div>
                        </div>
                    </div>

                    <div class="ml-3">
                        <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="table-responsive mt-1 mb-4">
                        <asp:GridView ID="gvPersonalFiles" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                            CellPadding="4" ForeColor="#333333" GridLines="None" Style="margin-top: 30px;" EmptyDataText="No data found">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <%--<asp:BoundField DataField="ProgramTargetId" HeaderText="Program Target Id" />
                        <asp:BoundField DataField="ProgramPlanId" HeaderText="Program Plan Id" />--%>

                                <asp:BoundField DataField="EmployeeId" HeaderText="Employee ID" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EmployeeNIC" HeaderText="NIC" HeaderStyle-CssClass="table-dark" />

                                <%--  <asp:TemplateField HeaderText="Project Type">
                            <ItemTemplate>
                                <asp:Label runat="server" Visible='<%#Eval("ProjectTypeId").ToString()=="2"?true:false%>' Text="Physical"></asp:Label>
                                <asp:Label runat="server" Visible='<%#Eval("ProjectTypeId").ToString()=="1"?true:false%>' Text="Online"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                                <asp:BoundField DataField="Title" HeaderText="Title" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="NameWithInitials" HeaderText="Full Name" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EmpInitials" HeaderText="Initials" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EmpGender" HeaderText="Gender" HeaderStyle-CssClass="table-dark" />


                            </Columns>
                        </asp:GridView>
                    </div>

                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSearch" />
                </Triggers>
            </asp:UpdatePanel>

            <div>

                <button runat="server" id="btnRun" onserverclick="btnExportExcel_Click" class="btn btn-success" title="Export To Excel">
                    <i class="fa fa-file-export" style="margin-right: 10px"></i>Export To Excel
                </button>

            </div>
        </div>
    </div>

</asp:Content>
