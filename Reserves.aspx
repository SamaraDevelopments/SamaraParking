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
        <div class="jumbotron" style="border:10px #000000">
            <h1 style="color:black">SamaraParking</h1>
    </div>
        <div>
        <h3>Elija El Parqueo: <asp:DropDownList ID="ParkingLot" runat="server" AppendDataBoundItems="true" style="color:black">
             <asp:ListItem Text="---Default---" Value="0" />
        </asp:DropDownList></h3>
        </div>
        <h3>Elija El Espacio Del Parqueo:  <asp:DropDownList ID="ParkingSpot" runat="server" AppendDataBoundItems="true" style="color:black">
            <asp:ListItem Text="---Default---" Value="0" />
        </asp:DropDownList></h3>
        <div>
            <h3>Elija Su Vehiculo:  <asp:DropDownList ID="Vehiculo" runat="server" AppendDataBoundItems="true" style="color:black">
            <asp:ListItem Text="---Default---" Value="0" />
        </asp:DropDownList></h3></div>
        </div>
   
    </form>
</body>
</html>
