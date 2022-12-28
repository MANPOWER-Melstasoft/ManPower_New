<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntRegistrationSearch.aspx.cs" Inherits="ManPowerWeb.EntRegistrationSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <h2>Developed Entrepreneur / Self Employers Details</h2>
        <br /><br />

        <div class="row">
			<div class="col-6">
				<div class="row">
					<div class="col-3">
						<label>Business Type : </label>
					</div>
					<div class="col-7">
						<asp:DropDownList ID="businessType" Width="230px" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
					</div>
				</div>
			</div>
			<div class="col-6">
				<div class="row">
					<div class="col-3">
						<label>Market Type : </label>
					</div>
					<div class="col-9">
						<asp:DropDownList ID="marketType" Width="230px" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
					</div>
				</div>
			</div>
		</div>

			<br /><br />
		<asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" style="width:120px;" />

		<br /><br />

		<a href="ResourcePersonReg.aspx">
			<asp:Button ID="Button2" runat="server" Text="Add New Entrepreneur" OnClick="isClicked" CssClass="btn btn-primary" style="width:220px;" />
		</a>

		<br /><br /><br />

		<div class="table-responsive" style="width: 100%;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None">
                <Columns>
					<asp:BoundField HeaderText="Market Type" DataField="MarketTypeId" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Business Type" DataField="BusinessTypeId" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Nature of Business" DataField="NatureOfBusiness" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Business Start Date" DataField="BusinessStartDate" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Number of Workers" DataField="NumberOfWorkers" HeaderStyle-CssClass="table-dark" />
					<asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" >
						<ItemTemplate>
							<asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
								a href ='<%#"EntView.aspx?id="+DataBinder.Eval(Container.DataItem,"BenificiaryId") %>'/>
						</ItemTemplate>
					</asp:TemplateField>
                </Columns>
            </asp:GridView>
		</div>
	</div>
</asp:Content>
