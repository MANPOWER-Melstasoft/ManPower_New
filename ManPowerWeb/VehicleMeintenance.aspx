<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehicleMeintenance.aspx.cs" Inherits="ManPowerWeb.VehicleMeintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <h2>Vehicle Maintenance</h2>
        <br /><br />

        <div class="row">
			<div class="col-6">
				<div class="row">
					<div class="col-3">
						<label>Category : </label>
					</div>
					<div class="col-7">
						<asp:DropDownList ID="ddlCategory" Width="250px" runat="server" AutoPostBack="true" CssClass="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false">
						</asp:DropDownList>					
					</div>
				</div>
			</div>
			<div class="col-6">
				<div class="row">
					<div class="col-5">
						<label>Date :</label>
					</div>
					<div class="col-7">
						<asp:TextBox ID="date" runat="server" name="date" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
					</div>
				</div>
			</div>
		</div>

		<div class="row">
			<div class="col-6">
				<div class="row">
					<div class="col-3">
						<label>Key Word : </label>
					</div>
					<div class="col-7">
						<asp:TextBox ID="keywrd" runat="server" name="date" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
					</div>
				</div>
			</div>
		</div>

		

			<br /><br />
		<asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" style="width:120px;" />

		<br /><br />

		<a href="VacancyReg.aspx">
			<asp:Button ID="Button2" runat="server" Text="Request Maintenance" OnClick="isClicked"  CssClass="btn btn-primary" style="width:200px;" />
		</a>

		<div class="table-responsive" style="width: 100%;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None">
                <Columns>
					<asp:BoundField HeaderText="#" DataField="CompanyVacansyRegistationDetailsId" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Date" DataField="VDate" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Address" DataField="VAddress" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Website Link" DataField="WebSiteLink" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="BRN" DataField="BusinessRegistationNumber" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Career Path" DataField="CareerPath" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Salary Level" DataField="SalaryLevel" HeaderStyle-CssClass="table-dark" />
					<asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" >
						<ItemTemplate>
							<asp:LinkButton ID="LinkButton1" runat="server" Text="View" OnClick="viewDetails" CssClass="btn btn-success"
								a href ='<%#"VacancyRegView.aspx?id="+DataBinder.Eval(Container.DataItem,"CompanyVacansyRegistationDetailsId") %>'/>
<%--							<asp:Button ID="Button3" runat="server" Text="View" OnClick="viewDetails" />--%>
						</ItemTemplate>
					</asp:TemplateField>
                </Columns>
            </asp:GridView>
		</div>
	</div>
</asp:Content>
