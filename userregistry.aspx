<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="userregistry.aspx.cs" Inherits="Form_userregistry" %>

<asp:Content ID="ContentHeadUserRegistry" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentBodyFrontUserRegistry" ContentPlaceHolderID="BodyFront" Runat="Server">
    <div class="container">
            <!-- ACA EL FORM -->
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="registrationform">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Agregar usuario<i class="fa fa-pencil pull-right"></i></legend>
                            <div class="form-group">
                                <asp:Label ID="LabelNameNewUser" runat="server" Text="Nombre:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxNameNewUser" runat="server" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelLastNameNewUser" runat="server" Text="Apellido:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxLastNameNewUser" runat="server" placeholder="Apellido" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelPasswordNewUser" runat="server" Text="Contraseña:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxPasswordNewUser" runat="server" placeholder="Contraseña" CssClass="form-control"
                                        TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelEmailNewUser" runat="server" Text="Correo electronico:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBoxEmailNewUser" runat="server" placeholder="Correo electronico" CssClass="form-control"
                                        TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:Label ID="LabelError" runat="server" EnableViewState="False" ForeColor="Red" CssClass="control-label"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelRoleTypeNewUser" runat="server" Text="Tipo de rol:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="DropDownListRoleTypeNewUser" runat="server" CssClass="form-control ddl">
                                        <asp:ListItem>Usuario</asp:ListItem>
                                        <asp:ListItem>Oficial de seguridad</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="ButtonAddUser" runat="server" CssClass="btn btn-primary" Text="Agregar usuario" />
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

