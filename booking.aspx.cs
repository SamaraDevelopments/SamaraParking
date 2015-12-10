using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

public partial class Form_booking : System.Web.UI.Page
{
    
    int selectedPosition = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Session["DropDownIndex"] = 0;
            FillDropDownListVehiclesFromUser();
            FillDropDownListParking();
            FillDropDownListInitialHour();
            FillDropDownListFinalHour();
            FillTableDesignOfNewParking(Int32.Parse(DropDownListParking.SelectedValue));
            
        }
        else
        {
            FillTableDesignOfNewParking(Int32.Parse(DropDownListParking.SelectedValue));
        }
    }
    public void FillDropDownListInitialHour()
    {
        int hours = 0;
        int min = 0;
        string time = "";

        for (int i=7; i <= 23; i++)
        {
            hours = i;
            for (int j = 0; j <= 30; j+=30)
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
    public void FillDropDownListFinalHour()
    {
        int hours = 0;
        int min = 0;
        string time = "";

        for (int i = 8; i <= 24; i++)
        {
            hours = i;
            if (hours == 24)
            {
                min = 0;
                time = hours + ":" + min +"0";
                DropDownListFinalHour.Items.Add(time);
            }
            else
            {
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
                    DropDownListFinalHour.Items.Add(time);
                }
            }
        }
    }
    public void FillDropDownListParking()
    {
        ParkingBusiness pb = new ParkingBusiness();
        DataSet ds = pb.GetParkingForBooking();

        DropDownListParking.DataTextField = ds.Tables[0].Columns["Name"].ToString();
        DropDownListParking.DataValueField = ds.Tables[0].Columns["Id"].ToString();
        DropDownListParking.DataSource = ds.Tables[0];
        DropDownListParking.DataBind();
    }
    public void FillDropDownListVehiclesFromUser()
    {
        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        DataSet ds = vb.GetVehiclesForBooking(currentUser);

        DropDownListVehicleFormUser.DataTextField = ds.Tables[0].Columns["Vehicleid"].ToString();//null
        DropDownListVehicleFormUser.DataValueField = ds.Tables[0].Columns["Vehicleid"].ToString();
        DropDownListVehicleFormUser.DataSource = ds.Tables[0];
        DropDownListVehicleFormUser.DataBind();
    }

    protected void btnBookingSpot_Click(object sender, EventArgs e)
    {
        Booking newBooking = new Booking();
        BookingBusiness bb = new BookingBusiness();
        ParkingBusiness pb = new ParkingBusiness();
        User currentUser = (User)Session["USER"];
        Vehicle bookingVehicle = new Vehicle();
        ParkingSpot bookingSpot = new ParkingSpot();
        ParkingLot bookingParking = new ParkingLot();

        bookingSpot.Id = Int32.Parse(DropDownListParking.SelectedValue);
        bookingSpot = pb.GetSpotData(bookingSpot, (int)Session["Position"]);
        newBooking.IdVehicle = bookingVehicle;
        newBooking.IdUser = currentUser;
        newBooking.IdParkingSpot = bookingSpot;
        newBooking.IdParkingLot = bookingParking;
        newBooking.EntryTime = DateTime.Parse(DropDownListInitialHour.SelectedValue);
        newBooking.ExitTime = DateTime.Parse(DropDownListFinalHour.SelectedValue);
        newBooking.IdVehicle.Id = DropDownListVehicleFormUser.SelectedValue.Trim();
        newBooking.Date = DateTime.Today;
        newBooking.IdParkingSpot.Id = bookingSpot.Id;
        newBooking.IdParkingLot.Id = Int32.Parse(DropDownListParking.SelectedValue);

        if (bookingSpot.Id == 0)
        {
            //Return error here
        }
        else
        {
            bb.InsertBooking(newBooking);
        }
    }

    public void FillTableDesignOfNewParking(int parkingName)
    {
        TableDesignOfNewParking.Rows.Clear();
        ParkingBusiness pb = new ParkingBusiness();
        ParkingLot parkingTable = new ParkingLot();
        ParkingSpot ps = new ParkingSpot();
        parkingTable.Id = parkingName;
        ps.IdParking = parkingTable.Id;
        int counter = 0;
        parkingTable = pb.GetDimensions(parkingTable);
        for (int counterRow = 0; counterRow < parkingTable.DimensionX; counterRow++)
        {
            TableRow tr = new TableRow();
            for (int counterColumn = 0; counterColumn < parkingTable.DimensionY; counterColumn++)
            {
                TableCell tc = new TableCell();
                tc.CssClass = "btn-error";
                tc.Controls.Add(addButton(counter));
                ps = pb.GetSpotData(ps, counter);

                switch (ps.SpotType)
                {
                    case "Normal Spot":
                        tc.BackColor = Color.Transparent;
                        break;
                    case "Road Spot":
                        tc.BackColor = Color.DarkGray;
                        tc.Enabled = false;
                        break;
                    case "Handicap Spot":
                        tc.BackColor = Color.Blue;
                        tc.Enabled = false;
                        break;
                    case "Motorcycle Spot":
                        tc.BackColor = Color.Blue;
                        break;
                }
                tr.Cells.Add(tc);
                counter++;
            }
            TableDesignOfNewParking.Rows.Add(tr);
        }

    }
    public Button addButton(int counter)
    {
        Button btnReserve = new Button();
        btnReserve.Click += new System.EventHandler(btnReserve_Click);
        btnReserve.Text = "";
        btnReserve.ID = "" + (counter);
        btnReserve.CssClass = "btn-success";
        return btnReserve;
    }
    protected void btnReserve_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        selectedPosition = Int32.Parse(btn.ID);
        Session["Position"] = selectedPosition;
    }
    protected void UpdateParking_SelectedIndexChange(object sender, EventArgs e)
    {
        if (Int32.Parse(DropDownListParking.SelectedValue) > 0)
        {
            Session["DropDownIndex"] = DropDownListParking.SelectedIndex;
            DropDownListParking.SelectedIndex = (int)Session["DropDownIndex"];
        }
    }
}