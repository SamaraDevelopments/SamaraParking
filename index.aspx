﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Form_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--[if lt IE 7]> <html class="no-js ie6 oldie" lang="en"> <![endif]-->
    <!--[if IE 7]>    <html class="no-js ie7 oldie" lang="en"> <![endif]-->
    <!--[if IE 8]>    <html class="no-js ie8 oldie" lang="en"> <![endif]-->
    <!--[if IE 9]> <html class="no-js ie9 oldie" lang="en"> <![endif]-->
    <meta charset="utf-8">
    <!-- Set the viewport width to device width for mobile -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Latina Parking</title>
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
                        <li><a href="/">Reserva tu espacio</a> </li>
                        <li><a href="/contact">Soporte</a> </li>
                        <li><a href="/products">Agregar vehiculo</a> </li>
                         <% if (loggedUser.Roletype == 2)
                            {
                        %>
                        <li><a href="/products">Admin</a> </li>

                        <%} %>
                        <li><a href="login.aspx" onclick="<%Session["USER"] = null;%>">Salir</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="container">
            <!-- ACA EL FORM -->
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="registrationform">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Bienvenido <%=loggedUser.Name%><i class="fa fa-pencil pull-right"></i></legend>
                            <div class="form-group">
                            </div>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Primary" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-warning" Text="Warning" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Success" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-info" Text="Info" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button4" runat="server" CssClass="btn btn-default" Text="Default" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button5" runat="server" CssClass="btn btn-danger" Text="Danger" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button6" runat="server" CssClass="btn btn-link" Text="Link" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
            <!-- ESPACIO PARA IMAGEN O TEXTO -->
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
                <div id="banner">
                    <h1>Poner <strong>IMAGEN aqui.</strong> o algun texto</h1>
                    <h5>
                        <strong>www.samaradevs.com</strong></h5>
                </div>
            </div>
        </div>
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
