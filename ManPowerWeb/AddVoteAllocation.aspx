<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVoteAllocation.aspx.cs" Inherits="ManPowerWeb.AddVoteAllocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card o-hidden border-0 shadow-lg my-3">
        <div class="card-header d-flex align-items-center justify-content-center" style="height: 5%">
            <h5 class="text-center  mt-3 mb-3">Add Vote Allocation</h5>
        </div>
        <div class="card-body">

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblType" runat="server" Text="Vote Type"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlVoteType" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlVoteType" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblAmount" runat="server" Text="Amount"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtAmount" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                </div>

                <%-------------------------------------------------------------------------------------------------------------------------------------------------%>

                <div class="col-sm-6">
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblYear" runat="server" Text="Year"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="btn btn-outline-dark dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlYear" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>

                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <div class="row mb-3">
                        <div class="col-sm-6">
                            <asp:Literal ID="lblVoteNumber" runat="server" Text="Vote Number"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtVoteNumber" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtVoteNumber" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblVotnumError" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
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
            <div class="row mb-3 ms-1">
                <div class="col-sm-6 m-3">
                    <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
                    <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>

        </div>
    </div>

    <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
        <asp:GridView Style="margin-top: 30px;" ID="gvVoteAllocation" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="voteType.Deatils" HeaderText="DETAILS" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="DisplayYear" HeaderText="YEAR" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="VoteNumber" HeaderText="VOTE NUMBER" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="Amount" HeaderText="AMOUNT" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="RemainAmount" HeaderText="REMAIN AMOUNT" HeaderStyle-CssClass="table-dark" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
