<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalFiles.aspx.cs" Inherits="ManPowerWeb.PersonalFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
    <h2>Personal Files Management</h2>
        <br /><br />

		<%--<%int count = 0; %>
		<%if (Count == 0) { %>--%>

		<div id="id0" runat="server">
			<h4><b>Personal Details</b></h4>

			<br />
			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Last Name : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="lname" runat="server" Width="250px" CssClass="form-control form-control-user" ></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Initials : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="initial" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Name Denoted by Initials : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="nameOfInitials" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Gender : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlGender" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Ethnicity : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlEthnicity" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Religion : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlReligion" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Date of Birth : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="dob" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Marital Status : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlMaritalStatus" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>NIC : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="nic" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>NIC Issued Date : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="nicIssuedDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br /><br /><br />

			<div class="row">
				<div class="col-8">
<%--					<asp:Button runat="server" ID="Button1" Text="Back" CssClass="btn btn-success btn-user btn-block"  Width ="150px" />--%>
				</div>
				<div class="col-3"  style="text-align:end">
					<asp:Button runat="server" ID="page1" Text="Next" CssClass="btn btn-success btn-user btn-block" Width ="150px"  onClick="page1NextClick"/>
				</div>
			</div><br />
		</div>

	<%---------------------------------------------------------------------%>		

		<%--<% } %>


		<%else if (Count == 1) { %>--%>

		<div id="id1" runat="server">


			<h4><b>Employement Details</b></h4>

			<br />
			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Company Name : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="TextBox1" runat="server" Width="250px" CssClass="form-control form-control-user" ></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Personal File Number : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="personalFileNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Is Resigned : </label>
						</div>
						<div class="col-8">
							<input type="radio" name="fav_language" value="HTML" id="yes" checked />
							<label for="yes">Yes</label>
							&nbsp&nbsp&nbsp
							<input type="radio" name="fav_language" value="HTML" id="no" />
							<label for="no">No</label>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Employee Number : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="empNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Start Date : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="sDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>End Date : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="eDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Retired Date : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="retiredDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Epf : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="epf" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br /><br /><br />

			<div class="row">
				<div class="col-8">
					<asp:Button runat="server" ID="page21" Text="Previous" CssClass="btn btn-success btn-user btn-block"  Width ="150px" onClick="page2PrevClick"/>
				</div>
				<div class="col-3"  style="text-align:end">
					<asp:Button runat="server" ID="page22" Text="Next" CssClass="btn btn-success btn-user btn-block" Width ="150px" onClick="page2NextClick" />
				</div>
			</div><br />

	</div>
		<%--<% } %>

		<%else if (Count == 2) { %>--%>

		<%-----------------------------------------------------------%>

		<div id="id2" runat="server">
			<h4><b>Dependant Details</b></h4>

			<br />
			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Dependant Type : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlDependant" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Relationship : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="dependantRelationship" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>First Name : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="dependantFname" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Last Name : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="dependantLname" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Date of Birth: </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="depDob" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Birth Certificate Number : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="bcNumber" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Passport Number : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="ppNumber" runat="server" Width="250px" CssClass="form-control form-control-user" ></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Any Kind of Special Sickness : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="sickness" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<%if (int.Parse(ddlDependant.SelectedValue) == 1)
              { %>

					<div class="row">
						<div class="col-5">
							<div class="row">
								<div class="col-4" >
									<label>Marriage Date : </label>
								</div>
								<div class="col-8">
									<asp:TextBox ID="mDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
								</div>
							</div>
						</div>

						<div class="col-7">
							<div class="row">
								<div class="col-4" >
									<label>Marriage Certificate Number : </label>
								</div>
								<div class="col-8">
									<asp:TextBox ID="mCertificateNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
								</div>
							</div>
						</div>
					</div><br />

					<div class="row">
						<div class="col-5">
							<div class="row">
								<div class="col-4" >
									<label>Nic Number : </label>
								</div>
								<div class="col-8">
									<asp:TextBox ID="depNic" runat="server" Width="250px" CssClass="form-control form-control-user" ></asp:TextBox>
								</div>
							</div>
						</div>

						<div class="col-7">
							<div class="row">
								<div class="col-4" >
									<label>Working Company : </label>
								</div>
								<div class="col-8">
									<asp:TextBox ID="workingCompany" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
								</div>
							</div>
						</div>
					</div><br />
			<%} %>

		<br /><br />

			<asp:Button runat="server" ID="add" Text="Add" CssClass="btn btn-primary btn-user btn-block"  Width ="150px" OnClick="addDependant"/>

			<br /><br />

		<div cssClass="table-responsive" style="width: 100%;">
            <asp:GridView Style="margin-top: 30px;" ID="dependantGV" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None">
                <Columns>
                    <asp:BoundField HeaderText="First Name" DataField="FirstName" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Last Name" DataField="LastName" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Dependant NIC" DataField="DependantNIC" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Dependant Passport No" DataField="DependantPassportNo" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Date of Birth" DataField="Dob" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Relationship to Employee" DataField="RelationshipToEmp" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="BirthCertificate Number" DataField="BirthCertificateNumber" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Special Sickness" DataField="Remarks" HeaderStyle-CssClass="table-dark" />
                </Columns>
            </asp:GridView>
		</div>

		<%--<% } %>--%>

		<div class="row">
			<div class="col-8">
				<asp:Button runat="server" ID="page31" Text="Previous" CssClass="btn btn-success btn-user btn-block"  Width ="150px" onClick="page3PrevClick"/>
			</div>
			<div class="col-3"  style="text-align:end">
				<asp:Button runat="server" ID="page32" Text="Next" CssClass="btn btn-success btn-user btn-block" Width ="150px" onClick="page3NextClick" />
			</div>
		</div><br />
	</div>

		<%---------------------------------------------------------%>

		<div id="id3" runat="server">
			<h4><b>Contact Details</b></h4>

			<br />
			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Address : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="address" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Devisional Secretary : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="devsec" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>City / Town : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="city" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>District : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="district" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Telephone : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="telephone" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Postal Code : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="postalCode" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Personal Email : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="email" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

		<br /><br />

		<%--<% } %>--%>


			<h4><b>Emergency Contact Details</b></h4>

			<br /><br />
			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Name : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="ecName" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Home Telephone Number : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="landLine" runat="server" Width="250px" CssClass="form-control form-control-user" ></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Relationship To Employee : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="ecRelationship" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Office Phone Number : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="ecOfficePhone" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Address of Emergancy Contact Person : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="ecAddress" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Mobile Number : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="ecMobile" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Personal Email : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="ecEmail" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

		<br /><br />

		<%--<% } %>--%>

		<div class="row">
			<div class="col-8">
				<asp:Button runat="server" ID="page41" Text="Previous" CssClass="btn btn-success btn-user btn-block"  Width ="150px" onClick="page4PrevClick"/>
			</div>
			<div class="col-3"  style="text-align:end">
				<asp:Button runat="server" ID="page42" Text="Next" CssClass="btn btn-success btn-user btn-block" Width ="150px" onClick="page4NextClick" />
			</div>
		</div><br />
	</div>

		
		<%-----------------------------------------------------------%>

		<div id="id4" runat="server">
			<h4><b>Education Details</b></h4>

			<br /><br />
			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Education Type : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlEducation" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Institute / School / University : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="uni" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Attempt : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlAttempt" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Year : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlYear" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Index Number: </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="index" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Subject : </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="sub" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Stream : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="stream" runat="server" Width="250px" CssClass="form-control form-control-user" ></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Grade : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="grade" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Status : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="status" runat="server" Width="250px" CssClass="form-control form-control-user" ></asp:TextBox>
						</div>
					</div>
				</div>
				
			</div>

			<br /><br />

		<%--<% } %>--%>

		<div class="row">
			<div class="col-8">
				<asp:Button runat="server" ID="aa" Text="Previous" CssClass="btn btn-success btn-user btn-block"  Width ="150px" onClick="page5PrevClick"/>
			</div>
			<div class="col-3"  style="text-align:end">
				<asp:Button runat="server" ID="Button2" Text="Next" CssClass="btn btn-success btn-user btn-block" Width ="150px" onClick="page5NextClick" />
			</div>
		</div><br />
	</div>

		<div id="id5" runat="server">
			<h4><b>Employee Services Details</b></h4>

			<br /><br />
			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Service Type : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlService" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Date of Appointment: </label>
						</div>
						<div class="col-8" style="text-align:right">
							<asp:TextBox ID="appointmentDate" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>First Name : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="TextBox14" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
						</div>
					</div>
				</div>

				<div class="col-7">
					<div class="row">
						<div class="col-4" >
							<label>Date Assumed Duty : </label>
						</div>
						<div class="col-8">
							<asp:TextBox ID="TextBox15" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
						</div>
					</div>
				</div>
			</div><br />

			<%if (int.Parse(ddlService.SelectedValue) == 2)
            { %>

				<div class="row">
					<div class="col-5">
						<div class="row">
							<div class="col-4" >
								<label>Medium of Recruitment : </label>
							</div>
							<div class="col-8" style="text-align:right">
								<asp:TextBox ID="medium" runat="server" Width="250px" CssClass="form-control form-control-user" ></asp:TextBox>
							</div>
						</div>
					</div>

					<div class="col-7">
						<div class="row">
							<div class="col-4" >
								<label>Method of Recruitment : </label>
							</div>
							<div class="col-8" style="text-align:right">
								<asp:TextBox ID="method" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
							</div>
						</div>
					</div>
				</div><br />

			<%} %>

			<div class="row">
				<div class="col-5">
					<div class="row">
						<div class="col-4" >
							<label>Is Confirmed : </label>
						</div>
						<div class="col-8">
							<asp:DropDownList ID="ddlConformation" Width="250px" runat="server" AutoPostBack="true" Class="btn  btn-primary dropdown-toggle"
								data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
						</div>
					</div>
				</div>
			</div>

		<br /><br />


		<%--<% } %>--%>

		<div class="row">
			<div class="col-8">
				<asp:Button runat="server" ID="Button1" Text="Previous" CssClass="btn btn-success btn-user btn-block"  Width ="150px" onClick="page6PrevClick"/>
			</div>
			<div class="col-3"  style="text-align:end">
<%--				<asp:Button runat="server" ID="Button2" Text="Next" CssClass="btn btn-success btn-user btn-block" Width ="150px" />--%>
			</div>
		</div><br />
	</div>

    </div>
</asp:Content>

