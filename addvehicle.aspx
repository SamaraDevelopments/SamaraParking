<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="addVehicle.aspx.cs" Inherits="form_addvehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">
    <!-- ACA EL FORM -->

    <% Vehicle vehicleFromUser = (Vehicle)Session["VEHICLE"];  %>

    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Sus vehiculos registrados son:</legend>

                        <div class="form-group">
                            
                            <div class="col-lg-10">
                                <asp:Table ID="TableRegistryVehicles" runat="server" class="table table-bordered">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>PLACA</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>MARCA</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>TIPO</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>ACCION</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                                <asp:Label ID="LabelLegendMoto" runat="server" Text="M = Moto" CssClass="col-lg-2 control-label"></asp:Label>
                                <asp:Label ID="LabelLegendCar" runat="server" Text="VL = Vehiculo Liviano" CssClass="col-lg-2 control-label"></asp:Label>

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
                            <asp:Label ID="LabelBrandOfVehicle" runat="server" Text="Marca:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxBrandOfVehicle" runat="server" placeholder="Marca" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelIdVehicleOfVehicle" runat="server" Text="Numero de placa:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxIdOfVehicle" runat="server" placeholder="Numero de placa" CssClass="form-control" OnTextChanged="TextBoxIdVehicle_TextChanged"></asp:TextBox>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="CheckBoxIsMotrocycle" runat="server" Text="Es Moto?" Checked="false" CssClass="checkbox" />
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelError" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonAddVehicle" runat="server" CssClass="btn btn-primary" Text="Agregar Vehiculo" OnClick="btnAddVehicle_Click" />
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

