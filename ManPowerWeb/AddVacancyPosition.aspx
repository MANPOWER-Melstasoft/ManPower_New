<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVacancyPosition.aspx.cs" Inherits="ManPowerWeb.AddVacancyPosition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card p-4 ml-4">
        <h2>Add Vacancy Position Details</h2>

        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-3">
                <asp:Literal ID="Literal1" runat="server" Text="Vacancy Position Category"></asp:Literal>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                    ControlToValidate="txtCategory" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row mb-3 ms-1 mt-3">
            <div class="col-sm-3">
                <asp:Literal ID="lblName" runat="server" Text="Vacancy Position Name"></asp:Literal>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtPositionName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                    ControlToValidate="txtPositionName" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="row mb-3 ms-1">
            <div class="col-sm-3">
                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" ValidationGroup="1" OnClick="btnSubmit_Click" />
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529" OnClick="btnReset_Click" />
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
        <asp:GridView Style="margin-top: 30px;" ID="gvVacancyPosition" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="VacancyPositionName" HeaderText="Position Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="VacancyCategory" HeaderText="Position Category" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbEdit" CssClass="btn btn-primary" Text="Edit" OnClick="lbEdit_Click"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnDelete" CssClass="btn btn-danger" Text="Delete" OnClick="lbtnDelete_Click"></asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
