<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainDashboard.aspx.cs" Inherits="ManPowerWeb.MainDashboard" %>

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
            <div class="row mb-5">
                <div class="col-6">
                    <div class="card " style="text-align: center">
                        <h2>HR</h2>
                    </div>
                </div>
                <div class="col-6">
                    <a href="Dashboard.aspx" style="text-decoration: none;">
                        <div class="card" style="text-align: center">
                            <h2>Planning</h2>
                        </div>
                    </a>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="card" style="text-align: center">
                        <h2>Finance</h2>
                    </div>
                </div>
                <div class="col-6">
                    <div class="card" style="text-align: center">
                        <h2>Procument</h2>
                    </div>
                </div>
            </div>
        </div>


    </form>
</body>
</html>
