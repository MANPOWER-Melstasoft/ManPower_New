<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME24.aspx.cs" Inherits="ManPowerWeb.DME24" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container" style="margin:40px;padding:30px">
    <h2>Confirmation of Completed Programs - DME 24 </h2>
        <br /><br />

        
		<div class="row">
			<div class="col-3">
				<label>Name of the program:</label>
			</div>
			<div class="col-9">
				<asp:DropDownList ID="ddlProgramName" Width="230px" runat="server" AutoPostBack="true" CssClass="btn  btn-primary dropdown-toggle dropdown-toggle-split" 
					OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged" data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
			</div>
		</div>

		<br/>

		<div class="row">
			<div class="col-3">
				<label>Place : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox1" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div>
		<br/> 


		<div class="row">
			<div class="col-3">
				<label>Program Conducted Date : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox4" runat="server" name="date" Width="230px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
			</div>
		</div>
		<br />


		<div class="row">
			<div class="col-3">
				<label>Number of Days : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox2" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /> 

		<div class="row">
			<div class="col-3">
				<label>Coordinating Officer : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox3" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /> <br />

		<h4><b>Resource Person </b></h4>
		<br />
		<div class="row">
			<div class="col-3">
				<label>Name : </label>
			</div>
			<div class="col-9">
				<asp:DropDownList ID="ddlResourcePerson" Width="230px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
					OnSelectedIndexChanged="ddlResourcePerson_SelectedIndexChanged" data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Working Place : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox5" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Subject Area / Topic </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox6" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /><br />

		<h4><b>Number Of Beneficiaries </b></h4>
		<br />
		<div class="row">
			<div class="col-3">
				<label>Male Count : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox7" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Female Count : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox8" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Total : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox9" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br /><br />


		<div class="row">
			<div class="col-3">
				<label>Vote Number : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox10" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Financial Source : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-user" Width="230px" TextMode="MultiLine"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Program Type : </label>
			</div>
			<div class="col-9">
				<asp:TextBox ID="TextBox12" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Output : </label>
			</div>
			<div class="col-4">
				<asp:TextBox ID="TextBox13" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
			<div class="col-4">
				<asp:TextBox ID="TextBox14" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Outcome : </label>
			</div>
			<div class="col-4">
				<asp:TextBox ID="TextBox11" runat="server" Width="230px" CssClass="form-control form-control-user" ></asp:TextBox>
			</div>
			<div class="col-4">
				<asp:TextBox ID="TextBox15" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Is Approved : </label>
			</div>
			<div class="col-9">
				<div class="form-check">
				  <input class="form-check-input" type="radio" name="flexRadioDefault" id="yes" checked />
				  <label class="form-check-label" for="yes">
					Yes
				  </label>
					&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
				<input class="form-check-input" type="radio" name="flexRadioDefault" id="no" />
				  <label class="form-check-label" for="no">
					No
				  </label>
				</div>
			</div>
		</div><br />

		<div class="row">
			<div class="col-3">
				<label>Program Type : </label>
			</div>
			<div class="col-9">
				<input type="radio" name="fav_language" value="HTML" id="online" checked />
				<label for="online">Online</label>
				&nbsp&nbsp&nbsp
				<input type="radio" name="fav_language" value="HTML" id="phy" />
				<label for="phy">Physical</label>
			</div>
		</div><br /><br /><br />

		<div class="row">
			<div class="col-2">
				<button type="button" class="btn btn-primary" style="width:115px;">Save</button>
			</div>
			<div class="col-2">
				<button type="button" class="btn btn-primary" style="width:115px;">Submit</button>
			</div>
			<div class="col-2">
				<button type="button" class="btn btn-primary" style="width:115px;">Clear</button>
			</div>
		</div><br />

    </div>

</asp:Content>

