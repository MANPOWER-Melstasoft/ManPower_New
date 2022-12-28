<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourcePersonRegSearch.aspx.cs" Inherits="ManPowerWeb.ResourcePersonRegSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <h2>Resource Person Registration</h2>
        <br /><br />

        <div class="row">
			<div class="col-6">
				<div class="row">
					<div class="col-3">
						<label>Designation : </label>
					</div>
					<div class="col-7">
						<asp:TextBox ID="desig" runat="server"  Width="230px" CssClass="form-control form-control-user"></asp:TextBox>			
					</div>
				</div>
			</div>
			<div class="col-6">
				<div class="row">
					<div class="col-5">
						<label>Resource Person Type :</label>
					</div>
					<div class="col-7">
						<asp:DropDownList ID="ddlType" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
					</div>
				</div>
			</div>
		</div>

			<br /><br />
		<asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" style="width:120px;" />

		<br /><br />

		<a href="ResourcePersonReg.aspx">
			<asp:Button ID="Button2" runat="server" Text="Add New Resource Person" OnClick="isClicked" CssClass="btn btn-primary" style="width:220px;" />
		</a>

		<br /><br />

		<div class="table-responsive" style="width: 100%;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None">
                <Columns>
					<asp:BoundField HeaderText="Resource Person Type" DataField="ResourcePersonType" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Designation" DataField="Designation" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Name" DataField="Name" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="WorkPlace" DataField="WorkPlace" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Qualifications" DataField="Qualifications" HeaderStyle-CssClass="table-dark" />
					<asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" >
						<ItemTemplate>
							<asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
								a href ='<%#"ResourcePersonView.aspx?id="+DataBinder.Eval(Container.DataItem,"ResoursePersonId") %>'/>
						</ItemTemplate>
					</asp:TemplateField>
                </Columns>
            </asp:GridView>
		</div>
	</div>
</asp:Content>
