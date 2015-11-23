<%@ Page Language="C#" AutoEventWireup="true" CodeFile="booking.aspx.cs" Inherits="Form_booking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--[if lt IE 7]> <html class="no-js ie6 oldie" lang="en"> <![endif]-->
    <!--[if IE 7]>    <html class="no-js ie7 oldie" lang="en"> <![endif]-->
    <!--[if IE 8]>    <html class="no-js ie8 oldie" lang="en"> <![endif]-->
    <!--[if IE 9]> <html class="no-js ie9 oldie" lang="en"> <![endif]-->
    <meta charset="utf-8">
    <!-- Set the viewport width to device width for mobile -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>Samara Parking</title>
    <!-- ============ Google fonts ============ -->
    <link href='http://fonts.googleapis.com/css?family=EB+Garamond' rel='stylesheet'
        type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700,300,800'
        rel='stylesheet' type='text/css' />
    <!-- ============ Add custom CSS here ============ -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <%
            User loggedUser = (User)Session["USER"];

        %>
        <div id="custom-bootstrap-menu" class="navbar navbar-default " role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <a class="navbar-brand" href="index.aspx">Latina Parking</a>
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-menubuilder">
                        <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span
                            class="icon-bar"></span><span class="icon-bar"></span>
                    </button>
                </div>
                <div class="collapse navbar-collapse navbar-menubuilder">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="booking.aspx">Reserva tu espacio</a> </li>
                        <li><a href="addvehicle.aspx">Agregar vehiculo</a> </li>
                        <% if (loggedUser.Roletype == 2)
                            {
                        %>
                        <li><a href="userregistry.aspx">Agregar usuario</a> </li>
                        <li><a href="addparkinglot.aspx">Agregar parqueo</a></li>
                        <%} %>
                        <li><a href="login.aspx" onclick="">Salir</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- ACA EL FORM -->
        <div class="container">
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="registrationform">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Reservar espacio <i class="fa fa-pencil pull-right"></i></legend>
                            <div class="form-group">
                                <asp:Label ID="LabelParking" runat="server" Text="Parqueo:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="DropDownListParking" runat="server" CssClass="form-control ddl">
                                        <asp:ListItem>Aguja</asp:ListItem>
                                        <asp:ListItem>Banderas....</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelInitialTime" runat="server" Text="Hora inicial:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxInitialTime" runat="server" placeholder="Hora inicial" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelFinalTime" runat="server" Text="Hora final:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxfinalhour" runat="server" placeholder="Hora final" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelISpotnumber" runat="server" Text="Numero de espacio:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxSpotnumber" runat="server" placeholder="Numero de espacio" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:Label ID="Label4" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="btnBookingSpot" runat="server" CssClass="btn btn-primary" Text="Reservar espacio" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
        <!-- ESPACIO PARA IMAGEN O TEXTO -->

        <script src="js/jquery.js" type="text/javascript"></script>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
        <script src="js/jquery.backstretch.js" type="text/javascript"></script>
        <script type="text/javascript">
            'use strict';

            /* ========================== */
            /* ::::::: Backstrech ::::::: */
            /* ========================== */
            // You may also attach Backstretch to a block-level element
            $.backstretch(
            [

                "img/colorful.jpg",
                "img/34.jpg",

            ],

            {
                duration: 4500,
                fade: 1500
            }
        );
        </script>
    </form>
</body>
</html>
