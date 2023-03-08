<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalFilesSearch.aspx.cs" Inherits="ManPowerWeb.PersonalFilesSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <h2>Personal Files Search</h2>

        <div class="row mt-5">
            <div class="col-6">
                <div class="row">
                    <div class="col-3">
                        <label>Name : </label>
                    </div>
                    <div class="col-6 ">
                        <asp:TextBox ID="name" runat="server" name="date" CssClass="form-control form-control-user"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-6">
                <div class="row">
                    <div class="col-4">
                        <label>NIC : </label>
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="nic" runat="server" name="date" CssClass="form-control form-control-user"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-6">
                <div class="row">
                    <div class="col-3">
                        <label>Emp No : </label>
                    </div>
                    <div class="col-6">
                        <asp:DropDownList ID="empNo" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4 p-2">
            <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-primary" Style="width: 120px;" />
        </div>

        <div class="row mt-3 p-2">
            <a href="PersonalFiles.aspx">
                <asp:Button ID="Button2" runat="server" Text="Add New Personal File" CssClass="btn btn-primary" Style="width: 255px;" />
            </a>
        </div>

        <div class="table-responsive mt-5" style="width: 100%;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None">
                <Columns>
                    <asp:BoundField HeaderText="Employee Number" DataField="EmpNo" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Name Denoted By Initials" DataField="NameWithInitials" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Last Name" DataField="LastName" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="NIC" DataField="EmployeeNIC" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField HeaderText="Gender" DataField="EmpGender" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
                                a href='<%#"PersonalFilesView.aspx?id="+DataBinder.Eval(Container.DataItem,"EmployeeId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
