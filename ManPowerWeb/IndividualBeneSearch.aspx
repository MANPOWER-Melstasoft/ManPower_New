<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndividualBeneSearch.aspx.cs" Inherits="ManPowerWeb.IndividualBeneSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card p-4">
            <h2>Developed Entrepreneur / Self Employers Details</h2>

            <div class="row mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-3">
                            <label>Date of birth : </label>
                        </div>
                        <div class="col-6 ">
                            <asp:TextBox ID="dob" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>School / Non-School : </label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddlScl" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-6">
                    <div class="row">
                        <div class="col-3">
                            <label>Gender : </label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddlGen" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4 p-2">
                <asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" />
            </div>

            <div class="row mt-3 p-2">
                <a href="ResourcePersonReg.aspx">
                    <asp:Button ID="Button2" runat="server" Text="Add New Indvidual Beneficiaries" OnClick="isClicked" CssClass="btn btn-primary" />
                </a>
            </div>

            <div class="table-responsive mt-5" style="width: 100%;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    CellPadding="4" GridLines="None">
                    <Columns>
                        <asp:BoundField HeaderText="Name" DataField="InduvidualBeneficiaryName" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Job Preference" DataField="JobPreference" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Contact Number" DataField="ContactNumber" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField HeaderText="Date Of Birth" DataField="DateOfBirth" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
                                    a href='<%#"IndividualBeneView.aspx?id="+DataBinder.Eval(Container.DataItem,"BenificiaryId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" Text="Edit" CssClass="btn btn-info" Width="100px"
                                a href='<%#"IndividualBeneView.aspx?id="+DataBinder.Eval(Container.DataItem,"BenificiaryId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" Text="Delete" CssClass="btn btn-info" Width="100px"
                                a href='<%#"IndividualBeneView.aspx?id="+DataBinder.Eval(Container.DataItem,"BenificiaryId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
