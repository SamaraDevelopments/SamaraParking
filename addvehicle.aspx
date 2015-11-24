<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="AddVehicle.aspx.cs" Inherits="form_addvehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
        <!-- ACA EL FORM -->
        <div class="container">
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="registrationform">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Sus vehiculos registrados son:</legend>
                            <div class="form-group">
                                <div class="col-lg-10">
                                    <asp:Table ID="Table1" runat="server" class="table table-bordered">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>PLACA</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>MARCA</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                            </div>
                            <legend>Agregar Vehiculo:</legend>
                            <div class="form-group">
                                <asp:Label ID="LabelBrand" runat="server" Text="Marca:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxBrand" runat="server" placeholder="Marca" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelIdVehicle" runat="server" Text="Numero de placa:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxIdVehicle" runat="server" placeholder="Numero de placa" CssClass="form-control" OnTextChanged="TextBoxIdVehicle_TextChanged"></asp:TextBox>
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="CheckBoxIsMotrocycle" runat="server" Text="Es Moto?" Checked="false" />
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:Label ID="Label4" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="btnAddVehicle" runat="server" CssClass="btn btn-primary" Text="Agregar Vehiculo" OnClick="btnAddVehicle_Click" />
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
            </div>
</asp:Content>

