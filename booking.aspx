﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="booking.aspx.cs" Inherits="Form_booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">
    <!-- ACA EL FORM -->
    <div class="container">

        <% User loggedUser = (User)Session["USER"];  %>

        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Reservar espacio <i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="LabelaParkingName" Font-Size="15.9px" runat="server" Text="Parqueo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownListParking" Font-Size="15.9px" runat="server" CssClass="form-control ddl" AutoPostBack="true" OnSelectedIndexChanged="UpdateParking_SelectedIndexChange">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelInitialHour" Font-Size="15.9px" runat="server" Text="Hora inicial:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownListInitialHour" Font-Size="15.9px" runat="server" CssClass="form-control ddl" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelFinalHour" Font-Size="15.9px" runat="server" Text="Hora Final:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownListFinalHour" Font-Size="15.9px" runat="server" CssClass="form-control ddl" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <% if (loggedUser.Roletype != 3)
                            {%>
                        <div class="form-group">
                            <asp:Label ID="LabelIdVehicle" Font-Size="15.9px" runat="server" Text="Vehículo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownListVehicleFormUser" Font-Size="15.9px" runat="server" CssClass="form-control ddl"></asp:DropDownList>
                            </div>
                        </div>
                        <%} %>
                        <div class="form-group">
                            <asp:Label ID="LabelNothing" Font-Size="15.9px" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelError" Font-Size="15.9px" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <!-- Diseño del parqueo -->
         <% string emailAlert = (string)Session["BOOKINGALERT"]; %>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Diseño del parqueo:</legend>                       
                        <div class="form-group">                           
                                <a class="btn" style="background-color: blue; color: white">Preferencial</a>
                                <a class="btn" style="background-color: yellow; color: black">Motocicletas</a>
                                <a class="btn" style="background-color: transparent; color: white">Vehiculo Liviano</a>
                                <a class="btn" style="background-color: green; color: white">Seleccionado</a>
                                <a class="btn" style="background-color: red; color: white">Ocupado</a>                            
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10">
                                <div class="table-responsive">
                                    <asp:Table ID="TableDesignOfNewParking" runat="server" class="table table-bordered">
                                    </asp:Table>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-3">
                                <asp:Button ID="ButtonBooking" Font-Size="15.9px" runat="server" CssClass="btn btn-primary" Text="Reservar espacio" OnClick="btnBookingSpot_Click" />
                            </div>
                        </div>
                         <%if (emailAlert.Equals("No Enviado"))
                            { %>
                       <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-1">
                                <div class="alert alert-danger" id="warning-alert">
                                    <button type="button" class="close" data-dismiss="alert">x</button>
                                    <strong>No enviado!</strong>
                                    <p>No se envio el correo, verifique su direccion de correo. <%=loggedUser.Email %></p>
                                </div>
                            </div>
                        </div>
                        <% }%>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.backstretch.js" type="text/javascript"></script>
    <script type="text/javascript">

        $("#warning-alert").alert();
        $("#warning-alert").fadeTo(4000, 500).slideUp(500, function () {
            $("#warning-alert").hide();
        });

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
            duration: 5500,
            fade: 1500
        }
    );
    </script>
    <style>
        .designOfParking {
            height: 500px;
            width: 500px;
            overflow: auto;
        }
    </style>
</asp:Content>

