<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="activeuser.aspx.cs" Inherits="Form_activeUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
            Paginador = function (divPaginador, tabla, tamPagina) {
                this.miDiv = divPaginador; //un DIV donde irán controles de paginación
                this.tabla = tabla;           //la tabla a paginar
                this.tamPagina = tamPagina; //el tamaño de la página (filas por página)
                this.pagActual = 1;         //asumiendo que se parte en página 1
                this.paginas = Math.floor((this.tabla.rows.length - 1) / this.tamPagina); //¿?

                this.Mostrar = function () {
                    //Crear la tabla
                    var tblPaginador = document.createElement('TableActiveProfessor');

                    //Agregar una fila a la tabla
                    var fil = tblPaginador.insertRow(tblPaginador.rows.length);

                    //Ahora, agregar las celdas que serán los controles
                    var ant = fil.insertCell(fil.cells.length);
                    ant.innerHTML = 'Anterior';
                    ant.className = 'pag_btn'; //con eso le asigno un estilo

                    var num = fil.insertCell(fil.cells.length);
                    num.innerHTML = ''; //en rigor, aún no se el número de la página
                    num.className = 'pag_num';

                    var sig = fil.insertCell(fil.cells.length);
                    sig.innerHTML = 'Siguiente';
                    sig.className = 'pag_btn';
                    //Como ya tengo mi tabla, puedo agregarla al DIV de los controles
                    this.miDiv.appendChild(tblPaginador);

                    //¿y esto por qué?
                    if (this.tabla.rows.length - 1 > this.paginas * this.tamPagina)
                        this.paginas++;
                }
            }

            this.SetPagina = function (num) {
                if (num < 0 || num > this.paginas)
                    return;

                this.pagina = num;
                var min = 1 + (this.pagina - 1) * this.tamPagina;
                var max = min + this.tamPagina - 1;

                for (var i = 1; i < this.tabla.rows.length; i++) {
                    if (i < min || i > max)
                        this.tabla.rows[i].style.display = 'none';
                    else
                        this.tabla.rows[i].style.display = '';
                }
                this.miDiv.firstChild.rows[0].cells[1].innerHTML = this.pagina;
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyFront" Runat="Server">
    
            <!-- ACA EL FORM -->
    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Profesores activos:</legend>
                        
                        <div class="form-group">
                            <div class="col-lg-10">
                                <asp:Table ID="TableActiveProfessor" runat="server" class="table table-bordered">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Apellido</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div>
                        <div id="pagerForProfessor"></div>
                                             
                        <legend>Estudiantes activos:</legend>
                        
                        <div class="form-group">
                            <div class="col-lg-10">
                                <asp:Table ID="TableActiveStudent" runat="server" class="table table-bordered">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Apellido</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div>   
                        <div id="pagerForStudent"></div>                  
                    </fieldset>
                </div>
            </div>
        </div>
        </div>
        <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.backstretch.js" type="text/javascript"></script>
    <script type="text/javascript">
        var p = new Paginador(
            document.getElementById('pagerForProfessor'),
            document.getElementById('TableActiveProfessor'),
            2
        );
        p.Mostrar();
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
</asp:Content>

