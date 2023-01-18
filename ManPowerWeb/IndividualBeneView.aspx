<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndividualBeneView.aspx.cs" Inherits="ManPowerWeb.IndividualBeneView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="padding-left: 30px;">
        <h2>Individual Beneficiary Registration</h2>

        <div class="row">

            <div class="col-6">
                <div class="col-3">
                    <label>NIC :</label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="nic" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>

            <div class="col-6">
                <div class="col-3">
                    <label>Name : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="name" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>

        </div>

        <%----------------------------------------------------------------------------%>
        <div class="row">
            <div class="col-6">
                <div class="col-3">
                    <label>Gender : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="gender" runat="server" name="place" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>


            <div class="col-6">
                <div class="col-3">
                    <label>Date of Birth : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="dob" runat="server" name="date" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
        </div>
        <%---------------------------------------------------------------------------------------------%>

        <div class="row">
            <div class="col-6">
                <div class="col-3">
                    <label>Personal Address : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="address" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>


            <div class="col-6">
                <div class="col-3">
                    <label>Email : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="email" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
        </div>
        <%-----------------------------------------------------------------------------------%>

        <div class="row">
            <div class="col-6">
                <div class="col-3">
                    <label>Job Preference : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="jobType" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>


            <div class="col-6">
                <div class="col-3">
                    <label>Contact Number : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="contact" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>
        </div>

        <%--------------------------------------------------------------------------------------%>

        <div class="row">
            <div class="col-6">
                <div class="col-3">
                    <label>Whatsapp Number : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="whatsapp" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>



            <div class="col-6">
                <div class="col-3">
                    <label>Name of the School : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="sclName" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>

        </div>

        <%-------------------------------------------------------------------------------------------%>

        <div class="row">
            <div class="col-6">
                <div class="col-3">
                    <label>Address of the School : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="sclAddress" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>

            <div class="col-6">
                <div class="col-3">
                    <label>Grade : </label>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="grade" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
                </div>
            </div>

        </div>

        <%-------------------------------------------------------------------------------------------------%>

        <div class="row">
            <div class="col-3">
                <label>Parent NIC : </label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="parentNic" runat="server" Width="230px" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-5">
            <div class="col-2">
                <asp:Button runat="server" ID="btnSave" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" ValidationGroup="1" />
            </div>
        </div>

        <%----------------------------------------------------------------------------------------------%>

        <div class="card">
            <ul class="nav nav-tabs">
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#home">Home</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#menu1">Menu 1</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#menu2">Menu 2</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#menu3">Menu 3</a></li>
            </ul>

            <div class="tab-content">
                <div id="home" class="tab-pane fade in active mr-4">
                    <h3>HOME</h3>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                </div>
                <div id="menu1" class="tab-pane fade">
                    <h3>Menu 1</h3>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                </div>
                <div id="menu2" class="tab-pane fade">
                    <h3>Menu 2</h3>
                    <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam.</p>
                </div>
                <div id="menu3" class="tab-pane fade">
                    <h3>Menu 3</h3>
                    <p>Eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.</p>
                </div>
            </div>
        </div>
    </div>

    <style>
        .nav-tabs .nav-link {
            color: gray;
            border: 0;
            border-bottom: 1px solid red;
        }

            .nav-tabs .nav-link:hover {
                border: 0;
                border-bottom: 1px solid grey;
            }

            .nav-tabs .nav-link.active {
                color: #000000;
                border: 0;
                border-radius: 0;
                border-bottom: 2px solid blue;
            }
    </style>
</asp:Content>


