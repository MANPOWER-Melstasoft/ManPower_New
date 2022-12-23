<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProgram.aspx.cs" Inherits="ManPowerWeb.AddProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card o-hidden border-0 shadow-lg my-3">
        <div class="card-header d-flex align-items-center justify-content-center" style="height: 5%">
            <h5 class="text-center  mt-3 mb-3">Add Programs</h5>
        </div>
        <div class="card-body">

            <div class="row mb-3 ms-1 mt-3">

                <div class="col-sm-3">
                    <asp:Literal ID="lblName" runat="server" Text="Program Name"></asp:Literal>
                </div>

                <div class="col-md-3">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                    <div class="d-flex text-danger">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                            ControlToValidate="txtName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-sm-3">
                    <asp:Literal ID="lblType" runat="server" Text="Program Type"></asp:Literal>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlProgramType" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"></asp:DropDownList>
                    <div class="d-flex text-danger">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                            ControlToValidate="ddlProgramType" ErrorMessage="Required">*</asp:RequiredFieldValidator>
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
            <div class="col-sm-6 m-3">
                <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
            </div>

        </div>
    </div>
</asp:Content>
