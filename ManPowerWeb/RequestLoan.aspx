<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestLoan.aspx.cs" Inherits="ManPowerWeb.RequestLoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="Scriptmanger1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="Updatepanel" runat="server">
        <ContentTemplate>
            <div class="card o-hidden border-0 shadow-lg m-3 p-4">

                <h2>Request Loan</h2>

                <div class="card-body">

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="lblName" runat="server" Text="Loan Type"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="form-control form-control-user" AutoPostBack="true"></asp:DropDownList>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                                            ControlToValidate="ddlLoanType" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal1" runat="server" Text="Full Name"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal2" runat="server" Text="Position"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtPosition" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>





                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal4" runat="server" Text="Position Type"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPositionType" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtPositionType" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal3" runat="server" Text="Work Place"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtWorkPlace" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtWorkPlace" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>




                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal5" runat="server" Text="Appointment Date"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtAppointmentDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtAppointmentDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal6" runat="server" Text="Basic Salary"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtBasicSalary"
                                            ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ValidationGroup="1" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtBasicSalary" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal7" runat="server" Text="Requesting Loan Amount"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLoanAmount"
                                            ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ValidationGroup="1" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtLoanAmount" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal8" runat="server" Text="Date Required"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtDateWanted" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtDateWanted" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>




                    <%--Distress Loan Div--%>
                    <% if (ddlLoanType.SelectedValue == "3")
                        { %>

                    <div class="row mb-3 ms-1 mt-3">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal9" runat="server" Text="Reason for Loan"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtLoanReason" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtLoanReason" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal10" runat="server" Text="Last Loan Date"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtLastLoan" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtLastLoan" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <h4>Guarantor Details</h4>

                    <div class="row mb-3 ms-1 mt-5">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal11" runat="server" Text="Guarantor Name"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtGuarantorName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtGuarantorName" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal12" runat="server" Text="Guarantor Position"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtGuarantorPosition" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="1"
                                            ControlToValidate="txtGuarantorPosition" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-5 ms-1 mt-5">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal13" runat="server" Text="Work place address of guarantor"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtGuarantorAdress" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="1"
                                        ControlToValidate="txtGuarantorAdress" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal14" runat="server" Text="Appointed Date of Guarantor"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtGuarantorAppointedDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="1"
                                        ControlToValidate="txtGuarantorAppointedDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-5">
                        <div class="col-sm-3">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnAddGuarantor" runat="server" Text="Add To Table" CssClass="btn btn-success" OnClick="btnAddGuarantor_Click" />
                                </div>
                                <%--  <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529"  />
                        </div>--%>
                            </div>
                        </div>
                    </div>


                    <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                        <asp:GridView Style="margin-top: 30px;" ID="gvGuarantor" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" AllowPaging="true" HeaderStyle-HorizontalAlign="center"
                            FooterStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Guarantor Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="Address" HeaderText="Guarantor Position" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="Position" HeaderText="Work place address of guarantor" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="AppointedDate" HeaderText="Appointed Date of Guarantor" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>No records</EmptyDataTemplate>

                        </asp:GridView>
                    </div>
                    <h4>If aplicant is a guarantor </h4>


                    <div class="row mb-3 ms-1 mt-5">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal15" runat="server" Text="Officer Name"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtOfficerName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal16" runat="server" Text="Officer Position"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtOfficerPosition" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <div class="d-flex text-danger">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-5">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal17" runat="server" Text="Loan Amount"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtApplicantLoanAmount" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtApplicantLoanAmount"
                                        ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ValidationGroup="1" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal18" runat="server" Text="Premium Amount"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPremiumAmount" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revNumber" runat="server" ControlToValidate="txtPremiumAmount"
                                        ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                        </div>


                    </div>
                    <div class="row mb-3 ms-1 mt-5">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Literal ID="Literal19" runat="server" Text="Interest"></asp:Literal>
                                </div>

                                <div class="col-md-6">
                                    <asp:TextBox ID="txtInterest" runat="server" CssClass="form-control form-control-user"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1 mt-5">
                        <div class="col-sm-3">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnAddApplicant" runat="server" Text="Add To Table" CssClass="btn btn-success" />
                                </div>
                                <%--  <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529"  />
                        </div>--%>
                            </div>
                        </div>
                    </div>

                    <% } %>

                    <%--End of Distress Div--%>



                    <div class="row mb-3 ms-1 mt-5">
                        <div class="col-sm-3">
                            <div class="row mb-3 ms-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Send to Admin" CssClass="btn btn-primary" ValidationGroup="1" OnClick="btnSubmit_Click" />
                                </div>
                                <%--  <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529"  />
                        </div>--%>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
