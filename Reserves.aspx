<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reserves.aspx.cs" Inherits="SamaraParking.Reserves" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
              <li><a href="Login.aspx">Logout</a></li>
            </ul>
          </div>
      </nav>
            </div>
        <h3>Elija El Parqueo: <asp:DropDownList ID="ParkingLot" runat="server" AppendDataBoundItems="true" style="color:black">
             <asp:ListItem Text="---Default---" Value="0" />
        </asp:DropDownList></h3>
        <h3>Elija El Espacio Del Parqueo:  <asp:DropDownList ID="ParkingSpot" runat="server" AppendDataBoundItems="true" style="color:black">
            <asp:ListItem Text="---Default---" Value="0" />
        </asp:DropDownList></h3>
        <div>
            <h3>Elija Su Vehiculo:  <asp:DropDownList ID="Vehiculo" runat="server" AppendDataBoundItems="true" style="color:black">
            <asp:ListItem Text="---Default---" Value="0" />
        </asp:DropDownList></h3></div>
        </div>
   
    </form>
            <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
