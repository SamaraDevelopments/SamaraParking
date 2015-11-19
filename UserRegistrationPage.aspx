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

    <style type="text/css">
        .auto-style2 {
            height: 30px;
        }

        .auto-style7 {
            height: 30px;
            width: 156px;
        }
        .auto-style8 {
            height: 31px;
            width: 156px;
        }
        .auto-style9 {
            height: 11px;
        }
        .auto-style10 {
            height: 11px;
            width: 156px;
        }
        .auto-style13 {
            width: 196px;
        }
        .auto-style14 {
            height: 33px;
        }
        .auto-style16 {
            height: 33px;
            width: 156px;
        }
        .auto-style17 {
            height: 33px;
            width: 196px;
        }
        .auto-style18 {
            height: 30px;
            width: 196px;
        }
        .auto-style19 {
            height: 11px;
            width: 196px;
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
            <table border="0" align="left">

                <tr>
                    <th colspan="3" class="auto-style5">
                        <p>Registration</p>
                    </th>
                </tr>
                <tr>
                    <td class="auto-style16" aria-readonly="True">Name:
                    </td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtName" runat="server" Style="background-color: #EAEAEA" ForeColor="#000000" />
                    </td>
                    <td class="auto-style17">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7" aria-readonly="True">Last Name:
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtLastname" runat="server" Style="background-color: #EAEAEA" ForeColor="#000000" />
                    </td>
                    <td class="auto-style18">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Username:
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtUsername" runat="server" Style="background-color: #EAEAEA" ForeColor="#000000" />
                    </td>
                    <td class="auto-style18">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Password:
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="background-color: #EAEAEA" ForeColor="#000000" />
                    </td>
                    <td class="auto-style18">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Confirm Password:
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Style="background-color: #EAEAEA" ForeColor="#000000" />
                    </td>
                    <td class="auto-style18">
                        <asp:CompareValidator ID="CompareValidator1" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Email:
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtEmail" runat="server" Style="background-color: #EAEAEA" ForeColor="#000000" />
                    </td>
                    <td class="auto-style19">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                            ControlToValidate="txtEmail" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td align="left" class="auto-style6">
                        <asp:Button ID="SubmitButton" Text="Submit" runat="server" OnClick="RegisterUser" ForeColor="#000000" Height="26px" Width="74px" />
                    </td>
                    <td class="auto-style13"></td>
                </tr>
            </table>
        </div>
    </form>
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
