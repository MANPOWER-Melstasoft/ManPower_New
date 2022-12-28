<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntRegistration.aspx.cs" Inherits="ManPowerWeb.EntRegistration" %>
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
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="regNo" ForeColor="Red">*</asp:RequiredFieldValidator>
			</div>
		</div>

		<br/>

		<div class="row">
			<div class="col-3">
				<label>Contact Number : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="contact" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="contact" ForeColor="Red">*</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number."
                                ValidationExpression="^([0-9]{10})$" ControlToValidate="contact" ValidationGroup="1"
                                ForeColor="Red" Display="Dynamic">Invalid Mobile Number</asp:RegularExpressionValidator>
			</div>
		</div>
		<br/> 

		<div class="row">
			<div class="col-3">
				<label>Email : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="email" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="email" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="email" runat="server" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid Email</asp:RegularExpressionValidator>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-3">
				<label>Business Type : </label>
			</div>
			<div class="col-9">
				<asp:DropDownList ID="businessType" Width="230px" runat="server" AutoPostBack="true"  CssClass="dropdown-toggle form-control"></asp:DropDownList>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Nature of Business : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="nature" runat="server" Width="230px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="nature" ForeColor="Red">*</asp:RequiredFieldValidator>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-3">
				<label>Start Date : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="sDate" runat="server" name="date" Width="230px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="sDate" ForeColor="Red">*</asp:RequiredFieldValidator>
			</div>
		</div>
		<br />


		<div class="row">
			<div class="col-3">
				<label>Average Monthly Income : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="income" runat="server" Width="230px" CssClass="form-control form-control-user" ></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="income" ForeColor="Red">*</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="income" runat="server" ErrorMessage="Should be a Nummeric Value" ForeColor="Red" ValidationExpression="\d+$">Should be a Nummeric Value</asp:RegularExpressionValidator>
			</div>
		</div><br /> 

		

		<div class="row">
			<div class="col-3">
				<label>Number of Workers : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="workers" runat="server" Width="230px" CssClass="form-control form-control-user" TextMode="Number"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="workers" ForeColor="Red">*</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="workers" runat="server" ErrorMessage="Should be a Nummeric Value" ForeColor="Red" ValidationExpression="\d+$">Should be a Nummeric Value</asp:RegularExpressionValidator>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-3">
				<label>Market Type : </label>
			</div>
			<div class="col-9">
				<asp:DropDownList ID="marketType" Width="230px" runat="server" AutoPostBack="true"  CssClass="dropdown-toggle form-control"></asp:DropDownList>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>District : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="district" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="district" ForeColor="Red">*</asp:RequiredFieldValidator>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Divisional Secretary : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="ds" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1" ControlToValidate="ds" ForeColor="Red">*</asp:RequiredFieldValidator>
			</div>
		</div><br /><br />

		<h4><b>Facilitatin for Business Plan Preparation</b></h4>
		<br />

		<div class="row">
			<div class="col-3">
				<label>Date : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="date" runat="server" name="date" Width="230px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
				<asp:RequiredFieldValidator ControlToValidate="date" ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1"  ForeColor="Red">*</asp:RequiredFieldValidator>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Bank Loan Arrangement : </label>
			</div>
			<div class="col-9">
				<asp:DropDownList ID="bankLoan" Width="230px" runat="server" AutoPostBack="true"  CssClass="dropdown-toggle form-control"></asp:DropDownList>
			</div>
		</div><br /> <br />

		<div class="row">
			<div class="col-3">
				<label>Facilitation Type : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="fType" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
				<asp:RequiredFieldValidator ControlToValidate="fType" ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="1"  ForeColor="Red">*</asp:RequiredFieldValidator>
			</div>
		</div><br />


		<br />

		<div class="row">
			<div class="col-2">
				<asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click" ValidationGroup="1"/>
			</div>
			<div class="col-2">
				<asp:Button runat="server" ID="Button1" Text="Clear" CssClass="btn btn-primary btn-user btn-block" OnClick="btnClear_Click" />
			</div>
		</div><br />

    </div>
</asp:Content>
