<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="security.aspx.cs" Inherits="security" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" Runat="Server">
    <!-- ACA EL FORM -->
    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Reservar espacio <i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="LabelaParkingName" Font-Size= "15.9px" runat="server" Text="Parqueo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownListParking" Font-Size= "15.9px" runat="server" CssClass="form-control ddl" AutoPostBack="true" >
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelInitialHour" Font-Size= "15.9px" runat="server" Text="Hora inicial:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownListInitialHour" Font-Size= "15.9px" runat="server" CssClass="form-control ddl"> </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNothing" Font-Size= "15.9px" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelError" Font-Size= "15.9px" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonVerifiySpot" Font-Size= "15.9px" runat="server" CssClass="btn btn-primary" Text="Verificar espacio" OnClick="btnVerifySpot_Click" />
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <!-- Diseño del parqueo -->
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Diseño del parqueo:</legend>
                        <div class="form-group">
                            <div class="col-lg-10">
                                <div class="table-responsive">
                                    <div class="designOfParking">
                                        <asp:Table ID="TableReportBooking" runat="server" class="table table-bordered">
                                            <asp:TableHeaderRow>
                                                <asp:TableHeaderCell>Usuario</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Espacio</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                                            </asp:TableHeaderRow>
                                        </asp:Table>
                                    </div>
                                </div>
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
    <style>
        .designOfParking {
            height: 500px;
            width: 500px;
            overflow: auto;
        }
    </style>
</asp:Content>

