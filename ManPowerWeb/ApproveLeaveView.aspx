<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveLeaveView.aspx.cs" Inherits="ManPowerWeb.ApproveLeaveView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card p-4">
            <h2>Approve Leave</h2>

            <div class="row mt-3">
                <div class="col-6">

                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">
                            <asp:Literal ID="Literal3" runat="server" Text="Date Of Commencing Leave"></asp:Literal>
                        </div>
                        <div class="col-md-6">

                            <asp:TextBox runat="server" ID="txtDateCommencing" CssClass="form-control form-control-user" Enabled="false">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDateCommencing" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">
                            <asp:Literal ID="Literal4" runat="server" Text="Number Of Dates"></asp:Literal>
                        </div>
                        <div class="col-md-6">

                            <asp:TextBox runat="server" ID="txtNoOfDates" CssClass="form-control form-control-user" TextMode="Number" min="0" Enabled="false">
                            </asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNoOfDates" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator runat="server" ControlToValidate="txtNoOfDates" ErrorMessage="Invalid number"
                                    Type="Integer" MinimumValue="1" MaximumValue="1000" ForeColor="Red"></asp:RangeValidator>--%>
                        </div>
                    </div>

                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">

                            <asp:Literal ID="Literal1" runat="server" Text="Date of Resuming"></asp:Literal>
                        </div>
                        <div class="col-md-6">

                            <asp:TextBox runat="server" ID="txtDateResuming" CssClass="form-control form-control-user" Enabled="false">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDateResuming" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">

                            <asp:Literal ID="Literal2" runat="server" Text="Leave Type"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList runat="server" ID="ddlLeaveType" CssClass="form-control form-control-user" Enabled="false">
                            </asp:DropDownList>

                        </div>
                    </div>

                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">

                            <asp:Literal ID="Literal6" runat="server" Text="Day Type"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList runat="server" ID="ddlDayType" CssClass="form-control form-control-user" Enabled="false">
                                <asp:ListItem Value="1">Morning-Half</asp:ListItem>
                                <asp:ListItem Value="2">Evening-Half</asp:ListItem>
                                <asp:ListItem Value="3">Full Day</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">

                            <asp:Literal ID="Literal5" runat="server" Text="Reason for Leave"></asp:Literal>
                        </div>
                        <div class="col-md-6">

                            <asp:TextBox runat="server" ID="txtLeaveReason" CssClass="form-control form-control-user" TextMode="MultiLine" Enabled="false">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtLeaveReason" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>


                        </div>
                    </div>

                    <div class="row mb-3 ms-1">


                        <div class="col-sm-2">
                            <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary" OnClick="btnBack_Click" BackColor="#212529" BorderColor="#212529" />
                        </div>
                        <div class="col-sm-2">
                            <button runat="server" id="btnModalReject" type="button" class="btn btn-danger " data-toggle="modal" data-target="#exampleModalCenter">Reject</button>

                        </div>
                        <div class="col-sm-2">
                            <asp:Button runat="server" ID="btnApprove" Text="Approve" CssClass="btn btn-primary" OnClick="btnApprove_Click" />
                        </div>

                        <div class="col-sm-5 ml-3">
                            <asp:Button runat="server" ID="btnViewLeave" Text="View Leave Balance" CssClass="btn btn-success btn-user btn-block" OnClick="btnViewLeave_Click" />
                        </div>


                    </div>

                </div>

                <div class="col-5 ml-5">

                    <div class="table-responsive">
                        <asp:GridView Style="margin-top: 30px;" ID="gvDocument" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="Id" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Document" DataField="Document" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px" target="new"
                                            a href='<%#"/SystemDocuments/StaffLeaveResources/"+DataBinder.Eval(Container.DataItem,"Document") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>

            </div>
        </div>
    </div>

    <%------------------- model ----------------------%>

    <!-- Modal -->
    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Reject Leave Appication</h5>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" ControlToValidate="txtrejectReason" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </center>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnReject" Text="Reject" OnClick="btnReject_Click" CssClass="btn btn-danger" Width="100px" ValidationGroup="1" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
