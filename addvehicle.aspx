<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="addVehicle.aspx.cs" Inherits="Form_AddVehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">
    <!-- ACA EL FORM -->

    <% Vehicle vehicleFromUser = (Vehicle)Session["VEHICLE"];
        string alert = (string)Session["ALERT"]; %>

    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Sus vehiculos registrados son:</legend>
                        <div class="form-group">
                            <div class="col-lg-10">
                                <div class="table-responsive">
                                    <asp:Table ID="TableRegistryVehicles" runat="server" class="table table-bordered">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>PLACA</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>MARCA</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>TIPO</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>ACCION</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                                <asp:Label ID="LabelLegendMoto" Font-Size="15.9px" runat="server" Text="M = Moto" CssClass="col-lg-2 control-label"></asp:Label>
                                <asp:Label ID="LabelLegendCar" Font-Size="15.9px" runat="server" Text="VL = Vehiculo Liviano" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <%if (vehicleFromUser != null)
                            { %>
                        <legend>Editando su vehiculo</legend>
                        <% 
                            }
                            else
                            {%>
                        <legend>Agregar Vehiculo:</legend>
                        <% }%>

                        <div class="form-group">
                            <asp:Label ID="LabelBrandOfVehicle" Font-Size="15.9px" runat="server" Text="Marca:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxBrandOfVehicle" Font-Size="16.5px" runat="server" placeholder="Marca" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelIdVehicleOfVehicle" Font-Size="15.9px" runat="server" Text="Numero de placa:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxIdOfVehicle" Font-Size="16.5px" runat="server" placeholder="Numero de placa" CssClass="form-control" OnTextChanged="TextBoxIdVehicle_TextChanged"></asp:TextBox>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="CheckBoxIsMotrocycle" Font-Size="15.9px" runat="server" Text="Es Moto?" Checked="false" CssClass="checkbox" />
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelTransparent" Font-Size="15.9px" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelError" Font-Size="15.9px" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <%if (vehicleFromUser != null)
                            { %>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonEditVehicle" Font-Size="15.9px" runat="server" CssClass="btn btn-primary" Text="Editar Vehiculo" OnClick="btnExecuteEditVehicle_Click" />
                                <asp:Button ID="ButtonCancelVehicle" Font-Size="15.9px" runat="server" CssClass="btn btn-danger" Text="Cancelar Vehiculo" OnClick="btnCancelEditVehicle_Click" />
                            </div>
                        </div>
                        <% 
                            }
                            else
                            {%>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonAddVehicle" Font-Size="15.9px" runat="server" CssClass="btn btn-primary" Text="Agregar Vehiculo" OnClick="btnAddVehicle_Click" />
                            </div>
                        </div>
                        <% }%>
                    </fieldset>
                </div>
            </div>
        </div>
        <%if (alert.Equals("Borrado"))
            { %>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="alert alert-success" id="warning-alert">
                <button type="button" class="close" data-dismiss="alert">x</button>
                <strong>Eliminado! </strong>
                Su vehiculo a sido eliminado.
            </div>

        </div>
        <% }
            else if (alert.Equals("Editado"))
            { %>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="alert alert-success" id="warning-alert">
                <button type="button" class="close" data-dismiss="alert">x</button>
                <strong>Editado! </strong>
                Su vehiculo a sido editado con exito.
            </div>
        </div>
        <% }
            else if (alert.Equals("Agregado"))
            { %>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="alert alert-success" id="warning-alert">
                <button type="button" class="close" data-dismiss="alert">x</button>
                <strong>Agregado! </strong>
                Su vehiculo a sido agregado con exito.
            </div>
        </div>
        <%} %>
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
            duration: 4500,
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

