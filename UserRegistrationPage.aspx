<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistrationPage.aspx.cs" Inherits="SamaraParking.UserRegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
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
              <li><a href="Login.aspx">Logout</a></li>
            </ul>
          </div>
      </nav>
        <table border="0" >
            
    <tr>
        <th colspan="3">
            Registration
        </th>
    </tr>
    <tr>
        <td>
            Name
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" style="background-color:black"/>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Last Name
        </td>
        <td>
            <asp:TextBox ID="txtLastname" runat="server" style="background-color:black" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Username
        </td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" style="background-color:black" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Password
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" style="background-color:black" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Confirm Password
        </td>
        <td>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" style="background-color:black"/>
        </td>
        <td>
            <asp:CompareValidator ID="CompareValidator1" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                ControlToValidate="txtConfirmPassword" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Email
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" style="background-color:black"/>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                ControlToValidate="txtEmail" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="SubmitButton" Text="Submit" runat="server" OnClick="RegisterUser" ForeColor="Black" />
        </td>
        <td>
        </td>
    </tr>
</table>
    </div>
    </form>
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
