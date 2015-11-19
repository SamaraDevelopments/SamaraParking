<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="SamaraParking.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
     <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/grayscale.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
       <div class="container-fluid">
                <nav class="navbar navbar-default">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="#">Samara Parking</a>
          </div>
          <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
              <li><a href="Home.aspx">Home</a></li>
              <li><a href="UserRegistrationPage.aspx">User Registration</a></li>
              <li><a href="Reserves.aspx">Reserve</a></li>
              <li><a href="Login.aspx">Logout</a></li>
            </ul>
          </div>
      </nav>
            </div>
    <p>Welcome
    <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" ForeColor= "White"/>
    <br />
    <br />
    <asp:Label ID="lblLastLoginDate" runat="server" />
        </p>
    </form>
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
