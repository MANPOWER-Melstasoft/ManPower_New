<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHoliday.aspx.cs" Inherits="ManPowerWeb.AddHoliday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card p-4">
        <h2>Add Holidays</h2>

        <div class="mt-3">


            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-6">

                            <asp:Literal ID="Literal1" runat="server" Text="Date"></asp:Literal>
                        </div>
                        <div class="col-md-6">

                            <asp:TextBox runat="server" TextMode="Date" CssClass="form-control form-control-user" ID="txtDate"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDate" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-6">

                            <asp:Literal ID="Literal3" runat="server" Text="Description"></asp:Literal>
                        </div>
                        <div class="col-md-6">

                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescription" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-6">

                            <asp:Button runat="server" ID="btnAddToTable" Text="Add To Table" CssClass="btn btn-primary" />
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" ValidationGroup="1" OnClick="btnSave_Click" />
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

    <asp:GridView ID="gvHoliday" runat="server" CssClass="Grid" AutoGenerateColumns="false"
        EmptyDataText="No records has been added">
        <Columns>
            <asp:BoundField DataField="Date" HeaderText="Name" ItemStyle-Width="120" HeaderStyle-CssClass="table-dark" />
            <asp:BoundField DataField="Description" HeaderText="Country" ItemStyle-Width="120" HeaderStyle-CssClass="table-dark" />
            <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="btnView" runat="server" Text="Remove" CssClass="btn btn-danger" Width="100px" Height="35px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


</asp:Content>
