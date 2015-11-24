<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Form_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <%
            User loggedUser = (User)Session["USER"];

        %>
        <!-- ACA EL FORM -->
        <div class="container">
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="registrationform">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Bienvenido <%=loggedUser.Name%></legend>
                            <div class="form-group">
                            </div>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Primary" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-warning" Text="Warning" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Success" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-info" Text="Info" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button4" runat="server" CssClass="btn btn-default" Text="Default" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button5" runat="server" CssClass="btn btn-danger" Text="Danger" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button6" runat="server" CssClass="btn btn-link" Text="Link" OnClick="btnSubmit_Click" />
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

