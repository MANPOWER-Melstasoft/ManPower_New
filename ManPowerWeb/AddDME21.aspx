<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDME21.aspx.cs" Inherits="ManPowerWeb.AddDME21" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Add DME21</h2>
                <div class="row mb-5" style="text-align: center; width: 70%;">
                    <div class="col-sm-6 my-auto" style="width: 10% !important;">
                        <asp:Label CssClass="font-weight-bold" ID="Label1" runat="server" Text="Work Type"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="width: 90%;">
                        <asp:DropDownList Style="width: 80%; height: 40px; padding-left: 10px;" ID="ddlWorkType" runat="server" DataTextField="TaskTypeName" DataValueField="TaskTypeId" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-5" style="text-align: center; width: 70%;" visible="false" id="ProgramDisplay" runat="server">
                    <div class="col-sm-6 my-auto">
                        <asp:Label CssClass="font-weight-bold" ID="Label4" runat="server" Text="Program Name"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="width: 90%;">
                        <asp:DropDownList Style="width: 80%; height: 40px; padding-left: 10px;" ID="ddlProgram" runat="server" DataTextField="ProgramName" DataValueField="ProgramPlanId" Enabled="false"></asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-5" style="text-align: center; width: 70%;" runat="server" visible="false" id="OtherDisplay">
                    <div class="col-sm-6 my-auto">
                        <asp:Label CssClass="font-weight-bold" ID="label5" runat="server" Text="Remarks"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="width: 90%;">
                        <asp:TextBox TextMode="MultiLine" runat="server" Style="width: 80%;" ID="txtRemarks" name="txtRemarks" cols="20" Rows="2"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-5" style="text-align: center; width: 70%;" runat="server" id="divDuty" visible="true">
                    <div class="col-sm-6 my-auto">
                        <asp:Label CssClass="font-weight-bold" ID="label2" runat="server" Text="Performed Duty"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="width: 90%;">
                        <asp:TextBox runat="server" Style="width: 80%;" ID="txtDuty" TextMode="MultiLine" name="txtDuty" cols="20" Rows="2"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-5" style="text-align: center; width: 70%;" runat="server" visible="true" id="divPlace">
                    <div class="col-sm-6 my-auto">
                        <asp:Label CssClass="font-weight-bold" ID="label3" runat="server" Text="Work Attended Place"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="width: 90%;">
                        <asp:TextBox runat="server" Style="width: 80%;" ID="txtPlace" name="txtPlace" type="text" />
                    </div>
                </div>
                <div class="row mb-5"">
                    <div class="col-sm-6 d-flex justify-content-end">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-outline-primary" OnClick="LinkButton1_Click"  style="width: 150px;">Save DME21</asp:LinkButton>
                    </div>
                    <div class="col-sm-6">
                        <asp:LinkButton ID="btnDelete" runat="server" style="width: 150px;" OnClick="btnDelete_Click">Delete</asp:LinkButton>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="LinkButton1" />
            <asp:PostBackTrigger ControlID="btnDelete" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

