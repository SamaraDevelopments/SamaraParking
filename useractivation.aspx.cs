using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_UserActivation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }

        User requestingUser = (User)Session["USER"];

        LabelSessionId.Text = requestingUser.Id.ToString();
        LabelSessionName.Text = requestingUser.Name;
        LabelSessionLastname.Text = requestingUser.Lastname;
        LabelSessionEmail.Text = requestingUser.Email;

    }
    protected void TextBoxIdVehicle_TextChanged(object sender, EventArgs e)
    {
        TextBoxIdOfVehicle.Text = TextBoxIdOfVehicle.Text.ToUpper();
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
                Session["Vehicle"] = vehicleToAdd;
                currentUser.Registry = true;
               
            }
        }
        else
        {
            LabelError.Text = "El formato de placa esta equivocado";
        }
    }
}