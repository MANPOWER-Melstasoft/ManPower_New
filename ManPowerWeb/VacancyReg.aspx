<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VacancyReg.aspx.cs" Inherits="ManPowerWeb.VacancyReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin:40px;padding:30px">
    <h2>Company / Vacancy Registration Details</h2>
        <br /><br />

		<div class="row">
			<div class="col-4">
				<label>Date : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="date" runat="server" name="date" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-4">
				<label>Address : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="address" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-4">
				<label>Website Link : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="link" runat="server" name="place" Width="250px" CssClass="form-control form-control-user" TextMode="Url"></asp:TextBox>
			</div>
		</div>
		<br/> 

		<div class="row">
			<div class="col-4">
				<label>Business Registration Number :</label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="regNo" runat="server"  Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div>

		<br/>

		<div class="row">
			<div class="col-4">
				<label>Vacancy Type / Job Position : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="vanacnyType" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div>
		<br/> 

		<div class="row">
			<div class="col-4">
				<label>Carrer Path / Achived Highest Position : </label>
			</div>
			<div class="col-8">
				<asp:DropDownList ID="achivedPosition" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
					data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
			</div>
		</div><br />

		<div class="row">
			<div class="col-4">
				<label>Level : </label>
			</div>
			<div class="col-8">
				<asp:DropDownList ID="ddl2" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
					data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-4">
				<label>Salary Level : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="salary" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />
		
		<div class="row">
			<div class="col-4">
				<label>Number of Vacancies : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="NoOfVacancy" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<h4><b>Contact Person Details</b></h4>
		<br />

		<div class="row">
			<div class="col-4">
				<label>Name : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="name" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-4">
				<label>Position : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="position" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-4">
				<label>Contact Number : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="contact" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-4">
				<label>Whatsapp Number : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="whatsapp" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-4">
				<label>Email : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="email" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />


		<br />

		<div class="row">
			<div class="col-2">
				<asp:Button runat="server" ID="Button3" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" />
			</div>
			<div class="col-2">
				<asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click" />
			</div>
			<div class="col-2">
				<asp:Button runat="server" ID="Button1" Text="Clear" CssClass="btn btn-primary btn-user btn-block" OnClick="btnClear_Click" />
			</div>
		</div><br />

    </div>
</asp:Content>
