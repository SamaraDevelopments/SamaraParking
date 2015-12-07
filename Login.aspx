<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Form_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--[if lt IE 7]> <html class="no-js ie6 oldie" lang="en"> <![endif]-->
    <!--[if IE 7]>    <html class="no-js ie7 oldie" lang="en"> <![endif]-->
    <!--[if IE 8]>    <html class="no-js ie8 oldie" lang="en"> <![endif]-->
    <!--[if IE 9]> <html class="no-js ie9 oldie" lang="en"> <![endif]-->
    <!-- Set the viewport width to device width for mobile -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
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
    <form id="formLogin" runat="server">
        <div id="custom-bootstrap-menu" class="navbar navbar-default ">
            <div class="container">
                <div class="navbar-header">
                    <a class="navbar-brand" href="index.aspx">Latina Parking</a>
                </div>
            </div>
        </div>
        <div class="container">
            <!-- ACA EL FORM -->
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="registrationform">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Ingreso<i class="fa fa-pencil pull-right"></i></legend>
                            <div class="form-group">
                                <asp:Label ID="LabelEmailIncomingUser" runat="server" Text="Correo Electronico: " CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxEmailIncomingUser" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelPasswordIncomingUser" runat="server" Text="Contraseña: " CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxPasswordIncomingUser" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="CheckBoxRememberIncomingUser" runat="server" Text="Recordarme" Checked="false" CssClass="checkbox" />
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:Label ID="LabelError" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="ButtonSubmit" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="ButtonCancel" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
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
