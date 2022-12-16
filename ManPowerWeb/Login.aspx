<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ManPowerWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department of Manpower and Employment</title>
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />

    <!-- Favicons -->
    <link rel="icon" type="image/x-icon" href="img/favicon.png" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top-row mb-5">
            <div class="col-12">
                <img src="img/header2.png" class="mb-3 ml-5 mt-2" style="height: 85%; width: 30em" />
            </div>
        </div>

        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-7">
                    <div class="card shadow-lg border-0 rounded-lg mt-6 bg-transparent">
                        <div class="card-header" style="background-color: #122a8d66">
                            <h3 class="text-light text-center text-uppercase">Login</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-outline" style="font-weight: 700">
                                <label class="form-label" for="inputUserName">User Name</label>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control "></asp:TextBox>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                        ControlToValidate="txtUserName" ErrorMessage="Username is Required">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-outline mb-4" style="font-weight: 700">
                                <label for="inputPassword" class="form-label">Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control " TextMode="Password"></asp:TextBox>
                                <div class="d-flex text-danger">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txtPassword" ErrorMessage="Password Required">*</asp:RequiredFieldValidator>
                                    <div class="mt-3">
                                        <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-outline mb-4">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
                            </div>
                            <div class="form-group d-flex justify-content-center">
                                <a class="small" href="#"></a>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-block" Width="400px" Font-Bold="true" OnClick="btnLogin_Click" />
                            </div>

                        </div>
                        <div class="card-footer text-center py-3" style="background-color: #122a8d66">
                        </div>
                    </div>
                </div>
            </div>
        </div>





    </form>
</body>
</html>
