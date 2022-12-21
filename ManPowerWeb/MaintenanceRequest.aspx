<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintenanceRequest.aspx.cs" Inherits="ManPowerWeb.MaintenanceRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <h2>New Maintenance Request</h2>
        <br /><br />

		<div class="row">
			<div class="col-4">
				<label>File Number : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="fielNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /> 

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
				<label>Maintenance Category : </label>
			</div>
			<div class="col-8">
				<asp:DropDownList ID="achivedPosition" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
					data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
			</div>
		</div><br />

		<div class="row">
			<div class="col-4">
				<label>Requested By : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="requestedBy" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div>
		<br/> 

		<div class="row">
			<div class="col-4">
				<label>Vehicle Number :</label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="vNo" runat="server"  Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br/>

		<div class="row">
			<div class="col-4">
				<label>Description : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="description" runat="server" name="place" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
			</div>
		</div><br/> 

		<div class="row">
			<div class="col-4">
				<label>Uploads : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="uploads" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />
		

		<br />

		<div class="row">
			<div class="col-2">
				<asp:Button runat="server" ID="Button3" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" />
			</div>
			<div class="col-2">
				<asp:Button runat="server" ID="btnSave" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click" />
			</div>
			<div class="col-2">
				<asp:Button runat="server" ID="Button1" Text="Clear" CssClass="btn btn-primary btn-user btn-block" OnClick="btnClear_Click" />
			</div>
		</div><br />

    </div>
</asp:Content>
