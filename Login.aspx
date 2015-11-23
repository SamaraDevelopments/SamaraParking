<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Form_login" %>

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
    <title>Ingreso Latina Parking</title>
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
        <div id="custom-bootstrap-menu" class="navbar navbar-default " role="navigation">
            <div class="container">
                
            </div>
        </div>
        <div class="container">
            <!-- ACA EL FORM -->
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="registrationform">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Ingresar. <i class="fa fa-pencil pull-right"></i></legend>
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Email" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Password" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Password" CssClass="form-control"
                                        TextMode="Password"></asp:TextBox>
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me" Checked="false"/>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:Label ID="Label4" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label5" runat="server" Text="Sede:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control ddl">
                                        <asp:ListItem>San Pedro</asp:ListItem>
                                        <asp:ListItem>Heredia</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="btnSubmit_Click" />
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
