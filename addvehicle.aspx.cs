using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class form_addvehicle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }

        FillTableUserVehicles();

    }

    protected void FillTableUserVehicles()
    {
        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        DataTable userVehiclesTable = vb.GetVehiclesFromUser(currentUser);

        foreach (DataRow dr in userVehiclesTable.Rows)
        {
            TableRow tr = new TableRow();
            int counterCells = 0;

            foreach (DataColumn dc in userVehiclesTable.Columns)
            {
                TableCell tc = new TableCell();


                if (counterCells == 3)
                {
                    tc.Text = string.Format("<button ID=\"Button8\" Class=\"btn btn-danger\" title=\"Eliminar\"><span class=\"glyphicon glyphicon-remove\"></span>  </button> &nbsp <button ID=\"Button8\" Class=\"btn btn-warning\" title=\"Editar\"><span class=\"glyphicon glyphicon-edit\"></span>  </button>");
                    tr.Cells.Add(tc);
                }
                else
                {

                    try
                    {
                        bool isMoto = (bool)dr[dc.ColumnName];
                        if (isMoto)
                        {
                            tc.Text = string.Format("M");
                        }
                        else
                        {
                            tc.Text = string.Format("VL");
                        }

                    }
                    catch (Exception)
                    {


                        tc.Text = string.Format(dr[dc.ColumnName].ToString());
                    }

                  
                    tr.Cells.Add(tc);
                    //tc.Text = string.Format("<button ID=\"Button8\" runat=\"server\" Class=\"btn btn-danger\">HOLA</button>");

                }
                counterCells++;
                TableRegistryVehicles.Rows.Add(tr);

            }
        }
    }

    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {

        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        Vehicle vehicleToAdd = new Vehicle();

        vehicleToAdd.Id = TextBoxIdOfVehicle.Text;
        vehicleToAdd.Brand = TextBoxBrandOfVehicle.Text;

        if (CheckBoxIsMotrocycle.Checked)
        {
            vehicleToAdd.VehicleType = true;
        }
        else
        {
            vehicleToAdd.VehicleType = false;
        }
        if (vb.ValidateLicensePlate(vehicleToAdd))
        {

            if (vb.AddVehicle(vehicleToAdd, currentUser) != null)
            {
                LabelError.Text = vb.AddVehicle(vehicleToAdd, currentUser);
            }
            else
            {
                TextBoxIdOfVehicle.Text = null;
                TextBoxBrandOfVehicle.Text = null;
            }
        }
        else
        {
            LabelError.Text = "El formato de placa esta equivocado";
        }
    }

    protected void TextBoxIdVehicle_TextChanged(object sender, EventArgs e)
    {
        TextBoxIdOfVehicle.Text = TextBoxIdOfVehicle.Text.ToUpper();
    }
}