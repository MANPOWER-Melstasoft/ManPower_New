<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompletedPrograms.aspx.cs" Inherits="ManPowerWeb.CompletedPrograms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin:40px;padding:30px">
        <h2>Completed Programs</h2>
        <br /><br />

        <div class="row">
			<div class="col-6">
				<div class="row">
					<div class="col-3">
						<label>Date : </label>
					</div>
					<div class="col-7">
						<asp:TextBox ID="TextBox4" runat="server" name="date" Width="230px" CssClass="form-control form-control-user" TextMode="DateTimeLocal"></asp:TextBox>
					</div>
				</div>
			</div>
			<%--<div class="col-6">
				<div class="row">
					<div class="col-5">
						<label>Type the program :</label>
					</div>
					<div class="col-7">
						<asp:DropDownList ID="ddl1" Width="230px" runat="server" AutoPostBack="true" CssClass="btn  btn-primary dropdown-toggle dropdown-toggle-split" 
							data-bs-toggle="dropdown" aria-expanded="false">
								<asp:ListItem Value=1>Online</asp:ListItem>
                                <asp:ListItem Value=2>Physical</asp:ListItem>
						</asp:DropDownList>
					</div>
				</div>
			</div>--%>
		</div>

			<br /><br />
		<asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" style="width:120px;"/>
		<br /><br />
		<%--<a href="DME24.aspx">
			<input type="button" class="btn btn-primary" style="width:200px;" value="Completed Programs"/>
		</a>--%>


			<div class="table-responsive" style="width: 100%;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="ConductDate" HeaderText="Date" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="ConductLocation" HeaderText="Location" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="ApprovedDate" HeaderText="Approved Date" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="MaleCount" HeaderText="Male Count" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="FemaleCount" HeaderText="Female Count" HeaderStyle-CssClass="table-dark" />
					<asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" >
						<ItemTemplate>
							<asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-success"
								a href ='<%#"CompletedProgramsView.aspx?id="+DataBinder.Eval(Container.DataItem,"ProgramPlanId") %>'/>
						</ItemTemplate>
					</asp:TemplateField>
                </Columns>
            </asp:GridView>
			</div>
			
    </div>
</asp:Content>
