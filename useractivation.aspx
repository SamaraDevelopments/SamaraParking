<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="useractivation.aspx.cs" Inherits="Form_UserActivation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">


    <%
        User loggedUser = (User)Session["USER"];
        Vehicle vehicleFromUser = (Vehicle)Session["VEHICLE"];
        string activatioMsg = (string)Session["ACTIVATION"];
    %>

    <div class="container">
        <!-- ACA EL FORM -->
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Agregar usuario<i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="LabelIDNewUser" Font-Size= "15.9px" runat="server" Text="ID:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionId" Font-Size= "15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"><></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNameNewUser" Font-Size= "15.9px" runat="server" Text="Nombre:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionName" Font-Size= "15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"><></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelLastNameNewUser"  Font-Size= "15.9px"runat="server" Text="Apellido:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionLastname" Font-Size= "15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelEmailNewUser" Font-Size= "15.9px" runat="server" Text="Correo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionEmail" Font-Size= "15.9px" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <%if (loggedUser.ListOfVehicles.Count <= 0)
                            { %>


                        <div class="form-group">
                            <asp:Label ID="LabelBrandOfVehicle" Font-Size= "15.9px" runat="server" Text="Marca:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxBrandOfVehicle" Font-Size= "16.5px" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelIdVehicleOfVehicle" Font-Size= "15.9px" runat="server" Text="Numero de placa:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxIdOfVehicle" Font-Size= "16.5px" runat="server" CssClass="form-control" OnTextChanged="TextBoxIdVehicle_TextChanged"></asp:TextBox>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="CheckBoxIsMotrocycle" Font-Size= "15.9px" runat="server" Text="Es Moto?" Checked="false" CssClass="checkbox" />
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNothing" Font-Size= "15.9px" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelFirstError" Font-Size= "15.9px" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonRequestRegistryAndAddVehicle" Font-Size= "15.9px" runat="server" CssClass="btn btn-primary" Text="Solicitar Marchamo" OnClick="btnAddVehicle_Click" />
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
                            <asp:Label ID="LabelTransparent" Font-Size= "15.9px" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelError" Font-Size= "15.9px" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonCreateRequestRegistry" Font-Size= "15.9px" runat="server" CssClass="btn btn-primary" Text="Crear Marchamo" OnClick="btnCreateRegistry_Click"/>
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
                        <div class="jumbotron">
                                <h1><img alt="Universidad Latina" class="img-responsive" src="img/ulatina.png" /></h1>
                                <h2>ID:<%=loggedUser.Id %> </h2>
                                <p>Estudiante: <%=loggedUser.Name %> <%=loggedUser.Lastname %> </p>
                                <p>Vehiculo(s): <%=vehicleFromUser.Brand%> <%=vehicleFromUser.Id %> </p>
                                <div class="table-responsive">
                                    <asp:Table ID="TableRequestRegistry" runat="server" class="table table-bordered">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>PLACA</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>MARCA</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                            </div>
                        <asp:Button ID="ButtonRequestRegistry" Font-Size= "15.9px" runat="server" CssClass="btn btn-primary" Text="Solicitar Marchamo" OnClick="btnRequestRegistry_Click" />
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
        .desingOfParking {
            height: 525px;
            width: 485px;
            overflow: auto;
        }
    </style>
</asp:Content>

