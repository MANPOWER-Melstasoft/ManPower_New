<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveLoan.aspx.cs" Inherits="ManPowerWeb.ApproveLoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="scriptmanger1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePannel1">
        <ContentTemplate>
            <div class="card m-4 p-4">
                <h2>Approve Loan</h2>
                <div class="table-responsive mt-4" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                    <asp:GridView runat="server" ID="gvLoan" AutoGenerateColumns="False" CssClass="table table-bordered"
                        CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="center"
                        FooterStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                        <Columns>
                            <asp:BoundField DataField="LoanDetailsId" HeaderText="Id" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="EmployeeId" HeaderText="Employee ID" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="FullName" HeaderText="Employee Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="LoanAmount" HeaderText="Loan Amount" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="Date Request" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ApprovalStatus" HeaderText="Status" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="BtnView" CssClass="btn btn-success" OnClick="BtnView_Click">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>No records</EmptyDataTemplate>
                    </asp:GridView>
                </div>


            </div>
            <div class="card m-4 p-4">
                <div class="row mb-5 ms-1 mt-5">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal2" runat="server" Text="Employee Id"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal1" runat="server" Text="Loan Amount"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row ms-1">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal13" runat="server" Text="Basic Salary"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtBasicSalary" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBasicSalary"
                                    ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ValidationGroup="1" ForeColor="Red"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal14" runat="server" Text="Total Deduction"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtTotalDeduction" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtTotalDeduction" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTotalDeduction"
                                    ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ValidationGroup="1" ForeColor="Red"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>
                </div>


                <asp:Label runat="server" ID="lblCkeckerSuccess" CssClass="alert-success" Visible="false" Font-Size="XX-Large" Font-Bold="true"></asp:Label>
                <asp:Label runat="server" ID="lblCkeckerfailed" CssClass="alert-danger" Visible="false" Font-Size="XX-Large" Font-Bold="true"></asp:Label>

                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-3">
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <asp:Button ID="btnCheck" runat="server" Text="Check" CssClass="btn btn-success" OnClick="btnCheck_Click1" ValidationGroup="1" />
                            </div>
                            <%--  <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529"  />
                        </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCheck" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
