<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestTraining.aspx.cs" Inherits="ManPowerWeb.RequestTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Request Training</h2>
        <div class="card-body">
            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblDate" runat="server" Text="Date :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <input id="txtDate" runat="server" type="date" style="width: 100%; height: 40px; border-radius: 5px; padding-left: 10px;" />
                        </div>
                    </div>

                </div>

                <%-------------------------------------------------------------------------------------------------------------------------------------------------%>

                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6" style="padding-left: 60px;">
                            <asp:Literal ID="lblProgram" runat="server" Text="Employee ID :"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                        </div>
                    </div>

                </div>
            </div>

            <div class="row mb-3 ms-1" style="width: 40%">
                <div class="col-sm-6" style="padding-left: 60px;">
                    <asp:Button ID="btnRegister" runat="server" Text="Search" CssClass="btn btn-primary btn-user " ValidationGroup="1" Style="width: 200px;" OnClick="btnRegister_Click" />
                </div>
                <div class="col-sm-6" style="padding-left: 60px;">
                    <asp:Button ID="btnAdd" runat="server" Text="Request Training" CssClass="btn btn-secondary btn-user " BackColor="#565656" BorderColor="#565656" Style="width: 200px;" OnClick="btnAdd_Click" />
                </div>
            </div>
            <div class="col-sm-6 m-3">
                <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
            </div>
        </div>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvRequestTraining" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ProgramDate" HeaderText="Program Date" />
                    <asp:BoundField DataField="Employee_Id" HeaderText="Employee Id" />
                    <asp:BoundField DataField="Employee.fullName" HeaderText="Employee Name" />
                    <asp:BoundField DataField="Program.ProgramName" HeaderText="Program" />
                    <asp:BoundField DataField="Institute" HeaderText="Institute" />
                    <asp:BoundField DataField="Status.ProjectStatusName" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-secondary" ID="btnAction" runat="server" Style="width: 150px;" OnClick="btnAction_Click">Update</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
