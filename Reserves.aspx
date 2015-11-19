<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reserves.aspx.cs" Inherits="SamaraParking.Reserves" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/grayscale.css" rel="stylesheet" />
    <style type="text/css">
        
        .auto-style7 {
            height: 30px;
            width: 9883px;
        }
        .auto-style8 {
            height: 30px;
            width: 4499px;
        }
        .auto-style9 {
            height: 53px;
            width: 9883px;
        }
        .auto-style10 {
            height: 53px;
            width: 4499px;
        }
    </style>
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

        <table border="0" align="left">
            <tr>
                <td class="auto-style7">
                    <p>Reserve</p>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Choose the wanted parking:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true" Style="color: black">
                        <asp:ListItem Text="---Default---" Value="0" />
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="auto-style7">Spot number:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="ParkingSpot" runat="server" AppendDataBoundItems="true" Style="color: black">
                        <asp:ListItem Text="---Default---" Value="0" />
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="auto-style9">Choose your vehicle:</td>
                <td class="auto-style10">
                    <asp:DropDownList ID="Vehiculo" runat="server" AppendDataBoundItems="true" Style="color: black">
                        <asp:ListItem Text="---Default---" Value="0" />
                    </asp:DropDownList>
                    <br />
                    <asp:RadioButton ID="RadioButtonIsMotorcycle" runat="server" Text="Is Motorcycle?"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Initial hour:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtInitialHour" runat="server" Style="background-color: #EAEAEA" ForeColor="#000000">
                    </asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style7">Final hour:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtFinalHour" runat="server" Style="background-color: #EAEAEA" ForeColor="#000000">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td align="left" class="auto-style6">
                    <asp:Button ID="ButtonBooking" Text="Booking Spot" runat="server" ForeColor="#000000" Height="26px" Width="122px" />
                </td>
            </tr>
        </table>
        <script src="js/jquery-1.11.3.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
    </form>
</body>
</html>
