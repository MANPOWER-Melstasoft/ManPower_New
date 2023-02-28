<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddParent.aspx.cs" Inherits="ManPowerWeb.AddParent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card o-hidden border-0 shadow-lg my-3">
        <div class="card-header d-flex align-items-center justify-content-center" style="height: 5%">
            <h5 class="text-center  mt-3 mb-3">Assign District</h5>
        </div>
        <div class="card-body">

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblType" runat="server" Text="Select User"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlUser" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlUser" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblYear" runat="server" Text="Select Department"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlDepartment" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                </div>

            </div>


            <div class="row mb-3 ms-1">
                <div class="col-sm-3">
                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">
                            <asp:Button ID="btnSubmit" runat="server" Text="Create" CssClass="btn btn-primary btn-user btn-block" ValidationGroup="1" OnClick="btnSubmit_Click" />
                        </div>
                        <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529" OnClick="btnReset_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mb-3 ms-1">
                <div class="col-sm-6 m-3">
                    <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
                    <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>

        </div>
    </div>

    <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
        <asp:GridView Style="margin-top: 30px;" ID="gvParent" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="systemUser.UserName" HeaderText="USER" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="departmentUnit.Name" HeaderText="ASSIGNED DEPARTMENT" HeaderStyle-CssClass="table-dark" />
                <asp:TemplateField HeaderStyle-CssClass="table-dark">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="table-dark">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
