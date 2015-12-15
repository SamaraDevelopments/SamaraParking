using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class security : System.Web.UI.Page
{
    int selectedPosition = -1;
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
                time = hours + ":" + min + "0";
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
        ParkingBusiness parkingbusiness = new ParkingBusiness();
        DataSet dataSet = parkingbusiness.GetParkingForBooking();

        DropDownListParking.DataTextField = dataSet.Tables[0].Columns["Name"].ToString();
        DropDownListParking.DataValueField = dataSet.Tables[0].Columns["Id"].ToString();
        DropDownListParking.DataSource = dataSet.Tables[0];
        DropDownListParking.DataBind();
    }
    public void FillDropDownListVehiclesFromUser()
    {
        VehicleBusiness vehicleBusiness = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        DataSet dataSet = vehicleBusiness.GetVehiclesForBooking(currentUser);

        DropDownListVehicleFormUser.DataTextField = dataSet.Tables[0].Columns["Vehicleid"].ToString();//null
        DropDownListVehicleFormUser.DataValueField = dataSet.Tables[0].Columns["Vehicleid"].ToString();
        DropDownListVehicleFormUser.DataSource = dataSet.Tables[0];
        DropDownListVehicleFormUser.DataBind();
    }

    protected void btnDeleteReserve_Click(object sender, EventArgs e)
    {
        Booking newBooking = new Booking();
        BookingBusiness bookingBusiness = new BookingBusiness();
        ParkingBusiness parkingBusiness = new ParkingBusiness();
        User currentUser = (User)Session["USER"];
        Vehicle bookingVehicle = new Vehicle();
        ParkingSpot bookingSpot = new ParkingSpot();
        ParkingLot bookingParking = new ParkingLot();

        bookingSpot.IdParking = Int32.Parse(DropDownListParking.SelectedValue);
        bookingSpot = parkingBusiness.GetSpotForReserve(bookingSpot, (int)Session["Position"]);
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

            bookingBusiness.DenyBooking(newBooking, newBooking.EntryTime, newBooking.ExitTime);
            bookingParking = parkingBusiness.GetDimensions(bookingParking);
            selectedPosition = -1;
            bookingParking = removeSelected(Int32.Parse(DropDownListParking.SelectedValue));
            TableDesignOfNewParking = bookingBusiness.VerifySpots(bookingParking, TableDesignOfNewParking, DateTime.Parse(DropDownListInitialHour.SelectedValue), DateTime.Parse(DropDownListFinalHour.SelectedValue));
        }
    }

    public void FillTableDesignOfNewParking(int parkingName)
    {
        TableDesignOfNewParking.Rows.Clear();
        ParkingBusiness parkingBusiness = new ParkingBusiness();
        BookingBusiness bookingBusiness = new BookingBusiness();
        ParkingLot parkingspotTable = new ParkingLot();
        ParkingSpot parking = new ParkingSpot();
        int counter = 0;
        parkingspotTable.Id = parkingName;
        parkingspotTable = parkingBusiness.GetDimensions(parkingspotTable);
        TableDesignOfNewParking = parkingBusiness.GetSpotData(parkingspotTable, TableDesignOfNewParking);

        for (int counterRow = 0; counterRow < parkingspotTable.DimensionX; counterRow++)
        {
            for (int counterColumn = 0; counterColumn < parkingspotTable.DimensionY; counterColumn++)
            {
                TableDesignOfNewParking.Rows[counterRow].Cells[counterColumn].Controls.Add(addButton(counter));
                counter++;
            }
        }
        TableDesignOfNewParking = bookingBusiness.VerifySpots(parkingspotTable, TableDesignOfNewParking, DateTime.Parse(DropDownListInitialHour.SelectedValue), DateTime.Parse(DropDownListFinalHour.SelectedValue));
        for (int counterRow = 0; counterRow < parkingspotTable.DimensionX; counterRow++)
        {
            for (int counterColumn = 0; counterColumn < parkingspotTable.DimensionY; counterColumn++)
            {
                if (TableDesignOfNewParking.Rows[counterRow].Cells[counterColumn].BackColor == Color.Red)
                {
                    TableDesignOfNewParking.Rows[counterRow].Cells[counterColumn].Enabled = true;
                }
                else
                {
                    TableDesignOfNewParking.Rows[counterRow].Cells[counterColumn].Enabled = false;
                }
                counter++;
            }
        }
    }
    public Button addButton(int counter)
    {
        Button btnDelete = new Button();
        btnDelete.Click += new System.EventHandler(btnDelete_Click);
        btnDelete.Text = "";
        btnDelete.ID = "" + (counter);
        btnDelete.CssClass = "btn-link";
        return btnDelete;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ParkingLot parkingTable = new ParkingLot();
        Button btn = (Button)sender;
        int counter = 0;
        selectedPosition = Int32.Parse(btn.ID);
        Session["Position"] = selectedPosition;
        parkingTable = removeSelected(Int32.Parse(DropDownListParking.SelectedValue));

        for (int counterRow = 0; counterRow < parkingTable.DimensionX; counterRow++)
        {
            for (int counterColumn = 0; counterColumn < parkingTable.DimensionY; counterColumn++)
            {
                if (selectedPosition == counter)
                {

                    Session["BackColor"] = TableDesignOfNewParking.Rows[counterRow].Cells[counterColumn].BackColor;
                    TableDesignOfNewParking.Rows[counterRow].Cells[counterColumn].BackColor = Color.Black;
                }
                counter++;
            }

        }


    }
    protected void UpdateParking_SelectedIndexChange(object sender, EventArgs e)
    {
        if (Int32.Parse(DropDownListParking.SelectedValue) > 0)
        {
            Session["DropDownIndex"] = DropDownListParking.SelectedIndex;
            DropDownListParking.SelectedIndex = (int)Session["DropDownIndex"];
            selectedPosition = -1;
        }
    }
    public ParkingLot removeSelected(int parkingName)
    {
        ParkingLot parkingTable = new ParkingLot();
        ParkingBusiness parkingBusiness = new ParkingBusiness();
        parkingTable.Id = parkingName;
        parkingTable = parkingBusiness.GetDimensions(parkingTable);
        for (int counterRow = 0; counterRow < parkingTable.DimensionX; counterRow++)
        {
            for (int counterColumn = 0; counterColumn < parkingTable.DimensionY; counterColumn++)
            {
                if (TableDesignOfNewParking.Rows[counterRow].Cells[counterColumn].BackColor == Color.Green)
                {
                    TableDesignOfNewParking.Rows[counterRow].Cells[counterColumn].BackColor = (Color)Session["BackColor"];
                }
            }
        }
        return parkingTable;
    }
}