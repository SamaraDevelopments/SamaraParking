<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" Debug="true" CodeFile="useractivation.aspx.cs" Inherits="Form_UserActivation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">


    <%
        User loggedUser = (User)Session["USER"];
        Vehicle vehicleFromUser = (Vehicle)Session["VEHICLE"];
        string activatioMsg = (string)Session["EMAIL"];
        string emailAlert = (string)Session["EMAILALERT"];
    %>

    <div class="container">
        <!-- ACA EL FORM -->
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Agregar usuario<i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="LabelIDNewUser" Font-Size="15.9px" runat="server" Text="ID:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionId" Font-Size="15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"><></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNameNewUser" Font-Size="15.9px" runat="server" Text="Nombre:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionName" Font-Size="15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"><></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelLastNameNewUser" Font-Size="15.9px" runat="server" Text="Apellido:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionLastname" Font-Size="15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelEmailNewUser" Font-Size="15.9px" runat="server" Text="Correo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionEmail" Font-Size="15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <%if (loggedUser.ListOfVehicles.Count <= 0)
                            { %>


                        <div class="form-group">
                            <asp:Label ID="LabelBrandOfVehicle" Font-Size="15.9px" runat="server" Text="Marca:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxBrandOfVehicle" Font-Size="16.5px" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelIdVehicleOfVehicle" Font-Size="15.9px" runat="server" Text="Numero de placa:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxIdOfVehicle" Font-Size="16.5px" runat="server" CssClass="form-control" OnTextChanged="TextBoxIdVehicle_TextChanged"></asp:TextBox>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="CheckBoxIsMotrocycle" Font-Size="15.9px" runat="server" Text="Es Moto?" Checked="false" CssClass="checkbox" />
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNothing" Font-Size="15.9px" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelFirstError" Font-Size="15.9px" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonRequestRegistryAndAddVehicle" Font-Size="15.9px" runat="server" CssClass="btn btn-primary" Text="Solicitar Marchamo" OnClick="btnAddVehicle_Click" />
                            </div>
                        </div>

                        <% }
                            else
                            {%>
                        <div class="table-responsive">
                            <asp:Table ID="TableRegisteredVehicles" runat="server" class="table table-bordered">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell>PLACA</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>MARCA</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>TIPO</asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                            </asp:Table>
                        </div>
                        <asp:Label ID="Label1" runat="server" Text="M = Moto" CssClass="col-lg-2 control-label"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="VL = Vehiculo Liviano" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="form-group">
                            <asp:Label ID="LabelTransparent" Font-Size="15.9px" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelError" Font-Size="15.9px" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonCreateRequestRegistry" Font-Size="15.9px" runat="server" CssClass="btn btn-primary" Text="Crear Marchamo" OnClick="btnCreateRegistry_Click" />
                            </div>
                        </div>
                        <%}%>
                    </fieldset>
                </div>
            </div>
        </div>
        <%if (loggedUser.Registry)
            { %>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <div id="printable" class="jumbotron">
                            <h1>
                                <img alt="Universidad Latina" class="img-responsive" src="img/ulatinalogoverde.png" /></h1>
                            <h2>ID:<%=loggedUser.Id %> </h2>
                            <p>Estudiante: <%=loggedUser.Name %> <%=loggedUser.Lastname %> </p>
                            <p>Vehiculo(s): <%=vehicleFromUser.Brand%> <%=vehicleFromUser.Id %> </p>
                            <div class="table-responsive">
                                <asp:Table ID="TableRequestRegistry" runat="server" class="table table-bordered" BorderStyle="Solid" BorderColor="Black">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell ForeColor="Black">PLACA</asp:TableHeaderCell>
                                        <asp:TableHeaderCell ForeColor="Black">MARCA</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-3">
                                <asp:Button ID="ButtonRequestRegistry" Font-Size="15.9px" runat="server" CssClass="btn btn-primary" Text="Solicitar Marchamo" OnClick="btnRequestRegistry_Click" />

                                <input id="buttonPrint" type='button' value='Imprimir' class="btn btn-success" />
                            </div>
                        </div>
                        <div class="col-lg-10">
                        </div>
                        <%if (emailAlert.Equals("Enviado"))
                            { %>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-1">
                                <div class="alert alert-success" id="warning-alert">
                                    <button type="button" class="close" data-dismiss="alert">x</button>
                                    <strong>Enviado! </strong>
                                    <p>Se ha enviado el marchamo a su correo electronico <%=loggedUser.Email %></p>
                                </div>
                            </div>
                        </div>
                        <% }
                            else if (emailAlert.Equals("No Enviado"))
                            {%>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-1">
                                <div class="alert alert-danger"
                                    id="warning-alert">
                                    <button type="button" class="close" data-dismiss="alert">x</button>
                                    <strong>No enviado!</strong>
                                    <p>No se envio el correo, verifique su direccion de correo. <%=loggedUser.Email %></p>
                                </div>
                            </div>
                        </div>
                        <% } %>
                    </fieldset>
                </div>
            </div>
        </div>

        <% } %>
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
        document.getElementById("buttonPrint").onclick = function () {
            printElement(document.getElementById("printable"));
            window.print();
        }

        function printElement(elem, append, delimiter) {
            var domClone = elem.cloneNode(true);

            var $printSection = document.getElementById("printSection");

            if (!$printSection) {
                var $printSection = document.createElement("div");
                $printSection.id = "printSection";
                document.body.appendChild($printSection);
            }

            if (append !== true) {
                $printSection.innerHTML = "";
            }

            else if (append === true) {
                if (typeof (delimiter) === "string") {
                    $printSection.innerHTML += delimiter;
                }
                else if (typeof (delimiter) === "object") {
                    $printSection.appendChlid(delimiter);
                }
            }

            $printSection.appendChild(domClone);
        }


    </script>
    <style>
        @media screen {
            #printSection {
                background: #0d4d16;
                display: none;
            }
        }

        @media print {

            body * {
                background: #0d4d16;
                visibility: hidden;
            }

            #printSection, #printSection * {
                background: #0d4d16;
                visibility: visible;
            }

            #printSection {
                background: #0d4d16;
                position: absolute;
                left: 0;
                top: 0;
            }
        }

        .desingOfParking {
            height: 525px;
            width: 485px;
            overflow: auto;
        }
    </style>
</asp:Content>

