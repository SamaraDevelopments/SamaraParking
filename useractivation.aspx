<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="useractivation.aspx.cs" Inherits="Form_UserActivation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">

    
    <%
        User loggedUser = (User)Session["USER"];

      %>

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
                                    <asp:Label ID="LabelSessionName" runat="server" Text="<%=loggedUser.Name%>" CssClass="col-lg-2 control-label"><></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelLastNameNewUser" runat="server" Text="Apellido:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:Label ID="LabelSessionLastname" runat="server" Text="<%=loggedUser.Lastname%>" CssClass="col-lg-2 control-label"></asp:Label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="LabelEmailNewUser" runat="server" Text="Correo:" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:Label ID="LabelSessionEmail" runat="server" Text="<%=loggedUser.Email%>" CssClass="col-lg-2 control-label"></asp:Label>
                                </div>
                            </div>
                             
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="ButtonRequestRegistry" runat="server" CssClass="btn btn-primary" Text="Solicitar Marchamo" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
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
    <style>
        .desingOfParking {
            height: 525px;
            width: 485px;
            overflow: auto;
        }
    </style>
</asp:Content>

