<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSupplierType.aspx.cs" Inherits="ManPowerWeb.AddSupplierType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 40px;"></div>
    <div class="card" style="width: 70%; margin-left: auto; margin-right: auto">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Add Supplier Type</h2>
        <div class="row mb-5" style="text-align: center; width: 100%; padding-left: 20px;">
            <div class="col-sm-6" style="width: 50%; padding-left: 40px; padding-right: 10px; margin-bottom: 0px;">
                <div style="text-align: start; padding-left: 2px; margin-bottom: 5px;">
                    <asp:Literal ID="Literal1" runat="server" Text="Supplier Type Name"></asp:Literal>
                </div>
                <asp:TextBox Style="width: 100%;" ID="txtSupplierName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtSupplierName" ErrorMessage="Required" ValidationGroup="1">This field is Required</asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-6" style="width: 30%; margin-left: auto; margin-right: auto; margin-top: 27px;">
                <asp:Button ID="btnSave" runat="server" Text="Add Supplier Type" Style="width: 50%;" OnClick="btnSave_Click" ValidationGroup="1" CssClass="btn btn-primary btn-user btn-block" />
            </div>
            <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                <asp:GridView Style="margin-top: 30px;" ID="gvAddSupplierType" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover"
                    CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Supplier Type Id" />
                        <asp:BoundField DataField="SupplyTypeName" HeaderText="Supplier type Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-outline-success ">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btndelete" runat="server" OnClick="btndelete_Click" CssClass="btn btn-outline-danger ">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div style="height: 40px;"></div>
</asp:Content>
