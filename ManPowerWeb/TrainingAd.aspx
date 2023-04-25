<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrainingAd.aspx.cs" Inherits="ManPowerWeb.TrainingAd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="contrainer" style="margin-left: 200px; margin-right: 200px;">
        <asp:ListView ID="lvTrainingAd" runat="server">
            <ItemTemplate>
                <div class="card" style="align-items: center; padding-top: 20px;">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Post_img") %>' Height="100%" Width="100%" />
                    <h4 style="margin-top: 20px; margin-bottom: 20px;"><%# Eval("Title") %></h4>
                    <h6 style="margin-bottom: 20px;">From <%# Eval("Start_Date") %> To <%# Eval("End_date") %></h6>
                    <p><%# Eval("Content") %></p>

                </div>
            </ItemTemplate>
        </asp:ListView>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvAttachments" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Attachment" HeaderText="Attachments" />
                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-info" Width="100px" target="new"
                                a href='<%#"/SystemDocuments/TrainingMainAttachments/"+DataBinder.Eval(Container.DataItem,"Attachment") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="row mb-3 mt-3">
            <div class="col-sm-6" style="padding-left: 60px;">
                <asp:Literal ID="Literal1" runat="server" Text="Attachments :"></asp:Literal>
            </div>
            <div class="col-md-6" style="text-align: center">
                <asp:FileUpload ID="FileUploader" runat="server" AllowMultiple="true" Style="padding-top: 10px;"></asp:FileUpload>
            </div>
        </div>
        <div class="row d-flex justify-content-center" style="margin-bottom: 30px; margin-top: 20px;">
            <div class="col-3">
                <asp:LinkButton ID="btnBack" runat="server" Style="width: 150px;" CssClass="btn btn-outline-primary" OnClick="btnBack_Click">Back</asp:LinkButton>
            </div>
            <div class="col-3">
                <asp:LinkButton ID="btnApply" runat="server" Style="width: 150px;" OnClick="btnApply_Click">Apply</asp:LinkButton>
            </div>
            <div class="col-3">
                <asp:LinkButton ID="btnReject" runat="server" Style="width: 150px;" OnClick="btnReject_Click">Cancel</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
