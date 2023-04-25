<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveTrainingRequest.aspx.cs" Inherits="ManPowerWeb.ApproveTrainingRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Approve/Reject Training Requests</h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvApproveTraining" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="TrainingRequestsId" HeaderText="Training Request ID" />
                    <asp:BoundField DataField="systemuser.EmpNumber" HeaderText="Employee Number" />
                    <asp:BoundField DataField="systemuser.Name" HeaderText="Employee Name" />
                    <asp:BoundField DataField="Trainingmain.TrainingMainId" HeaderText="Training ID" />
                    <asp:BoundField DataField="Trainingmain.Title" HeaderText="Title" />
                    <asp:BoundField DataField="Trainingmain.Start_Date" HeaderText="Start Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="Trainingmain.End_date" HeaderText="End Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="Trainingmain.Member_Count" HeaderText="Member Count" />
                    <asp:TemplateField HeaderText="View Attachments">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-secondary" ID="btnView" runat="server" Style="width: 150px;" OnClick="btnView_Click">View Attachments</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Approve">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-success" ID="btnApprove" runat="server" Style="width: 150px;" OnClick="btnApprove_Click">Approve</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reject">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-danger" ID="btnReject" runat="server" Style="width: 150px;" data-toggle="modal" data-target="#exampleModalCenter">Reject</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
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
