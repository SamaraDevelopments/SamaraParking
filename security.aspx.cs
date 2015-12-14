using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class security : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            FillDropDownListParking();
            FillDropDownListInitialHour();
        }
    }
    public void FillDropDownListParking()
    {
        ParkingBusiness parkingBusiness = new ParkingBusiness();
        DataSet dataSet = parkingBusiness.GetParkingForBooking();

        DropDownListParking.DataTextField = dataSet.Tables[0].Columns["Name"].ToString();
        DropDownListParking.DataValueField = dataSet.Tables[0].Columns["Id"].ToString();
        DropDownListParking.DataSource = dataSet.Tables[0];
        DropDownListParking.DataBind();
    }
    public void FillDropDownListInitialHour()
    {
        int hours = 0;
        int min = 0;
        string time = "";

        for (int i = 7; i <= 23; i++)
        {
            hours = i;
            for (int j = 0; j <= 30; j += 30)
            {
                min = j;
                if (min == 0)
                {
                    time = hours + ":" + min + "0";
                }
                else
                {
                    time = hours + ":" + min;
                }
                DropDownListInitialHour.Items.Add(time);
            }
        }
    }
    protected void btnVerifySpot_Click(object sender, EventArgs e)
    {
        Booking booking = new Booking();
        ParkingLot parkingLot = new ParkingLot();

        booking.EntryTime = DateTime.Parse(DropDownListInitialHour.SelectedValue);
        booking.IdParkingLot = parkingLot;
        booking.IdParkingLot.Id = Int32.Parse(DropDownListParking.SelectedValue);
        FillTableReportBookingForSecurity(booking.IdParkingLot, booking.EntryTime);
    }

    public void FillTableReportBookingForSecurity(ParkingLot selectedParkingLot, DateTime selectedDateTime)
    {
        BookingBusiness bookingBusiness = new BookingBusiness();

        bookingBusiness.GetReportForSecurity(selectedParkingLot,selectedDateTime);
    }
}