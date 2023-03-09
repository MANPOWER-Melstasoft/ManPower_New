<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVoteType.aspx.cs" Inherits="ManPowerWeb.AddVoteType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card o-hidden border-0 shadow-lg my-3">
        <div class="card-header d-flex align-items-center justify-content-center" style="height: 5%">
            <h5 class="text-center  mt-3 mb-3">Add Vote Type</h5>
        </div>
        <div class="card-body">

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-3">
                    <asp:Literal ID="lblVote" runat="server" Text="Vote Details"></asp:Literal>
                </div>

                <div class="col-md-4">
                    <asp:TextBox ID="txtVoteDetails" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                    <div class="d-flex text-danger">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1"
                            ControlToValidate="txtVoteDetails" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>


            <div class="row mb-3 ms-1">
                <div class="col-sm-3">
                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">
                            <asp:Button ID="btnSubmit" runat="server" Text="Create" CssClass="btn btn-primary btn-user btn-block" ValidationGroup="1" OnClick="btnSubmit_Click" />
                        </div>
                        <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529" OnClick="btnReset_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 m-3">
                <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
            </div>

        </div>
    </div>

    <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
        <asp:GridView Style="margin-top: 30px;" ID="gvVoteType" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="Deatils" HeaderText="DETAILS" HeaderStyle-CssClass="table-dark" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
