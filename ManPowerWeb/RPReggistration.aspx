<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RPReggistration.aspx.cs" Inherits="ManPowerWeb.RPReggistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
    <h2>Individual Beneficiary Registration</h2>
        <br /><br />

        
		<div class="row">
			<div class="col-3">
				<label>NIC :</label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="nic" runat="server"  Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div>

		<br/>

		<div class="row">
			<div class="col-3">
				<label>Name : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="name" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div>
		<br/> 

		<div class="row">
			<div class="col-3">
				<label>Gender : </label>
			</div>
			<div class="col-9">
				<asp:DropDownList ID="ddl1" Width="230px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
					data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Date of Birth : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="dob" runat="server" name="date" Width="230px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
			</div>
		</div>
		<br />


		<div class="row">
			<div class="col-3">
				<label>Personal Address : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="address" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-3">
				<label>Email : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="email" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-3">
				<label>Job Preference : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="jobType" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-3">
				<label>Contact Number : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="contact" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Whatsapp Number : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="whatsapp" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>School / Non School : </label>
			</div>
			<div class="col-9">
				<asp:DropDownList ID="ddl2" Width="230px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
					data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
			</div>
		</div><br /> <br />


		<%if (ddl2.Text == "School")
			{ %>

		<div class="row">
			<div class="col-3">
				<label>Name of the School : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="sclName" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Address of the School : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="sclAddress" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Grade : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="grade" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Parent NIC : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="parentNic" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<%} %>
		
		<br /><br />

		<div class="row">
			<div class="col-2">
				<asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click" />
			</div>
			<div class="col-2">
				<asp:Button runat="server" ID="Button1" Text="Clear" CssClass="btn btn-primary btn-user btn-block" OnClick="btnClear_Click" />
			</div>
		</div><br />

    </div>
</asp:Content>
