<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveLoan.aspx.cs" Inherits="ManPowerWeb.ApproveLoan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
                            <asp:BoundField DataField="ApprovalStatusId" HeaderText="Status" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
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
                <h2>For Finance</h2>

                <div class="row ms-1 mt-3 mb-5">
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
                </div>
                <h4>Last Loan Details</h4>

                <div class="row ms-1 mb-5 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal3" runat="server" Text="Last Loan Type"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlLastLoanType" runat="server" CssClass="form-control form-control-user"></asp:DropDownList>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal4" runat="server" Text="Last Loan Amount"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtLastLoanAmount" runat="server" CssClass="form-control form-control-user"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="row ms-1 mb-5 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal5" runat="server" Text="Last Loan Date"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>

                <%--===============================================--%>
                <h4>Approval of Loan</h4>
                <div class="row ms-1 mb-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal1" runat="server" Text="Loan Amount"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtLoanAmount" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>
                </div>


                <div class="row ms-1 mb-1 mt-3">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal13" runat="server" Text="Basic Salary"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="form-control form-control-user" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtBasicSalary" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBasicSalary"
                                    ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal14" runat="server" Text="Total Deduction"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtTotalDeduction" runat="server" CssClass="form-control form-control-user" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtTotalDeduction" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTotalDeduction"
                                    ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>
                </div>


                <asp:Label runat="server" ID="lblCkecker" CssClass="alert-success" Visible="false" Font-Size="XX-Large" Font-Bold="true"></asp:Label>

                <div class="row mb-3 ms-1 mt-1">
                    <div class="col-sm-3">
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <asp:Button ID="btnCheck" runat="server" Text="Check" CssClass="btn btn-primary" OnClick="btnCheck_Click" ValidationGroup="1" ToolTip="Check the 40%" />
                            </div>
                            <%--  <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529"  />
                        </div>--%>
                        </div>
                    </div>
                </div>

                <div class="row ms-1 mb-1">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal6" runat="server" Text="Payable Loan Amount"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtPayableLoanAmount" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="4"
                                    ControlToValidate="txtPayableLoanAmount" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPayableLoanAmount"
                                    ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ForeColor="Red" ValidationGroup="4"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal9" runat="server" Text="Distress Loan Balance"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtDistressLoanBalance" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="4"
                                    ControlToValidate="txtDistressLoanBalance" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtDistressLoanBalance"
                                    ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ForeColor="Red" ValidationGroup="4"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row ms-1 mb-1">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal7" runat="server" Text="Premium Amount "></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtPremiumAmount" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="4"
                                    ControlToValidate="txtPremiumAmount" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPremiumAmount"
                                    ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ForeColor="Red" ValidationGroup="4"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Literal ID="Literal8" runat="server" Text="Number of Installments"></asp:Literal>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtNumberOfInstallments" runat="server" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="4"
                                    ControlToValidate="txtNumberOfInstallments" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtNumberOfInstallments" Type="Integer" MinimumValue="0" MaximumValue="480" ForeColor="Red"></asp:RangeValidator>


                            </div>
                        </div>
                    </div>
                </div>

                <%--Approve and Reject button--%>
                <div class="row mb-3 ms-1 mt-3">
                    <div class="col-sm-3">
                        <div class="row mb-3 ms-1">
                            <div class="col">
                                <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnApprove_Click" ValidationGroup="4" Visible="false" />
                            </div>
                            <div class="col">
                                <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" data-toggle="modal" data-target="#exampleModalCenter" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCheck" />
            <asp:PostBackTrigger ControlID="btnApprove" />
            <%--<asp:PostBackTrigger ControlID="btnReject" />--%>
        </Triggers>
    </asp:UpdatePanel>


    <%---------------------dialog box----------------------%>

    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Reject Loan By Finance</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <center>
                        <div class="row mb-3 ms-1">
                            <div class="col-sm-4">
                                <label>Reason to reject </label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtrejectReason" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="txtrejectReason" ValidationGroup="3" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </center>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnRejectReason" Text="Reject" OnClick="btnRejectReason_Click" CssClass="btn btn-danger" Width="100px" ValidationGroup="3" />
                </div>
            </div>
        </div>
    </div>

    <%--------------end of dialog box--------------------%>
</asp:Content>
