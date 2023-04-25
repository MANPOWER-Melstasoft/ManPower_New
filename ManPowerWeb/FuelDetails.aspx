<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FuelDetails.aspx.cs" Inherits="ManPowerWeb.FuelDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card p-4">
        <h2>Fuel Details</h2>

        <div class="row mt-3">
            <div class="col-sm-3">
                <asp:Literal ID="Vehicle_Number" runat="server" Text="Vehicle Number"></asp:Literal>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtVehicleNumber" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                <div class="d-flex text-danger">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                        ControlToValidate="txtVehicleNumber" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>



        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-3">
                <asp:Literal ID="Literal1" runat="server" Text="Fuel Type"></asp:Literal>
            </div>

            <div class="col-md-4">
                <asp:DropDownList ID="ddlFuelType" runat="server" CssClass="form-control form-control-user"></asp:DropDownList>
                <div class="d-flex text-danger">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                        ControlToValidate="ddlFuelType" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>


        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-3">
                <asp:Literal ID="Literal2" runat="server" Text="Liters"></asp:Literal>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtLiter" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                <div class="d-flex text-danger">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                        ControlToValidate="txtLiter" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>


        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-3">
                <asp:Literal ID="Literal3" runat="server" Text="Create Date"></asp:Literal>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                <div class="d-flex text-danger">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="1"
                        ControlToValidate="txtDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>



        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-3">
                <asp:Literal ID="Literal4" runat="server" Text="Order Number"></asp:Literal>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtOrderNumber" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                <div class="d-flex text-danger">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                        ControlToValidate="txtOrderNumber" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row mb-3 ms-1">
            <div class="col-sm-3">
                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmit_Click" ValidationGroup="1" />
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-6 m-3">
            <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
        </div>


    </div>


    <%-- <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
        <asp:GridView Style="margin-top: 30px;" ID="gvPosition" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="PossitionId" HeaderText="ID" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="PositionName" HeaderText="NAME" HeaderStyle-CssClass="table-dark" />
                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="BtnEdit" CssClass="btn btn-warning" OnClick="BtnEdit_Click">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="table-dark">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="BtnDelete" CssClass="btn btn-danger" OnClick="BtnDelete_Click">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>--%>
</asp:Content>
