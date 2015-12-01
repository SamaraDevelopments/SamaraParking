<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="reportbooking.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" Runat="Server">
     <!-- ACA EL FORM -->
    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Uso de parqueos:</legend>
                        
                        <div class="form-group">
                            <div class="col-lg-10">
                                <asp:Table ID="TableReportBooking" runat="server" class="table table-bordered">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Usuario</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Parqueo</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Espacio</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
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

