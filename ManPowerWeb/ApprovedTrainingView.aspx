<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovedTrainingView.aspx.cs" Inherits="ManPowerWeb.ApprovedTrainingView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mb-3" id="mainContainer" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <div class="card ml-4 p-4">
            <h2>
                <asp:Label ID="heading" runat="server" Text="N/A">Approved Training</asp:Label>
            </h2>
            <br />
            <div class="form-group">

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <div class="row mb-3 ms-1 mt-4">
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal1" runat="server" Text="Training Request ID : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainingRequestsId" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row mb-3 ms-1 mt-4">
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal2" runat="server" Text="Training ID : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainingMainId" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>



                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal3" runat="server" Text="Title : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTitle" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal4" runat="server" Text="Start Date : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblStartDate" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>



                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">

                                        <asp:Literal ID="Literal15" runat="server" Text="End Date : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblEnddate" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal6" runat="server" Text="Accepted By : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblAcceptedBy" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row mb-3">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal7" runat="server" Text="Accepted Date : "></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblAcceptedDate" runat="server" Text="N/A" Width="250px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row mb-5">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <asp:Literal ID="Literal8" runat="server" Text="Training Documents :"></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:GridView Style="margin-top: 30px;" ID="gvTrainingDocuments" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                                            CellPadding="4" GridLines="None" AllowPaging="true" PageSize="10" HeaderStyle-HorizontalAlign="Center">
                                            <Columns>
                                                <asp:BoundField DataField="Docs" HeaderText="Document Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfDocumentId" runat="server" Value='<%# Eval("Id") %>' />
                                                        <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-success" Width="100px" Height="35px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row mb-5">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-4">

                                        <asp:Literal ID="Literal9" runat="server" Text="Upload Documnents :"></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:FileUpload ID="Uploader" CssClass="btn" runat="server" AllowMultiple="true" />

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row mb-3 ms-1">
                            <div class="col-sm-6 d-flex">
                                <div class="col-sm-4">
                                    <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="btnBack_Click" />
                                </div>
                                <div class="col-sm-4">
                                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>




                    </ContentTemplate>
                    <Triggers>
                        <%--<asp:PostBackTrigger ControlID="btnView" />--%>
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                        <%--<asp:PostBackTrigger ControlID="btnBack" />--%>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>
</asp:Content>
