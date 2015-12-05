using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_booking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }
        FillDropDownListParking();
        FillDropDownListVehiclesFromUser();
    }
    public void FillDropDownListParking()
    {
        ParkingBusiness pb = new ParkingBusiness();
        pb.GetParkingForBooking();

        DropDownListParking.DataTextField = pb.GetParkingForBooking().Tables[0].Columns["Name"].ToString();
        DropDownListParking.DataValueField = pb.GetParkingForBooking().Tables[0].Columns["Id"].ToString();
        DropDownListParking.DataSource = pb.GetParkingForBooking().Tables[0];
        DropDownListParking.DataBind();
    }
    public void FillDropDownListVehiclesFromUser()
    {
        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        vb.GetVehiclesForBooking(currentUser);

        DropDownListVehicleFormUser.DataTextField = vb.GetVehiclesForBooking(currentUser).Tables[0].Columns["Vehicleid"].ToString();//null
        DropDownListVehicleFormUser.DataValueField = vb.GetVehiclesForBooking(currentUser).Tables[0].Columns["Vehicleid"].ToString();
        DropDownListVehicleFormUser.DataSource = vb.GetVehiclesForBooking(currentUser).Tables[0];
        DropDownListVehicleFormUser.DataBind();
    }



    protected void btn_BookingSpot_Click(object sender, EventArgs e)
    {
        Booking newBooking = new Booking();
        BookingBusiness bb = new BookingBusiness();
        User currentUser = (User)Session["USER"];

        newBooking.EntryTime = DateTime.Parse(TextBoxInitialTime.Text);
        newBooking.ExitTime = DateTime.Parse(TextBoxFinalTime.Text);
        newBooking.IdVehicle.Id = DropDownListVehicleFormUser.SelectedValue;
        newBooking.IdUser.Id = currentUser.Id;
        newBooking.Date = DateTime.Today;
        newBooking.IdParkingSpot.Id = DropDownListParking.SelectedValue; //Esto seria con la logica cuando le da click a un sspot del diseño del parqueo.
    }
}