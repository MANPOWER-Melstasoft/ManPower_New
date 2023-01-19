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
                <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#results">Career Key Test Results</a></li>
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
                            <asp:TextBox ID="txtR" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtR" ValidationGroup="1"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-2">
                            <label>I : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="txtI" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtI" ValidationGroup="1"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <%----------------------------------------------------------------------------%>
                    <div class="row mt-4">

                        <div class="col-2">
                            <label>A : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="txtA" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtA" ValidationGroup="1"></asp:RequiredFieldValidator>

                        </div>

                        <div class="col-2">
                            <label>S: </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="txtS" runat="server" name="date" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtS" ValidationGroup="1"></asp:RequiredFieldValidator>

                        </div>

                    </div>
                    <%---------------------------------------------------------------------------------------------%>


                    <div class="row mt-4">

                        <div class="col-2">
                            <label>E : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="txtE" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtE" ValidationGroup="1"></asp:RequiredFieldValidator>

                        </div>

                        <div class="col-2">
                            <label>C : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="txtC" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtC" ValidationGroup="1"></asp:RequiredFieldValidator>

                        </div>

                    </div>

                    <%-----------------------------------------------------------------------------------%>

                    <div class="row mt-4">

                        <div class="col-2">
                            <label>Provided Guidance : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="txtGuidance" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtGuidance" ValidationGroup="1"></asp:RequiredFieldValidator>

                        </div>

                        <div class="col-2">
                            <label>Held Date : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="TxtHeldDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtHeldDate" ValidationGroup="1"></asp:RequiredFieldValidator>

                        </div>

                    </div>

                    <%--------------------------------------------------------------------------------------%>

                    <div class="row mt-5 mb-4">
                        <div class="col-2">
                            <asp:Button runat="server" ID="btnSubmit1" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmit1_Click" ValidationGroup="1" />
                        </div>
                    </div>

                    <%----------------------------------------------------------------------------------------------%>
                    <div class="table-responsive">
                        <asp:GridView ID="gvAnnaualPlan" runat="server" AutoGenerateColumns="false" CssClass=" table-bordered mt-4 ParentGrid mb-4"
                            DataKeyNames="Id" OnRowDataBound="gvAnnaualPlan_RowDataBound" GridLines="None" HeaderStyle-CssClass="GridHeader" HeaderStyle-HorizontalAlign="Center">
                            <Columns>
                                <asp:TemplateField HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <a href="javascript:collapseExpand('ProgramTargetId-<%# Eval("Id") %>');">
                                            <img alt="Details" id="imageProgramTargetId-<%# Eval("Id") %> " src="img/plus.png" border="0" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="R" HeaderText="Id" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="I" HeaderText="Description" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="A" HeaderText="Target Year" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="S" HeaderText="Target Month" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="C" HeaderText="Start Date" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="E" HeaderText="Start Date" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="CreatedUser" HeaderText="Estimate Amount" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="Id" HeaderText="Instruction" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="Date" HeaderText="No of Projects" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" />


                                <asp:TemplateField HeaderText="ACTION" HeaderStyle-Width="300px" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnAddPlan" CssClass="btn btn-success" data-toggle="modal" data-target="#exampleModalCenter">Add Program Plan</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <tr>
                                            <td colspan="999">
                                                <div id="ProgramTargetId-<%# Eval("Id") %>" style="display: none; position: relative;">
                                                    <asp:GridView ID="gvPlanDetails" runat="server" AutoGenerateColumns="false" CssClass="table  ChildGrid" EmptyDataText="No Item Found"
                                                        OnRowEditing="gvPlanDetails_RowEditing" OnRowCancelingEdit="gvPlanDetails_RowCancelingEdit">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("R") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("I") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("S") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="City">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_City" runat="server" Text='<%#Eval("C") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txt_City" runat="server" Text='<%#Eval("E") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" />
                                                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>



                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

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
                            <asp:Button runat="server" ID="btn2Submit" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btn2Submit_Click" ValidationGroup="2" />
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
                            <asp:DropDownList ID="ddlCompanyVacancies" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob2" runat="server" ValidationGroup="Job"
                                    ControlToValidate="ddlCompanyVacancies" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-2">
                            <label>Job Category : </label>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList ID="ddlJobCategory" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob1" runat="server" ValidationGroup="Job"
                                    ControlToValidate="ddlJobCategory" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                    <div class="row mt-4">

                        <div class="col-2">
                            <label>Job Refferals Date: </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="jobRefferalsDate" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob3" runat="server" ValidationGroup="Job"
                                    ControlToValidate="jobRefferalsDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-2">
                            <label>Job Placement Date: </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="jobPlacememntDate" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob4" runat="server" ValidationGroup="Job"
                                    ControlToValidate="jobPlacememntDate" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>


                    <div class="row mt-4">

                        <div class="col-2">
                            <label>Career Guidance : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="careerGuidance" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob5" runat="server" ValidationGroup="Job"
                                    ControlToValidate="careerGuidance" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-2">
                            <label>Remarks : </label>
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="jobRefferalRemark" runat="server" name="place" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                        </div>

                    </div>

                    <div class="row mt-5 mb-4">
                        <div class="col-2">
                            <asp:Button runat="server" ID="btnSubmitJobRefferal" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="submitJobRefferal" ValidationGroup="Job" />
                        </div>
                    </div>


                    <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                        <asp:GridView Style="margin-top: 30px;" ID="gvJob" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                            CellPadding="4" GridLines="None" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="SystemUserId" HeaderText="ID" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Name" HeaderText="NAME" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="EmpNumber" HeaderText="EMPLOYEE NUMBER" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Email" HeaderText="EMAIL" HeaderStyle-CssClass="table-dark" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <%----------------------------------------------------------------------------------------------%>
                </div>


                <%------------------- model ----------------------%>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLongTitle">Add Career_Guidance_Feedback</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <center>
                                    <div class="row mb-3 ms-1">
                                        <div class="col-sm-4">
                                            <label>Add Feedback </label>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtrejectReason" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Required" ControlToValidate="txtrejectReason" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </center>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnReject" Text="Reject" CssClass="btn btn-danger" Width="100px" ValidationGroup="1" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <style>
        .nav-tabs .nav-link {
            color: gray;
            border: 0;
            border-bottom: 1px solid grey;
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

        .ChildGrid td {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
            text-align: center;
        }

        .ChildGrid th {
            color: White;
            font-size: 10pt;
            line-height: 200%;
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: center;
            background-color: #67778e !important;
            color: white;
        }
    </style>

    <script type="text/javascript">

        function collapseExpand(obj) {

            var gvObject = document.getElementById(obj);

            var imageID = document.getElementById('image' + obj);



            if (gvObject.style.display == "none") {

                gvObject.style.display = "inline";

                imageID.src = "img/minus.png";

            }

            else {

                gvObject.style.display = "none";

                imageID.src = "img/minus.png";

            }

        }

    </script>

</asp:Content>


