<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="reportactiveusers.aspx.cs" Inherits="Form_RerportActiveUsers" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" runat="Server">

    <!-- ACA EL FORM -->
    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Usuarios con marchamo activo:</legend>
                         <div class="form-group">
                            <asp:Label ID="LabelYear" Font-Size= "15.9px" runat="server" Text="Año:" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownListYearReport" Font-Size= "15.9px" runat="server" CssClass="form-control ddl" AutoPostBack="true" OnSelectedIndexChanged="UpdateParking_SelectedIndexChange">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="img-responsive">

                          <div id="chart_div"></div>
                        
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>

     <% User loggedUser = (User)Session["USER"];
        List<int> reportList = (List<int>)Session["REPORTLIST"]; %>

    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.backstretch.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart', 'bar'] });
        google.setOnLoadCallback(drawMultSeries);

        function drawMultSeries() {
            var data = google.visualization.arrayToDataTable([
              ['Cuatrimestre', 'Profesor', 'Estudiantes'],
              ['Primero', <%=reportList[1]%>, <%=reportList[0]%>],
              ['Segundo', <%=reportList[3]%>, <%=reportList[2]%>],
              ['Tercer', <%=reportList[5]%>, <%=reportList[4]%>],
            ]);

            var options = {
                title: 'Usuarios Activos',
                chartArea: { width: '50%' },
                hAxis: {
                    title: 'Total Usuarios',
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
            duration: 5500,
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

