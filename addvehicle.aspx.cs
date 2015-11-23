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
        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        Session["LISTOFVEHICLES"] = vb.GetUserListOfVehicles(currentUser);

    }
    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {
        

        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        Vehicle vehicleToAdd = new Vehicle();

        vehicleToAdd.Id = Int32.Parse(TextBoxIdVehicle.Text);
        vehicleToAdd.Brand = TextBoxBrand.Text;

        if (CheckBoxIsMotrocycle.Checked)
        {
            vehicleToAdd.VehicleType = true;
        }
        else
        {
            vehicleToAdd.VehicleType = false;
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