<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntView.aspx.cs" Inherits="ManPowerWeb.EntView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="padding-left:30px;">
    <h2>Developed Entrepreneur / Self Employers Details</h2>
        <br /><br />

		<div class="row">
			<div class="col-3">
				<label>Business Registration Number :</label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="regNo" runat="server"  Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div>

		<br/>

		<div class="row">
			<div class="col-3">
				<label>Contact Number : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="contact" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div>
		<br/> 

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
				<label>Business Type : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="businessType" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Nature of Business : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="nature" runat="server" Width="230px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-3">
				<label>Start Date : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="sDate" runat="server" name="date" Width="230px" CssClass="form-control form-control-user" ></asp:TextBox>
			</div>
		</div>
		<br />


		<div class="row">
			<div class="col-3">
				<label>Average Monthly Income : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="income" runat="server" Width="230px" CssClass="form-control form-control-user" ></asp:TextBox>
			</div>
		</div><br /> 

		

		<div class="row">
			<div class="col-3">
				<label>Number of Workers : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="workers" runat="server" Width="230px" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-3">
				<label>Market Type : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="marketType" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<%--<div class="row">
			<div class="col-3">
				<label>District : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="district" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Divisional Secretary : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="ds" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /><br />--%>


		<br />

		<div class="row">
			<div class="col-2">
				<asp:Button runat="server" ID="btnSave" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked"/>
			</div>
		</div><br />

    </div>
</asp:Content>
