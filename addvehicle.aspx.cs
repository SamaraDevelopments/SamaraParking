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
        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }
        //FillTableUserVehicles();


    }
    protected List<Vehicle> UserVehicles()
    {
        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        Session["LISTOFVEHICLES"] = vb.GetUserListOfVehicles(currentUser);

        return vb.GetUserListOfVehicles(currentUser);
    }
   /* protected void FillTableUserVehicles()
    {

        List<Vehicle> userVehicles = UserVehicles();
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        tc.Text = "HOLA";
        tr.Cells.Add(tc);

        Table1.Rows.Add(tr);

        foreach (Vehicle vehicle in userVehicles)
        {
            tc.Text = (vehicle.Id);
            tr.Cells.Add(tc);
            tc.Text = (vehicle.Brand);
            tr.Cells.Add(tc);
            tc.Text = string.Format("<button ID=\"Button8\" runat=\"server\" Class=\"btn btn-danger\">HOLA</button>");
            tr.Cells.Add(tc);
            Table1.Rows.Add(tr);
        }

    } */
    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {
        

        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        Vehicle vehicleToAdd = new Vehicle();

        vehicleToAdd.Id = TextBoxIdVehicle.Text;
        vehicleToAdd.Brand = TextBoxBrand.Text;

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
                Label4.Text = vb.AddVehicle(vehicleToAdd, currentUser);
            }
            else
            {
                TextBoxIdVehicle.Text = null;
                TextBoxBrand.Text = null;
            }
        }
        else
        {
            Label4.Text = "El formato de placa esta equivocado";
        }
    }
    protected void TextBoxIdVehicle_TextChanged(object sender, EventArgs e)
    {
        TextBoxIdVehicle.Text = TextBoxIdVehicle.Text.ToUpper();
    }
}