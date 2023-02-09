<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHoliday.aspx.cs" Inherits="ManPowerWeb.AddHoliday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="scriptmanger1"></asp:ScriptManager>

    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
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
                    <asp:Label runat="server" ID="lblAddHoliday" CssClass="alert-success mt-3" Visible="false" Font-Size="Large"></asp:Label>
                    <asp:Label runat="server" ID="lblAddHoliday2" CssClass="alert-danger mt-3" Visible="false"></asp:Label>

                </div>
            </div>

            <div class="table-responsive mt-3 mb-3" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                <asp:GridView ID="gvHoliday" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false"
                    ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger" HeaderStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="HolidayDate" HeaderText="Holiday Date" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnRemove" runat="server" Text="Remove" CssClass="btn btn-danger" OnClick="btnRemove_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No records has been added </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>






</asp:Content>
