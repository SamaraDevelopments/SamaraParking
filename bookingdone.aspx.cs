using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bookingdone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Booking booking = new Booking();
        booking = (Booking)Session["BOOKING"];
        LabelVehicle.Text = booking.IdVehicle.Id.ToString();
        LabelNameParking.Text = booking.IdParkingLot.Name;
        LabelIdSpotOfPaking.Text = booking.IdParkingSpot.Id.ToString();
        LabelinitialTime.Text = booking.EntryTime.ToString();
        LabelFinalTime.Text = booking.ExitTime.ToString();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("booking.aspx");
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

}