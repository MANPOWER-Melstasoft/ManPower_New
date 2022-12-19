<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VacancyRegSearch.aspx.cs" Inherits="ManPowerWeb.VacancyRegSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin:40px;padding:30px">
            <h2>Vacancy Registration</h2>
        <br /><br />

        <div class="row">
			<div class="col-6">
				<div class="row">
					<div class="col-3">
						<label>Year : </label>
					</div>
					<div class="col-7">
						<asp:DropDownList ID="ddlYear" Width="250px" runat="server" AutoPostBack="true" CssClass="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false">
						</asp:DropDownList>					
					</div>
				</div>
			</div>
			<div class="col-6">
				<div class="row">
					<div class="col-5">
						<label>Career Path :</label>
					</div>
					<div class="col-7">
						<asp:DropDownList ID="ddlPosition" Width="250px" runat="server" AutoPostBack="true" CssClass="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false">
						</asp:DropDownList>
					</div>
				</div>
			</div>
		</div>

			<br /><br />
		<asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" style="width:120px;" />

		<br /><br />

		<a href="VacancyReg.aspx">
			<asp:Button ID="Button2" runat="server" Text="Add New Vacancy" OnClick="isClicked"  CssClass="btn btn-primary" style="width:200px;" />
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
