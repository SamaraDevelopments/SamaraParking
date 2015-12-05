<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="addparking.aspx.cs" Inherits="Form_addparking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">
    <div class="container">
        <!-- ACA EL FORM -->
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Agregar parqueo<i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="LabelNameOfNewParking" runat="server" Text="Nombre:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxNameOfNewParking" runat="server" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelLocationOfNewParking" runat="server" Text="Locación:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxLocationOfNewParking" runat="server" placeholder="Locación" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelNormalSpots" runat="server" Text="Espacios regulares:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxNormalSpot" runat="server" placeholder="Regulares" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelMotocyclesForRegularSpot" runat="server" Text="Motocicletas por espacio:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxMotocyclesForRegularSpot" runat="server" placeholder="Cantidad de motocicletas" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelDimensionsOfParking" runat="server" Text="Dimensiones del parqueo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxDimensionsOfParkingX" runat="server" placeholder="Dimension X" CssClass="form-control"></asp:TextBox>
                                <asp:TextBox ID="TextBoxDimensionsOfParkingY" runat="server" placeholder="Dimension Y" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelNothingError" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelError" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNothingInfo" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                                <asp:Label ID="LabelInfo" runat="server" Text="* Cada espacio de la matriz sera un espacio regular" EnableViewState="False" ForeColor="White" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="form-group">
                                <asp:Label ID="LabelReseveSpot" runat="server" Text="Azul = Reserva" EnableViewState="False" ForeColor="White" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="form-group">
                                <asp:Label ID="LabelCalleSpot" runat="server" Text="Gris = Calle " EnableViewState="False" ForeColor="White" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="form-group">
                                <asp:Label ID="LabelRegularSpot" runat="server" Text="Transparente = Regular" EnableViewState="False" ForeColor="White" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonNext" runat="server" CssClass="btn btn-primary" Text="Siguiente" OnClick="btnNext_Click"/>
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
                                <asp:Table ID="TableDesignOfNewParking" runat="server" class="table table-bordered">                                    
                                </asp:Table>
                            </div>
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonAddParking" runat="server" CssClass="btn btn-primary" Text="Agregar parqueo" OnClick="btnAddNewParking_Click"/>
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
</asp:Content>

