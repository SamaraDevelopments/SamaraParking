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
        Session["VEHICLE"] = null;
        FillTableUserVehicles();
    }

    protected void FillTableUserVehicles()
    {
        string idToButton = "";
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
                if (counterCells == 0)
                {
                    idToButton = dr[dc.ColumnName].ToString().Trim();
                }

                if (counterCells == 3)
                {

                    Button updateBtn = new Button();
                    updateBtn.Click += new System.EventHandler(btnEditVehicle_Click);
                    updateBtn.Text = "Editar";
                    updateBtn.ID = idToButton + "e";
                    updateBtn.CssClass = "btn btn-warning";

                    Button deleteBtn = new Button();
                    deleteBtn.Click += new System.EventHandler(btnDeleteVehicle_Click);
                    deleteBtn.Text = "Borrar";
                    deleteBtn.ID = idToButton + "d";
                    deleteBtn.CssClass = "btn btn-danger";
                    tc.Controls.Add(updateBtn);
                    tc.Controls.Add(deleteBtn);
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
        if (vehicleToAdd.Id == "")
        {
            LabelError.Text = "Porfavor ingrese una marca";
        }
        else if (vehicleToAdd.Brand == "")
        {
            LabelError.Text = "Porfavor ingrese una placa";
        }
        else if (vb.ValidateLicensePlate(vehicleToAdd))
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
    protected void btnDeleteVehicle_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        Vehicle vehicleToDelete = new Vehicle();
        btn.ID = btn.ID.Remove(btn.ID.Length - 1);
        vehicleToDelete.Id = btn.ID;

        if (vb.DeleteVehicle(vehicleToDelete, currentUser) != null)
        {
            LabelError.Text = vb.DeleteVehicle(vehicleToDelete, currentUser);
        }
        else
        {
            LabelError.Text = "El vehiculo fue eliminado exitosamente";
        }
    }
    protected void btnEditVehicle_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        VehicleBusiness vb = new VehicleBusiness();
        Vehicle vehicleToAdd = new Vehicle();
        btn.ID = btn.ID.Remove(btn.ID.Length - 1);
        vehicleToAdd.Id = btn.ID;
        vehicleToAdd = vb.LoadVehicles(vehicleToAdd.Id);
        Session["VEHICLE"] = vehicleToAdd;
        TextBoxBrandOfVehicle.Text = vehicleToAdd.Brand;
        TextBoxIdOfVehicle.Text = vehicleToAdd.Id;
        TextBoxIdOfVehicle.Enabled = false;

        if (vehicleToAdd.VehicleType)
        {
            CheckBoxIsMotrocycle.Checked = true;
        }
        else
        {
            CheckBoxIsMotrocycle.Checked = false;
        }

    }

    protected void btnExecuteEditVehicle_Click(object sender, EventArgs e)
    {

        VehicleBusiness vb = new VehicleBusiness();
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
        if (vehicleToAdd.Brand == "")
        {
            LabelError.Text = "Porfavor ingrese una marca";
        }
        else if (vb.EditVehicle(vehicleToAdd) != null)
        {
            LabelError.Text = vb.EditVehicle(vehicleToAdd);

        }
        else
        {
            LabelError.ForeColor = System.Drawing.Color.Green;
            LabelError.Text = "El vehiculo fue editado";
            Session["VEHICLE"] = null;
        }
    }

    protected void btnCancelEditVehicle_Click(object sender, EventArgs e)
    {
        Session["VEHICLE"] = null;
        TextBoxIdOfVehicle.Enabled = true;
        TextBoxIdOfVehicle.Text = string.Empty;
        TextBoxBrandOfVehicle.Text = string.Empty;
        CheckBoxIsMotrocycle.Checked = false;
    }
}
