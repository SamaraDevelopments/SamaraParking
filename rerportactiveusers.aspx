﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="rerportactiveusers.aspx.cs" Inherits="Form_RerportActiveUsers" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">

    <!-- ACA EL FORM -->
    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Profesores activos:</legend>
                        <div class="img-responsive">

                          <div id="chart_div"></div>
                        
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
     <% User loggedUser = (User)Session["USER"];  %>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.backstretch.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart', 'bar'] });
        google.setOnLoadCallback(drawMultSeries);

        function drawMultSeries() {
            var data = google.visualization.arrayToDataTable([
              ['Cuatrimestre', 'Profesor', '<%=loggedUser.Name%>'],
              ['Primero', <%=5%>, 250],
              ['Segundo', 41, 320],
              ['Tercer', 10, 510],
            ]);

            var options = {
                title: 'Usuarios Activos',
                chartArea: { width: '50%' },
                hAxis: {
                    title: 'Total Population',
                    minValue: 0
                },
                vAxis: {
                    title: 'Cuatrimestre'
                }
            };

            var chart = new google.visualization.BarChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>
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
        .tableProfessor {
            height: 250px;
            width: auto;
            overflow: auto;
        }

        .tableStudent {
            height: 250px;
            width: auto;
            overflow: auto;
        }
    </style>
</asp:Content>

