<%@ Page ContentType="text/html; charset=utf-8" Title="Ingreso Latina Parking" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Form_index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyFront" runat="Server">

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
                            <div class="col-lg-10">
                                <asp:Label ID="LabelRegistry" runat="server" Text="Marchamo: " CssClass="col-lg-2 control-label"></asp:Label>
                               <div class="col-lg-10">
                                <asp:Label ID="LabelRegistryOfCommingUser" runat="server" CssClass="col-lg-2 control-label"></asp:Label>
                                 </div>
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
