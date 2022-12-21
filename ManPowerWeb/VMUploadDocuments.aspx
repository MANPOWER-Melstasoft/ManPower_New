<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VMUploadDocuments.aspx.cs" Inherits="ManPowerWeb.VMUploadDocuments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <h2>Upload Documents</h2>
        <br /><br />

		<div class="row">
			<div class="col-4">
				<label>Engineer Report : </label>
			</div>
			<div class="col-8">
				<asp:FileUpload ID="engineerReport" runat="server" Width="250px" CssClass="form-control form-control-user"/>
<%--				<asp:TextBox ID="fielNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>--%>
			</div>
		</div><br /> 

		<br />
		<h5><b>Quatation Summary</b></h5>
		<br />

		<div class="row">
			<div class="col-4">
				<label>Number of Quatation : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="noOfQuatation" runat="server" name="date" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-4">
				<label>Quatation Number : </label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="qtNo" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div>
		<br/> 

		<div class="row">
			<div class="col-4">
				<label>Company Name :</label>
			</div>
			<div class="col-8">
				<asp:TextBox ID="cName" runat="server"  Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br/>

		<div class="row">
			<div class="col-4">
				<label>Upload Quatation : </label>
			</div>
			<div class="col-8">
				<asp:FileUpload ID="quatationDoc" runat="server" Width="250px" CssClass="form-control form-control-user"/>
<%--				<asp:TextBox ID="fielNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>--%>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-4">
				<label>Engineer Report After Quatation : </label>
			</div>
			<div class="col-8">
				<asp:FileUpload ID="engineerReportDoc" runat="server" Width="250px" CssClass="form-control form-control-user"/>
<%--				<asp:TextBox ID="fielNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>--%>
			</div>
		</div><br /> 

		
		<div class="row">
			<div class="col-2">
				<asp:Button runat="server" ID="Button3" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" />
			</div>
			<div class="col-5">
				<asp:Button runat="server" ID="btnSave" Text="Send to Recommondation" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click" />
			</div>
			<div class="col-2">
				<asp:Button runat="server" ID="Button1" Text="Clear" CssClass="btn btn-primary btn-user btn-block" OnClick="btnClear_Click" />
			</div>
		</div><br />

    </div>
</asp:Content>
