<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovedTraining.aspx.cs" Inherits="ManPowerWeb.ApprovedTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Approved Trainings</h2>
        <div cssclass="table-responsive" style="margin-right: 20px; margin-left: 20px; text-align: center">
            <asp:GridView ID="gvApproveTraining" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="TrainingRequestsId" HeaderText="Training Request ID" />
                    <asp:BoundField DataField="systemuser.Name" HeaderText="Employee Name" />
                    <asp:BoundField DataField="Trainingmain.TrainingMainId" HeaderText="Training ID" />
                    <asp:BoundField DataField="Trainingmain.Title" HeaderText="Title" />
                    <asp:BoundField DataField="Trainingmain.Start_Date" HeaderText="Start Date" />
                    <asp:BoundField DataField="Trainingmain.End_date" HeaderText="End Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
