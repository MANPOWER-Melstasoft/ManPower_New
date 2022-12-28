<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpcomingPrograms.aspx.cs" Inherits="ManPowerWeb.UpcomingPrograms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
            <h2>Upcomming Programs</h2>
        <br /><br />

        <div class="row">
			<div class="col-6">
				<div class="row">
					<div class="col-3">
						<label>Date : </label>
					</div>
					<div class="col-7">
						<asp:TextBox ID="TextBox4" runat="server" name="date" Width="230px" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
					</div>
				</div>
			</div>
			<div class="col-6">
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
			</div>
		</div>

			<br /><br />
		<asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" style="width:120px;" />
		<%--<button type="button" class="btn btn-primary" style="width:120px;">Search</button>
		<br /><br />
		<a href="DME24.aspx">
			<input type="button" class="btn btn-primary" style="width:200px;" value="Completed Programs"/>
		</a>--%>

			<%--<div class="table-responsive" style="width: 100%;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None">
                <Columns>
                    <asp:BoundField HeaderText="Program Name" DataField="Title" />
                    <asp:BoundField HeaderText="Target Month" DataField="TargetMonth" />
                    <asp:BoundField HeaderText="Start Date" DataField="StartDate" />
                    <asp:BoundField HeaderText="Outcome" DataField="Outcome" />
                    <asp:BoundField HeaderText="Number of Projects" DataField="NoOfProjects" />
                    <asp:BoundField HeaderText="Estimated Amount" DataField="EstimatedAmount" />
                </Columns>
            </asp:GridView>
			</div>
        </div>--%>

	<div class="table-responsive" style="width: 100%;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None">
                <Columns>
                    <asp:BoundField HeaderText="Program Name" DataField="Title" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Target Month" DataField="TargetMonth" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Start Date" DataField="StartDate" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Outcome" DataField="Outcome" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Number of Projects" DataField="NoOfProjects" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField HeaderText="Estimated Amount" DataField="EstimatedAmount" HeaderStyle-CssClass="table-dark" />
					<%--<asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" >
						<ItemTemplate>
							<asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
								a href ='<%#"UpcomingprogramsView.aspx?id="+DataBinder.Eval(Container.DataItem,"ProgramTargetId") %>'/>
						</ItemTemplate>
					</asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
			</div>
</asp:Content>
