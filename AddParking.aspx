<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="addparking.aspx.cs" Inherits="Form_addparking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">
    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Agregar parqueo<i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="LabelNameOfNewParking" Font-Size="15.9px" runat="server" Text="Nombre:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxNameOfNewParking" Font-Size="16.5px" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelLocationOfNewParking" Font-Size="15.9px" runat="server" Text="Locación:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxLocationOfNewParking" Font-Size="16.5px" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelDimensionsOfParking" Font-Size="15.9px" runat="server" Text="Dimensiones del parqueo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxDimensionsOfParkingX" Font-Size="16.5px" runat="server" placeholder="Dimension X" CssClass="form-control"></asp:TextBox>
                                <asp:TextBox ID="TextBoxDimensionsOfParkingY" Font-Size="16.5px" runat="server" placeholder="Dimension Y" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNothingError" Font-Size="15.9px" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelError" Font-Size="15.9px" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNothingInfo" Font-Size="15.9px" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <asp:Label ID="LabelInfo" Font-Size="15.9px" runat="server" Text="* Cada espacio de la matriz sera un espacio regular" EnableViewState="False" ForeColor="White" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-3">
                                <asp:Button ID="ButtonNext" Font-Size="15.9px" runat="server" CssClass="btn btn-primary" Text="Siguiente" OnClick="btnNext_Click" />
                                <asp:Button ID="ButtonCancel" Font-Size="15.9px" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <%
            int action = (Int32)Session["AddParking"];

            if (action == 1)
            {%>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Diseño del parqueo:</legend>
                        <div class="form-group">
                            <asp:Label ID="LabelReseveSpot" Font-Size="15.9px" runat="server" Text="" EnableViewState="False" ForeColor="White" CssClass="control-label">Gris = Calle / Transparente = Espacio Vehículo Livianos  / Azul = Espacio Preferencial / Amarillo = Espacio para Motocicletas</asp:Label>
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
                            <asp:Label ID="LabelNormalSpots" Font-Size="15.9px" runat="server" Text="Espacios:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxNormalSpot" Font-Size="16.5px" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-10 col-lg-offset-3">
                            <asp:Button ID="ButtonAddParking" runat="server" CssClass="btn btn-primary" Text="Agregar parqueo" OnClick="btnAddNewParking_Click" />
                             <asp:Button ID="ButtonCancelAddParking" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="ButtonCancelAddParking_Click" />
                       </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <% } %>
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
            duration: 5500,
            fade: 1500
        }
    );
    </script>
    <style>
        .desingOfParking {
            height: 525px;
            width: 485px;
            overflow: auto;
        }
    </style>
</asp:Content>

