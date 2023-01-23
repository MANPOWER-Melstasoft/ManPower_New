<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VacancyReg.aspx.cs" Inherits="ManPowerWeb.VacancyReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card p-4 ml-4">
            <h2>Company / Vacancy Registration Details</h2>



            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row ">
                        <div class="col-4">
                            <asp:Literal ID="Literal1" runat="server" Text="Date"></asp:Literal>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="date" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>


                <div class="col-6">
                    <div class="row ">
                        <div class="col-4">
                            <asp:Literal ID="Literal2" runat="server" Text="Address"></asp:Literal>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="address" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>

                </div>
            </div>

            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Website Link </label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="link" runat="server" name="place" Width="250px" CssClass="form-control form-control-user" TextMode="Url"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Business Registration Number</label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="regNo" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>



            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Vacancy Type / Job Position</label>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="vanacnyType" runat="server" name="place" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Carrer Path / Achived Highest Position </label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="ddlPositions" Width="250px" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Level</label>
                        </div>
                        <div class="col-8">
                            <asp:DropDownList ID="ddlLevel" Width="250px" runat="server" AutoPostBack="true" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Salary Level</label>
                        </div>
                        <div class="col-8">
                            <asp:TextBox ID="salary" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row pl-3 mt-5 mb-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Number of Vacancies  </label>
                        </div>
                        <div class="col-8">
                            <asp:TextBox ID="NoOfVacancy" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <h4><b>Contact Person Details</b></h4>


            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Name </label>
                        </div>
                        <div class="col-8">
                            <asp:TextBox ID="name" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Position  </label>
                        </div>
                        <div class="col-8">
                            <asp:TextBox ID="position" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Contact Number</label>
                        </div>
                        <div class="col-8">
                            <asp:TextBox ID="contact" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Whatsapp Number</label>
                        </div>
                        <div class="col-8">
                            <asp:TextBox ID="whatsapp" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4">
                            <label>Email : </label>
                        </div>
                        <div class="col-8">
                            <asp:TextBox ID="email" runat="server" Width="250px" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row pl-3 mt-5">
                <div class="col-6">
                    <div class="row">
                        <div class="col-2">
                            <asp:Button runat="server" ID="Button3" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" />
                        </div>
                        <div class="col-2">
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click" />
                        </div>
                        <div class="col-2">
                            <asp:Button runat="server" ID="Button1" Text="Clear" CssClass="btn btn-primary btn-user btn-block" OnClick="btnClear_Click" />
                        </div>
                    </div>
                </div>
    </div>

    </div>
    </div>
</asp:Content>
