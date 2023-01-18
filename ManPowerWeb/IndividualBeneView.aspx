<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndividualBeneView.aspx.cs" Inherits="ManPowerWeb.IndividualBeneView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="padding-left: 30px;">
        <h2>Individual Beneficiary </h2>

        <div class="row mt-5">
            <div class="col-2">
                <label>NIC :</label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="nic" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
            <div class="col-2">
                <label>Name : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="name" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
            </div>
        </div>

        <%----------------------------------------------------------------------------%>
        <div class="row mt-4">

            <div class="col-2">
                <label>Gender : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="gender" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

            <div class="col-2">
                <label>Date of Birth : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="dob" runat="server" name="date" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

        </div>
        <%---------------------------------------------------------------------------------------------%>


        <div class="row mt-4">

            <div class="col-2">
                <label>Personal Address : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="address" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

            <div class="col-2">
                <label>Email : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="email" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

        </div>

        <%-----------------------------------------------------------------------------------%>

        <div class="row mt-4">

            <div class="col-2">
                <label>Job Preference : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="jobType" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

            <div class="col-2">
                <label>Contact Number : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="contact" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

        </div>

        <%--------------------------------------------------------------------------------------%>

        <div class="row mt-4">

            <div class="col-2">
                <label>Whatsapp Number : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="whatsapp" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

            <div class="col-2">
                <label>Name of the School : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="sclName" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

        </div>

        <%-------------------------------------------------------------------------------------------%>

        <div class="row mt-4">

            <div class="col-2">
                <label>Address of School : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="sclAddress" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

            <div class="col-2">
                <label>Grade : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="grade" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

        </div>

        <%-------------------------------------------------------------------------------------------------%>

        <div class="row mt-4">

            <div class="col-2">
                <label>Parent NIC : </label>
            </div>
            <div class="col-3">
                <asp:TextBox ID="parentNic" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
            </div>

        </div>

        <div class="row mb-5 mt-5">
            <div class="col-2">
                <asp:Button runat="server" ID="btnSave" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" ValidationGroup="1" />
            </div>
        </div>

        <%----------------------------------------------------------------------------------------------%>

        <div class="card p-5">
            <ul class="nav nav-tabs">
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#results">Career Key Test Results</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#training">Training Refferals</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#job">Job Refferals</a></li>
            </ul>

            <div class="tab-content mt-5">
                <div id="results" class="tab-pane fade in active mr-4">
                    <h3>Career Key Test Results </h3>

                    <div class="row mt-5">
                        <div class="col-2">
                            <label>R :</label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="r" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                        <div class="col-2">
                            <label>I : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="i" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>

                    <%----------------------------------------------------------------------------%>
                    <div class="row mt-4">

                        <div class="col-2">
                            <label>A : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="a" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>

                        <div class="col-2">
                            <label>S: </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="s" runat="server" name="date" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>

                    </div>
                    <%---------------------------------------------------------------------------------------------%>


                    <div class="row mt-4">

                        <div class="col-2">
                            <label>E : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="e" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>

                        <div class="col-2">
                            <label>C : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>

                    </div>

                    <%-----------------------------------------------------------------------------------%>

                    <div class="row mt-4">

                        <div class="col-2">
                            <label>Provided Guidance : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="guidance" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                        </div>

                        <div class="col-2">
                            <label>Held Date : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="date" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>

                    </div>

                    <%--------------------------------------------------------------------------------------%>

                    <div class="row mt-5 mb-4">
                        <div class="col-2">
                            <asp:Button runat="server" ID="Button1" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" ValidationGroup="1" />
                        </div>
                    </div>

                    <%----------------------------------------------------------------------------------------------%>
                </div>

                <%---------tab 2---------%>

                <div id="training" class="tab-pane fade">
                    <h3>Training Refferals </h3>

                    <div class="row mt-5">
                        <div class="col-2">
                            <label>Institute Name :</label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="institute" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                        <div class="col-2">
                            <label>Training Course : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="course" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>
                    </div>

                    <%----------------------------------------------------------------------------%>
                    <div class="row mt-4">

                        <div class="col-2">
                            <label>Contact Person Name : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="contactPersonName" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>

                        <div class="col-2">
                            <label>Contact Number: </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="contactNo" runat="server" name="date" CssClass="form-control form-control-user"></asp:TextBox>
                        </div>

                    </div>
                    <%---------------------------------------------------------------------------------------------%>


                    <div class="row mt-4">

                        <div class="col-2">
                            <label>Refferals Date : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="trainingRefferalDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mt-5 mb-4">
                        <div class="col-2">
                            <asp:Button runat="server" ID="Button2" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" ValidationGroup="1" />
                        </div>
                    </div>


                    <%----------------------------------------------------------------------------------------------%>
                </div>

                <%--------tab 3 --------%>

                <div id="job" class="tab-pane fade">
                    <h3>Job Refferals</h3>

                    <div class="row mt-5">
                        <div class="col-2">
                            <label>Company Vacancies :</label>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList ID="ddl" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                        </div>

                        <div class="col-2">
                            <label>Job Category : </label>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <%----------------------------------------------------------------------------%>
                    <div class="row mt-4">

                        <div class="col-2">
                            <label>Remarks : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="jobRefferalRemark" runat="server" name="place" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                        </div>

                        <div class="col-2">
                            <label>Job Placement Date: </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="jobPlacememntDate" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>

                    </div>
                    <%---------------------------------------------------------------------------------------------%>

                    <div class="row mt-4">

                        <div class="col-2">
                            <label>Career Guidance : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="careerGuidance" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                        </div>

                        <div class="col-2">
                            <label>Job Refferals Date: </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="jobRefferalsDate" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                        </div>

                    </div>
                    <%---------------------------------------------------------------------------------------------%>

                    <div class="row mt-5 mb-4">
                        <div class="col-2">
                            <asp:Button runat="server" ID="Button3" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" ValidationGroup="1" />
                        </div>
                    </div>


                    <%----------------------------------------------------------------------------------------------%>
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


