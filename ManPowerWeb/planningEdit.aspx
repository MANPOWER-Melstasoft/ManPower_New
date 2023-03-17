<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="planningEdit.aspx.cs" Inherits="ManPowerWeb.planningEdit" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <div class="container"></div>
    <div class="card ml-4 p-4">
        <h2><b>Program Plan</b></h2>
        <div class="mt-3">
            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal3" runat="server" Text="Program Name"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtProgramName" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtProgramName" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>


                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal4" runat="server" Text="Manager"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtManger" CssClass="form-control form-control-user" Enabled="false"></asp:TextBox>


                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>



            </div>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal1" runat="server" Text="Date "></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtDate" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <asp:Label runat="server" ID="lblDate" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDate" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal2" runat="server" Text="Location"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtLocation" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLocation" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>


                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>



            </div>


            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal10" runat="server" Text="Estimate Amount"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtEstimateAmount" CssClass="form-control form-control-user" TextMode="Number" Enabled="false"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal5" runat="server" Text="Budget"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtBudget" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>
                            <asp:Label runat="server" ID="lblBudget" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtBudget" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>


            </div>

            <%-- After Complete button content --%>
            <div id="DivAfterComplete" runat="server">


                <h5><b>Count</b></h5>
                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal6" runat="server" Text="Male Count"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtMaleCount" CssClass="form-control form-control-user" TextMode="Number" min="0" AutoPostBack="true" OnTextChanged="txtMaleCount_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtMaleCount" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal7" runat="server" Text="Female Count"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtFemaleCount" CssClass="form-control form-control-user" TextMode="Number" min="0" AutoPostBack="true" OnTextChanged="txtFemaleCount_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFemaleCount" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>


                </div>


                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal12" runat="server" Text="Total Count"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtTotalCount" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFemaleCount" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal8" runat="server" Text="Total Expenditure"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtExpenditure" CssClass="form-control form-control-user"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtExpenditure" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtExpenditure"
                                    ErrorMessage="Incorrect Input" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ValidationGroup="1" ForeColor="Red"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>




                </div>


                <div class="row mb-3 ms-1">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal13" runat="server" Text="Actual Output"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtActualOutput" CssClass="form-control form-control-user" TextMode="Number" min="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtActualOutput" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal14" runat="server" Text="Actual Outcome"></asp:Literal>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtActualOutcome" CssClass="form-control form-control-user"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtActualOutcome" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>


                </div>
            </div>

            <%-- End After Complete button Content--%>

            <div class="row mb-3 ms-1">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal11" runat="server" Text="Resource Person"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:UpdatePanel runat="server" ID="updatePanel1">
                                <ContentTemplate>
                                    <div class="form-control form-control-user scroll_checkboxes">
                                        <asp:CheckBoxList ID="chkList"
                                            runat="server" CssClass="form-control form-control-user"
                                            RepeatDirection="Vertical" RepeatColumns="1"
                                            BorderWidth="0" Datafield="description"
                                            DataValueField="value" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="chkList_SelectedIndexChanged">
                                        </asp:CheckBoxList>

                                    </div>
                                    <asp:Label ID="lblmsg" class="textcls" runat="server"></asp:Label>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
                <%--  <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal8" runat="server" Text="Resource Person"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlResourcePerson" CssClass="form-control form-control-user" SelectionMode="Multiple"></asp:DropDownList>

                        </div>
                    </div>
                </div>--%>
            </div>

            <div class="row mb-3 ms-1" id="divUplaod" runat="server">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-4">

                            <asp:Literal ID="Literal9" runat="server" Text="Upload Documnents"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <asp:FileUpload ID="Uploader" CssClass="form-control form-control-user" runat="server" AllowMultiple="true" />
                            <asp:Label ID="lblListOfUploadedFiles" runat="server" />
                        </div>
                    </div>
                </div>
            </div>


            <div class="row mb-3 ms-1 mt-5">

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-2">
                            <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary btn-user btn-block" OnClick="btnBack_Click" BackColor="#212529" BorderColor="#212529" />
                        </div>

                        <div class="col-sm-2">
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSave_Click1" ValidationGroup="1" />

                        </div>

                        <%if (DateTime.Now > DateTime.Parse(txtDate.Text) && txtDate.Text != "")
                            {
                        %>
                        <div class="col-sm-2">
                            <%--<asp:Button runat="server" ID="btnComplete" Text="Complete" CssClass="btn btn-success " OnClick="btnComplete_Click" />--%>
                            <asp:Button runat="server" ID="btnSendToRecommendation" Text="Send To Recommendation" CssClass="btn btn-success " OnClick="btnSendToRecommendation_Click" />
                        </div>
                        <%} %>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <style type="text/css">
        .scroll_checkboxes {
            height: 180px;
            width: fit-content;
            padding: 5px;
            overflow: auto;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .FormText {
            FONT-SIZE: 11px;
            FONT-FAMILY: tahoma,sans-serif
        }
    </style>
    <script language="javascript">

        var color = 'White';

        function changeColor(obj) {
            var rowObject = getParentRow(obj);
            var parentTable =
                document.getElementById("<%=chkList.ClientID%>");

            if (color == '') {
                color = getRowColor();
            }

            if (obj.checked) {
                rowObject.style.backgroundColor = '#A3B1D8';
            }
            else {
                rowObject.style.backgroundColor = color;
                color = 'White';
            }

            // private method
            function getRowColor() {
                if (rowObject.style.backgroundColor == 'White')
                    return parentTable.style.backgroundColor;
                else return rowObject.style.backgroundColor;
            }
        }

        // This method returns the parent row of the object
        function getParentRow(obj) {
            do {
                obj = obj.parentElement;
            }
            while (obj.tagName != "TR")
            return obj;
        }

        function TurnCheckBoixGridView(id) {
            var frm = document.forms[0];

            for (i = 0; i < frm.elements.length; i++) {
                if (frm.elements[i].type == "checkbox" &&
                    frm.elements[i].id.indexOf("<%= chkList.ClientID %>") == 0) {
                    frm.elements[i].checked =
                        document.getElementById(id).checked;
                }
            }
        }

        function SelectAll(id) {
            var parentTable = document.getElementById("<%=chkList.ClientID%>");
            var color

            if (document.getElementById(id).checked) {
                color = '#A3B1D8'
            }
            else {
                color = 'White'
            }

            for (i = 0; i < parentTable.rows.length; i++) {
                parentTable.rows[i].style.backgroundColor = color;
            }
            TurnCheckBoixGridView(id);
        }

    </script>
</asp:Content>
