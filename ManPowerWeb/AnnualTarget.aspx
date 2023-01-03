<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnnualTarget.aspx.cs" Inherits="ManPowerWeb.AnnualTarget" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card ml-4 p-4">
            <h2>Annual Targets</h2>
            <div class="mt-3">


                <div class="row mb-3 ms-1">

                    <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal1" runat="server" Text="Year"></asp:Literal>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="btn  btn-primary dropdown-toggle">
                                    <asp:ListItem Value="2020">2020</asp:ListItem>
                                    <asp:ListItem Value="2021">2021</asp:ListItem>
                                    <asp:ListItem Value="2022">2022</asp:ListItem>
                                    <asp:ListItem Value="2023">2023</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal2" runat="server" Text="Month"></asp:Literal>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="btn btn-primary dropdown-toggle">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>



                </div>


                <div class="row mb-5 ms-1">
                    <div class="col-sm-3">

                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info btn-user btn-block" Text="Search" OnClick="btnSearch_Click" />


                    </div>
                </div>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-3">



                        <asp:Button ID="btnAddNewTarget" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Add New Target" OnClick="btnAddNewTarget_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView Style="margin-top: 30px;" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ProgramTargetId" HeaderText="ID" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="TargetYear" HeaderText="YEAR" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="TargetMonth" HeaderText="TARGET MONTH" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="StartDate" HeaderText="START DATE" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="Description" HeaderText="DESCRIPTION" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="Title" HeaderText="TITLE" HeaderStyle-CssClass="table-dark" />
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark" >
						<ItemTemplate>
							<asp:LinkButton ID="LinkButton1" runat="server" Text="View" CssClass="btn btn-info" Width="100px"
								a href ='<%#"ProgramTargetView.aspx?id="+DataBinder.Eval(Container.DataItem,"ProgramTargetId") %>'/>
						</ItemTemplate>
					</asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


    </div>

</asp:Content>
