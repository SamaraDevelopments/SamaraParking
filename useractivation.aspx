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
                            <asp:Label ID="LabelIDNewUser" runat="server" Text="ID:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionId" runat="server" Text="" CssClass="col-lg-2 control-label"><></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNameNewUser" runat="server" Text="Nombre:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionName" runat="server" Text="" CssClass="col-lg-2 control-label"><></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelLastNameNewUser" runat="server" Text="Apellido:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionLastname" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelEmailNewUser" runat="server" Text="Correo:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelSessionEmail" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelBrandOfVehicle" runat="server" Text="Marca:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxBrandOfVehicle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelIdVehicleOfVehicle" runat="server" Text="Numero de placa:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxIdOfVehicle" runat="server" CssClass="form-control" OnTextChanged="TextBoxIdVehicle_TextChanged"></asp:TextBox>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="CheckBoxIsMotrocycle" runat="server" Text="Es Moto?" Checked="false" CssClass="checkbox" />
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelTransparent" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Label ID="LabelError" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="ButtonRequestRegistry" runat="server" CssClass="btn btn-primary" Text="Solicitar Marchamo" OnClick="btnAddVehicle_Click" />
                            </div>
                        </div>
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
                            <h1><asp:Image ImageUrl="~/img/ulatina.png" runat="server"/></h1>
                             <h2>ID:<%=loggedUser.Id %></h2>
                            <p>Estudiante: <%=loggedUser.Name %> <%=loggedUser.Lastname %></p>
                            <p>Vehiculo(s): <%=vehicleFromUser.Brand%> <%=vehicleFromUser.Id %></p>
                            <p></p>
                        </div>
                        <p><a class="btn btn-primary btn-lg" href="#" role="button">Learn more</a></p>
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

