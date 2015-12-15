<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="bookingdone.aspx.cs" Inherits="bookingdone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" Runat="Server">
     <!-- ACA EL FORM -->

    <% Vehicle vehicleFromUser = (Vehicle)Session["VEHICLE"];
        string alert = (string)Session["ALERT"]; %>

    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Su espacio fue reservada con exito!</legend>
                        <div class="form-group">
                            <asp:Label ID="LabelIDVehicle" Font-Size="15.9px" runat="server" Text="Vehículo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelVehicle" Font-Size="15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelinitialHour" Font-Size="15.9px" runat="server" Text="Hora inicial:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelinitialTime" Font-Size="15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelFinalHour" Font-Size="15.9px" runat="server" Text="Hora final:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelFinalTime" Font-Size="15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelIdParking" Font-Size="15.9px" runat="server" Text="Parqueo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelNameParking" Font-Size="15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabeIdSpot" Font-Size="15.9px" runat="server" Text="Espacio del parqueo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelIdSpotOfPaking" Font-Size="15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-3">
                                <asp:Button ID="ButtonGoToBooking" Font-Size="15.9px" runat="server" CssClass="btn btn-primary" Text="Volver a seleccionar espacio" OnClick="btnBack_Click" />
                                <asp:Button ID="ButtonGoToindex" Font-Size="15.9px" runat="server" CssClass="btn btn-primary" Text="Ok!" OnClick="btnOk_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-3">
                                
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

        $("#warning-alert").alert();
        $("#warning-alert").fadeTo(3000, 500).slideUp(500, function () {
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
        .vehiclesOfUser {
            height: 300px;
            width: auto;
            overflow: auto;
        }
    </style>
</asp:Content>

