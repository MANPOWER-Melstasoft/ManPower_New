<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndividualBeneView.aspx.cs" Inherits="ManPowerWeb.IndividualBeneView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
    --%>
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
                <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="isClicked" />
            </div>
        </div>

        <%----------------------------------------------------------------------------------------------%>

        <div class="card p-5 mb-3">
            <ul class="nav nav-tabs">
                <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#results">Career Key Test Results</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#training">Training Refferals</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#job">Job Refferals</a></li>
            </ul>

            <div class="tab-content mt-5">
                <div id="results" class="tab-pane fade in active mr-4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="careerkey" runat="server">


                                <h3>Career Key Test Results </h3>

                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>Program Plan</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:DropDownList ID="ddlProgramPlanCarrerKey" runat="server" CssClass="form-control form-control-user" AutoPostBack="true" OnSelectedIndexChanged="ddlProgramPlanCarrerKey_SelectedIndexChanged"></asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlProgramPlanCarrerKey" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                    </div>

                                </div>
                                <div>
                                    <asp:Label runat="server" ID="lblProgramPlanDetails" CssClass="alert-success mt-3" Visible="false"></asp:Label>

                                </div>


                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>R :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtR" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtR" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-2">
                                        <label>I : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtI" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtI" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>
                                </div>

                                <%----------------------------------------------------------------------------%>
                                <div class="row mt-4">

                                    <div class="col-2">
                                        <label>A : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtA" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtA" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>

                                    <div class="col-2">
                                        <label>S: </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtS" runat="server" name="date" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtS" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>

                                </div>
                                <%---------------------------------------------------------------------------------------------%>


                                <div class="row mt-4">

                                    <div class="col-2">
                                        <label>E : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtE" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtE" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>

                                    <div class="col-2">
                                        <label>C : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtC" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtC" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>

                                </div>

                                <%-----------------------------------------------------------------------------------%>

                                <div class="row mt-4">

                                    <div class="col-2">
                                        <label>Provided Guidance : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtGuidance" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtGuidance" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>

                                    <div class="col-2">
                                        <label>Held Date : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="TxtHeldDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtHeldDate" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>

                                </div>

                                <div class="row mt-5 mb-4">
                                    <div class="col-2">
                                        <asp:Button runat="server" ID="btnSubmit1" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmit1_Click" ValidationGroup="1" />
                                    </div>
                                </div>

                            </div>

                            <%--------------------------------------------------------------------------------------%>

                            <div id="careerkeyfeddback" runat="server" visible="false">
                                <h3>Career Key Test Results Feedback </h3>

                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>In Job (Specify) :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtInJob" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtInJob" ValidationGroup="1feed" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-2">
                                        <label>In Training (Specify) : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtTraining" runat="server" name="place" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTraining" ValidationGroup="1feed" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>Remarks :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtRemarksFeedCareer" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                    </div>

                                    <div class="col-3">
                                        <asp:TextBox ID="txtParentId" runat="server" CssClass="form-control form-control-user" Visible="false"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row mt-5 mb-4">
                                    <div class="col-2">
                                        <asp:Button runat="server" ID="Button1Feed" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="Button1Feed_Click" ValidationGroup="1feed" />
                                    </div>
                                </div>


                            </div>
                            <%----------------------------------------------------------------------------------------------%>
                            <div class="table-responsive">
                                <asp:GridView ID="gvAnnaualPlan" runat="server" AutoGenerateColumns="false" CssClass=" table-bordered mt-4 ParentGrid mb-4"
                                    DataKeyNames="Id" OnRowDataBound="gvAnnaualPlan_RowDataBound" GridLines="None" HeaderStyle-CssClass="GridHeader" HeaderStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="table-dark">
                                            <ItemTemplate>
                                                <a href="javascript:collapseExpand('ProgramTargetId-<%# Eval("Id") %>');">
                                                    <img alt="Details" id="imageProgramTargetId-<%# Eval("Id") %> " src="img/Down.png" style="width: 20px; height: 20px" border="0" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="R" HeaderText="R-Marks" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="I" HeaderText="I-Marks" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="A" HeaderText="A-Marks" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="S" HeaderText="S-Marks" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="C" HeaderText="C-Marks" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="E" HeaderText="E-Marks" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="HeldDate" HeaderText="Held Date" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-Width="20%" />


                                        <asp:TemplateField HeaderText="FEEDBACK" ItemStyle-Width="20%" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>

                                                <asp:LinkButton runat="server" ID="btnAddPlan" CssClass="btn btn-success" CommandArgument='<%#Eval("Id") %>' OnClick="btnAddPlan_Click"><i class="fa fa-plus" aria-hidden="true" ></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <tr>
                                                    <td colspan="999">
                                                        <div id="ProgramTargetId-<%# Eval("Id") %>" style="display: none; position: relative;">
                                                            <asp:GridView ID="gvPlanDetails" runat="server" AutoGenerateColumns="false" CssClass="table  ChildGrid" EmptyDataText="No Item Found"
                                                                OnRowEditing="gvPlanDetails_RowEditing" OnRowCancelingEdit="gvPlanDetails_RowCancelingEdit" OnRowUpdating="gvPlanDetails_RowUpdating">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Date" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtDates" runat="server" Text='<%#Eval("Date") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="InJob">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblInJob" runat="server" Text='<%#Eval("InJob") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtInJob" runat="server" Text='<%#Eval("InJob") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CssClass="btn btn-primary"><i class="fa fa-pen" aria-hidden="true"></i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:LinkButton ID="btn_Update" runat="server" CssClass="btn btn-warning" CommandName="Update" ToolTip="Update"> <i class="fa fa-check-square" aria-hidden="true"></i></asp:LinkButton>

                                                                            <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="btn btn-danger" CommandName="Cancel" ToolTip="Cancel"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
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
                                    <EmptyDataTemplate>No Records To Show</EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>

                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSubmit1" />
                            <asp:PostBackTrigger ControlID="Button1Feed" />
                        </Triggers>

                    </asp:UpdatePanel>


                </div>

                <%---------tab 2---------%>

                <div id="training" class="tab-pane fade">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div id="trainingDiv" runat="server">
                                <h3>Training Refferals </h3>
                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>Program Plan</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:DropDownList ID="ddlTrainningProgramplan" runat="server" CssClass="form-control form-control-user" AutoPostBack="true" OnSelectedIndexChanged="ddlTrainningProgramplan_SelectedIndexChanged"></asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlTrainningProgramplan" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                    </div>

                                </div>
                                <div>
                                    <asp:Label runat="server" ID="lblTrainningProgramDetails" CssClass="alert-success mt-3" Visible="false"></asp:Label>

                                </div>
                                <div class="row mt-5">
                                    <div class="col-3">
                                        <label>Institute Name :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="institute" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="institute" ValidationGroup="2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3">
                                        <label>Training Course : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="course" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="course" ValidationGroup="2" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>
                                </div>

                                <%----------------------------------------------------------------------------%>
                                <div class="row mt-4">

                                    <div class="col-3">
                                        <label>Contact Person Name : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="contactPersonName" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="contactPersonName" ValidationGroup="2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-3">
                                        <label>Contact Number: </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="contactNo" runat="server" name="date" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="contactNo" ValidationGroup="2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                <%---------------------------------------------------------------------------------------------%>


                                <div class="row mt-4">

                                    <div class="col-3">
                                        <label>Refferals Date : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="trainingRefferalDate" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="trainingRefferalDate" ValidationGroup="2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row mt-5 mb-4">
                                    <div class="col-3">
                                        <asp:Button runat="server" ID="btn2Submit" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btn2Submit_Click" ValidationGroup="2" />
                                    </div>
                                </div>

                            </div>

                            <div id="trainingDivFeedback" runat="server" visible="false">
                                <h3>Training Feedback </h3>

                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>Training Institute :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtTrainingInstitute" runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTrainingInstitute" ValidationGroup="1feed" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-2">
                                        <label>In Training (Specify) : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtInTraining" runat="server" name="place" CssClass="form-control form-control-user"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTraining" ValidationGroup="1feed" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>Is Completed :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtTrainingcompleted" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <label>Remarks :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtTrainingRemark" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row mt-5">
                                    <div class="col-3">
                                        <asp:TextBox ID="txtTrainingId" runat="server" CssClass="form-control form-control-user" Visible="false"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row mt-5 mb-4">
                                    <div class="col-2">
                                        <asp:Button runat="server" ID="btnTrainingFeed" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnTrainingFeed_Click" ValidationGroup="1feed" />
                                    </div>
                                </div>


                            </div>
                            <%----------------------------------------------------------------------------------------------%>
                            <div class="table-responsive">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass=" table-bordered mt-4 ParentGrid mb-4"
                                    DataKeyNames="Id" OnRowDataBound="GridView2_RowDataBound" GridLines="None" HeaderStyle-CssClass="GridHeader" HeaderStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="table-dark">
                                            <ItemTemplate>
                                                <a href="javascript:collapseExpand('ProgramTargetId-<%# Eval("Id") %>');">
                                                    <img alt="Details" id="imageProgramTargetId-<%# Eval("Id") %> " src="img/Down.png" style="width: 20px; height: 20px" border="0" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="20%" />
                                        <asp:BoundField DataField="TrainingCourse" HeaderText="Training Course" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="20%" />
                                        <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="20%" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="Contact No." HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="20%" />
                                        <%--<asp:BoundField DataField="C" HeaderText="C-Marks" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="E" HeaderText="E-Marks" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="HeldDate" HeaderText="Held Date" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-Width="20%" />--%>


                                        <asp:TemplateField HeaderText="FEEDBACK" ItemStyle-Width="20%" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>

                                                <asp:LinkButton runat="server" ID="btnAddTrainingFeedback" CssClass="btn btn-success" CommandArgument='<%#Eval("Id") %>' OnClick="btnAddTrainingFeedback_Click"><i class="fa fa-plus" aria-hidden="true" ></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <tr>
                                                    <td colspan="999">
                                                        <div id="ProgramTargetId-<%# Eval("Id") %>" style="display: none; position: relative;">
                                                            <asp:GridView ID="ChildGridView2" runat="server" AutoGenerateColumns="false" CssClass="table  ChildGrid" EmptyDataText="No Item Found"
                                                                OnRowCancelingEdit="ChildGridView2_RowCancelingEdit" OnRowUpdating="ChildGridView2_RowUpdating" OnRowEditing="ChildGridView2_RowEditing">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Date" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <%--  <asp:TemplateField HeaderText="Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Date" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtDates" runat="server" Text='<%#Eval("Date") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Training Institute">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_TrainingInstitute" runat="server" Text='<%#Eval("TrainingInstitute") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtTrainingInstitute" runat="server" Text='<%#Eval("TrainingInstitute") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="In Training">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_InTraining" runat="server" Text='<%#Eval("InTraining") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtInTraining" runat="server" Text='<%#Eval("InTraining") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Training Completed">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_TrainingCompleted" runat="server" Text='<%#Eval("TrainingCompleted") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtTrainingCompleted" runat="server" Text='<%#Eval("TrainingCompleted") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Remarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CssClass="btn btn-primary"><i class="fa fa-pen" aria-hidden="true"></i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:LinkButton ID="btn_Update" runat="server" CssClass="btn btn-warning" CommandName="Update" ToolTip="Update"> <i class="fa fa-check-square" aria-hidden="true"></i></asp:LinkButton>

                                                                            <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="btn btn-danger" CommandName="Cancel" ToolTip="Cancel"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
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
                                    <EmptyDataTemplate>No Records To Show</EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btn2Submit" />
                            <asp:PostBackTrigger ControlID="btnTrainingFeed" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <%----------------------------------------------------------------------------------------------%>
                </div>

                <%--------tab 3 --------%>

                <div id="job" class="tab-pane fade">
                    <asp:UpdatePanel ID="UpdatePanelJob" runat="server">
                        <ContentTemplate>
                            <div id="jobRefferals" runat="server">
                                <h3>Job Refferals</h3>
                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>Program Plan</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:DropDownList ID="ddlJobProgramPlan" runat="server" CssClass="form-control form-control-user" AutoPostBack="true" OnSelectedIndexChanged="ddlJobProgramPlan_SelectedIndexChanged"></asp:DropDownList>
                                        <%--                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlJobProgramPlan" ValidationGroup="1"></asp:RequiredFieldValidator>--%>
                                    </div>

                                </div>
                                <div>
                                    <asp:Label runat="server" ID="lblJobProgramPlanDetails" CssClass="alert-success mt-3" Visible="false"></asp:Label>

                                </div>
                                <div class="row mt-5">
                                    <div class="col-3">
                                        <label>District :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="dropdown-toggle form-control"></asp:DropDownList>

                                    </div>

                                    <div class="col-3">
                                        <label>DS Division  : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:DropDownList ID="ddlDsDivision" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDsDivision_SelectedIndexChanged" CssClass="dropdown-toggle form-control"></asp:DropDownList>

                                    </div>
                                </div>

                                <div class="row mt-5">
                                    <div class="col-3">
                                        <label>Job Position :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:DropDownList ID="ddlPositionType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPositionType_SelectedIndexChanged" CssClass="dropdown-toggle form-control"></asp:DropDownList>

                                    </div>
                                </div>

                                <div class="row mt-5">
                                    <div class="col-3">
                                        <label>Company Vacancies :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:DropDownList ID="ddlCompanyVacancies" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                        <div class="d-flex text-danger">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob2" runat="server" ValidationGroup="Job"
                                                ControlToValidate="ddlCompanyVacancies" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-3">
                                        <label>Job Category : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:DropDownList ID="ddlJobCategory" runat="server" CssClass="dropdown-toggle form-control"></asp:DropDownList>
                                        <div class="d-flex text-danger">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob1" runat="server" ValidationGroup="Job"
                                                ControlToValidate="ddlJobCategory" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>


                                <div class="row mt-4">

                                    <div class="col-3">
                                        <label>Job Refferals Date: </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="jobRefferalsDate" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                        <div class="d-flex text-danger">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob3" runat="server" ValidationGroup="Job"
                                                ControlToValidate="jobRefferalsDate" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-3">
                                        <label>Job Placement Date: </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="jobPlacememntDate" runat="server" name="date" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                                        <div class="d-flex text-danger">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob4" runat="server" ValidationGroup="Job"
                                                ControlToValidate="jobPlacememntDate" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>


                                <div class="row mt-4">

                                    <div class="col-3">
                                        <label>Career Guidance : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="careerGuidance" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                        <div class="d-flex text-danger">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorJob5" runat="server" ValidationGroup="Job"
                                                ControlToValidate="careerGuidance" ErrorMessage="Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-3">
                                        <label>Remarks : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="jobRefferalRemark" runat="server" name="place" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="row mt-5 mb-4">
                                    <div class="col-3">
                                        <asp:Button runat="server" ID="btnSubmitJobRefferal" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="submitJobRefferal" ValidationGroup="Job" />
                                    </div>
                                </div>
                            </div>

                            <div id="jobFeedback" runat="server" visible="false">
                                <h3>Job Refferals Feedback </h3>

                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>Remarks :</label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="txtRemarksJob" runat="server" CssClass="form-control form-control-user" TextMode="MultiLine" CausesValidation="true"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtRemarksJob" ValidationGroup="jobFeedback" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row mt-5">
                                    <div class="col-2">
                                        <label>In Training (Specify) : </label>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="TextBox2" runat="server" name="place" CssClass="form-control form-control-user" TextMode="MultiLine" CausesValidation="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox2" ValidationGroup="jobFeedback" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row mt-5 mb-4">
                                    <div class="col-2">
                                        <asp:Button runat="server" ID="btnSubmitJobFeedback" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmitJobFeedback_Click" ValidationGroup="jobFeedback" />
                                    </div>
                                </div>
                            </div>

                            <div class="table-responsive">
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" CssClass=" table-bordered mt-4 ParentGrid mb-4"
                                    DataKeyNames="JobRefferalsId" OnRowDataBound="GridView3_RowDataBound" GridLines="None" HeaderStyle-CssClass="GridHeader" HeaderStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Larger">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="table-dark">
                                            <ItemTemplate>
                                                <a href="javascript:collapseExpand('JobRefferalsId-<%# Eval("JobRefferalsId") %>');">
                                                    <img alt="Details" id="image3JobRefferalsId-<%# Eval("JobRefferalsId") %> " src="img/Down.png" style="width: 20px; height: 20px" border="0" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="JobRefferalsId" HeaderText="ID" HeaderStyle-CssClass="table-dark" ItemStyle-Width="5%" />
                                        <asp:BoundField DataField="VacancyRegistrationId" HeaderText="VacancyRegistrationId" HeaderStyle-CssClass="table-dark" ItemStyle-Width="15%" />
                                        <asp:BoundField DataField="JobCategoryId" HeaderText="JobCategoryId" HeaderStyle-CssClass="table-dark" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="JobPlacementDate" HeaderText="JobPlacementDate" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-Width="15%" />
                                        <asp:BoundField DataField="RefferalsDate" HeaderText="RefferalsDate" HeaderStyle-CssClass="table-dark" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-Width="15%" />
                                        <asp:BoundField DataField="CareerGuidance" HeaderText="CareerGuidance" HeaderStyle-CssClass="table-dark" ItemStyle-Width="15%" />
                                        <asp:BoundField DataField="RefferalRemarks" HeaderText="RefferalRemarks" HeaderStyle-CssClass="table-dark" ItemStyle-Width="15%" />

                                        <asp:TemplateField HeaderText="Feedback" ItemStyle-Width="25%" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>

                                                <asp:LinkButton runat="server" ID="btnAddFeedBackJob" CssClass="btn btn-success" CommandArgument='<%#Eval("JobRefferalsId") %>' OnClick="btnAddFeedBackJob_Click"><i class="fa fa-plus" aria-hidden="true" ></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <tr>
                                                    <td colspan="999">

                                                        <div id="JobRefferalsId-<%# Eval("JobRefferalsId") %>" style="display: none; position: relative;">
                                                            <asp:GridView ID="childgridView3" runat="server" AutoGenerateColumns="false" CssClass="table  ChildGrid" EmptyDataText="No Item Found"
                                                                OnRowEditing="childgridView3_RowEditing" OnRowCancelingEdit="childgridView3_RowCancelingEdit" OnRowUpdating="childgridView3_RowUpdating">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("JobPlacementFeedbackId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Date" runat="server" Text='<%#Eval("CreatedDate") %>'></asp:Label>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>


                                                                    <asp:TemplateField HeaderText="Still Working">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStillWorking" runat="server" Visible='<%#Eval("StillWorking").ToString()=="1" %>' Text="Yes"></asp:Label>
                                                                            <asp:Label ID="Label1" runat="server" Visible='<%#Eval("StillWorking").ToString()=="2" %>' Text="No"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <%--                                                                            <asp:TextBox ID="txtStillWorking" runat="server" Text='<%#Eval("StillWorking") %>'></asp:TextBox>--%>
                                                                            <asp:RadioButtonList runat="server" ID="rbStillworking">
                                                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnEditJob" runat="server" CommandName="Edit" CssClass="btn btn-primary"><i class="fa fa-pen" aria-hidden="true"></i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:LinkButton ID="btnUpdateJob" runat="server" CssClass="btn btn-warning" CommandName="Update" ToolTip="Update"> <i class="fa fa-check-square" aria-hidden="true"></i></asp:LinkButton>

                                                                            <asp:LinkButton ID="btnCancelJob" runat="server" CssClass="btn btn-danger" CommandName="Cancel" ToolTip="Cancel"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
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
                                    <EmptyDataTemplate>No Records To Show</EmptyDataTemplate>
                                </asp:GridView>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <%----------------------------------------------------------------------------------------------%>
                </div>


                <%------------------- model ----------------------%>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLongTitle">Add Career Guidance Feedback</h5>
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
                                            <asp:TextBox ID="txtFeedbackCarrier" runat="server" Width="250px" CssClass="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Required" ControlToValidate="txtFeedbackCarrier" ValidationGroup="22" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </center>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnAddCarrier" Text="Add" CssClass="btn btn-success" Width="100px" ValidationGroup="22" OnClick="btnAddCarrier_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <%--  <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    &times;</button>
                                <h4 class="modal-title">Modal Header</h4>
                            </div>
                            <div class="modal-body">
                                <iframe id="Iframe1" runat="server"></iframe>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
    <%--</ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="btnBack" />
        </Triggers>

    </asp:UpdatePanel>--%>
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



        .ParentGrid td {
            background-color: white;
            color: black;
            font-size: 10pt;
            line-height: 200%;
            text-align: center;
        }

        .ParentGrid th {
            color: White;
            font-size: 10pt;
            line-height: 200%;
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: center;
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

        var navItems = document.querySelectorAll(".nav-item");
        for (var i = 0; i < navItems.length; i++) {
            navItems[i].addEventListener("click", function () {
                this.classList.add("active");
            });
        }

        function openModal() {
            $('[id*=myModal]').modal('show');
        }

    </script>

</asp:Content>


