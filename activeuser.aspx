<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="ActiveUser.aspx.cs" Inherits="Form_activeUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
    <div class="container">
            <!-- ACA EL FORM -->
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="registrationform">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Profesores con marchamo activo<i class="fa fa-pencil pull-right"></i></legend>
                            <asp:DataGrid ID="TableActiveProfessor" runat="server"></asp:DataGrid>

                            <legend>Estudiantes con marchamo activo<i class="fa fa-pencil pull-right"></i></legend>
                            <asp:DataGrid ID="TableActiveStudent" runat="server"></asp:DataGrid>
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
</asp:Content>

