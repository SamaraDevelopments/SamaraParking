<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="SamaraParking.Home" %>

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
    Welcome
    <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" style="background-color:black" />
    <br />
    <br />
    <asp:Label ID="lblLastLoginDate" runat="server" />
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
    </div>
    </div>
    </form>
</body>
</html>
