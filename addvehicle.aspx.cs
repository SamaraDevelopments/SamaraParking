using System;
using System.Collections.Generic;
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
    protected List<Vehicle> UserVehicles()
    {
        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        Session["LISTOFVEHICLES"] = vb.GetUserListOfVehicles(currentUser);

        return vb.GetUserListOfVehicles(currentUser);
    }
    protected void FillTableUserVehicles()
    {

        List<Vehicle> userVehicles = UserVehicles();

        TableRow tr = new TableRow();

        if (userVehicles != null)
        {
            TableCell tc = new TableCell();
            tc.Text = "INFO";
            tr.Cells.Add(tc);
            TableRegistryVehicles.Rows.Add(tr);
        }

        foreach (Vehicle vehicle in userVehicles)
        {
            TableCell tc = new TableCell();
            TableCell tc2 = new TableCell();
            TableCell tc3 = new TableCell();
            tc.Text = (vehicle.Id);
            tr.Cells.Add(tc);
            tc2.Text = (vehicle.Brand);
            tr.Cells.Add(tc2);
            tc.Text = string.Format("<button ID=\"Button8\" runat=\"server\" Class=\"btn btn-danger\">HOLA</button>");
            tr.Cells.Add(tc3);
            TableRegistryVehicles.Rows.Add(tr);
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