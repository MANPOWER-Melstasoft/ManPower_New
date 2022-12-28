<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndividualBeneSearch.aspx.cs" Inherits="ManPowerWeb.IndividualBeneSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <h2>Developed Entrepreneur / Self Employers Details</h2>
        <br /><br />

        <div class="row">
			<div class="col-6">
				<div class="row">
					<div class="col-3">
						<label>Date of birth : </label>
					</div>
					<div class="col-7">
						<asp:TextBox ID="dob" runat="server" name="date" Width="230px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
					</div>
				</div>
			</div>
		</div>

			<br /><br />
		<asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" style="width:120px;" />

		<br /><br />

		<a href="ResourcePersonReg.aspx">
			<asp:Button ID="Button2" runat="server" Text="Add New Indvidual Beneficiaries" OnClick="isClicked" CssClass="btn btn-primary" style="width:255px;" />
		</a>

		<div class="table-responsive" style="width: 100%;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None">
                <Columns>
					<asp:BoundField HeaderText="Name" DataField="InduvidualBeneficiaryName" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Job Preference" DataField="JobPreference" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Contact Number" DataField="ContactNumber" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Date Of Birth" DataField="DateOfBirth" HeaderStyle-CssClass="table-dark" />
					<asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" >
						<ItemTemplate>
							<asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
								a href ='<%#"IndividualBeneView.aspx?id="+DataBinder.Eval(Container.DataItem,"BenificiaryId") %>'/>
						</ItemTemplate>
					</asp:TemplateField>
                </Columns>
            </asp:GridView>
		</div>
	</div>
</asp:Content>
