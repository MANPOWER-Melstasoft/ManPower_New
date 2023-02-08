<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTrainingFront.aspx.cs" Inherits="ManPowerWeb.AddTrainingFront1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Training Details</h2>
        <div class="col-sm-4">
            <asp:LinkButton ID="btnAddtraining" runat="server" Style="width: 200px; margin-left: 10px; margin-bottom: 20px;" CssClass="btn btn-outline-secondary" OnClick="btnAddtraining_Click">Add New Training</asp:LinkButton>
        </div>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvTrainingFront" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="TrainingMainId" HeaderText="Training ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Start_Date" HeaderText="Start Date" />
                    <asp:BoundField DataField="End_date" HeaderText="End date" />
                    <asp:BoundField DataField="Member_Count" HeaderText="Member Count" />
                    <asp:BoundField DataField="Post_img" HeaderText="Image URL" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-success" ID="btnEdit" runat="server" Style="width: 150px;" OnClick="btnEdit_Click">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-danger" ID="btnDelete" runat="server" Style="width: 150px;" OnClick="btnDelete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
