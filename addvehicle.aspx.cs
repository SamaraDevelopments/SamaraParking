using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_addvehicle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {
        VehicleBusiness vb = new VehicleBusiness();
        Vehicle vehicleToAdd = new Vehicle();
        vehicleToAdd.Id = TextBoxIdVehicle.Text;
        vehicleToAdd.Brand = TextBoxBrand.Text;
        if (CheckBoxIsMotrocycle.Checked)
        {
            vehicleToAdd.VehicleType = 1;
        }
        else
        {
            vehicleToAdd.VehicleType = 0;
        }
        if (vb.AddVehicle(vehicleToAdd, currentUser) == null)
        {

        }
        else
        {
            Label4.Text = vb.AddVehicle(vehicleToAdd, currentUser);
        }

    }
}