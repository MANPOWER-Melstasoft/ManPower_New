<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompletedPrograms.aspx.cs" Inherits="ManPowerWeb.CompletedPrograms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <div class="container">
        <div class="card m-4 p-4">
            <h2>Completed Programs</h2>
            <div class="row mt-5 mb-4">
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
            <asp:Button ID="Button2" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" Style="width: 120px;" />
        </div>



        <%--   <div class="row">
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
        <%--        </div>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" Style="width: 120px;" />--%>

        <%--<a href="DME24.aspx">
			<input type="button" class="btn btn-primary" style="width:200px;" value="Completed Programs"/>
		</a>--%>


        <div class="table-responsive " style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"
                ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                <Columns>
                    <asp:BoundField DataField="_ProgramTarget.Title" HeaderText="Program Target Name" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="ProgramName" HeaderText="Program Name" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="Date" HeaderText="Date" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="Location" HeaderText="Location" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="ApprovedDate" HeaderText="Approved Date" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="MaleCount" HeaderText="Male Count" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="FemaleCount" HeaderText="Female Count" HeaderStyle-CssClass="table-dark" />
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info"
                                a href='<%#"CompletedProgramsView.aspx?id="+DataBinder.Eval(Container.DataItem,"ProgramPlanId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>No Completed Programs to Show </EmptyDataTemplate>
            </asp:GridView>
        </div>

    </div>
</asp:Content>
