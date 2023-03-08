<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DME37Search.aspx.cs" Inherits="ManPowerWeb.DME37Search" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container">
        <div class="card ml-4 p-4">
            <h2>DME 37</h2>


            <div class="mt-3">


                <div class="row mb-3 ms-1">

                    <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal3" runat="server" Text="Year"></asp:Literal>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="btn  btn-primary dropdown-toggle">
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

                                <asp:Literal ID="Literal4" runat="server" Text="Month"></asp:Literal>
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
                            <div class="col-md-2">
                            </div>
                        </div>
                    </div>



                </div>


                <div class="row mb-5 ms-1">
                    <div class="col-sm-3">

                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success btn-user btn-block" Text="Search" OnClick="btnSearch_Click" />


                    </div>
                </div>

                <div class="row mb-3 ms-1">
                    <div class="col-sm-3">



                        <asp:Button ID="btnAddVacancy" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Add Vacancy" OnClick="btnAddVacancy_Click" />
                    </div>
                </div>
            </div>


        </div>

        <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
            <asp:GridView Style="margin-top: 30px;" ID="gv1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="gv1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="VDate" DataFormatString="{0:yyyy/MM/dd}" HeaderText="DATE" HeaderStyle-CssClass="table-dark" />

                    <asp:BoundField DataField="VAddress" HeaderText="ADDRESS" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="WebSiteLink" HeaderText="WEBSITE LINK" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="BusinessRegistationNumber" HeaderText="BUSINESS REGISTRATION NO." HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="JobPosition" HeaderText="JOB POSITION" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="VLevels" HeaderText="LEVEL" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="SalaryLevel" HeaderText="SALARY LEVEL" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="NumberOfVacancy" HeaderText="NO. VACANCY" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="ContactPersonName" HeaderText="NAME" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="ContactPersonPosition" HeaderText="POSITION" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="ContactNumber" HeaderText="CONTACT NO." HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="WhatsappNumber" HeaderText="WHATSAPP NO." HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="ContactPersonEmail" HeaderText="EMAIL" HeaderStyle-CssClass="table-dark" />


                </Columns>
            </asp:GridView>
        </div>


    </div>

</asp:Content>
