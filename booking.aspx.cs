using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

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
            FillTableDesignOfNewParking(Int32.Parse(DropDownListParking.SelectedValue));
        }
        else
        {
            FillTableDesignOfNewParking(Int32.Parse(DropDownListParking.SelectedValue));
        }
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

    protected void btnBookingSpot_Click(object sender, EventArgs e)
    {
        Booking newBooking = new Booking();
        BookingBusiness bb = new BookingBusiness();
        ParkingBusiness pb = new ParkingBusiness();
        User currentUser = (User)Session["USER"];
        Vehicle bookingVehicle = new Vehicle();
        User bookingUser = new User();
        ParkingSpot bookingSpot = new ParkingSpot();
        ParkingLot bookingParking = new ParkingLot();
        bookingSpot.Id = Int32.Parse(DropDownListParking.SelectedValue);
        bookingSpot = pb.GetSpotData(bookingSpot, (int)Session["Position"]);
        newBooking.IdVehicle = bookingVehicle;
        newBooking.IdUser = bookingUser;
        newBooking.IdParkingSpot = bookingSpot;
        newBooking.IdParkingLot = bookingParking;
        
        newBooking.EntryTime = DateTime.Parse(TextBoxInitialTime.Text);
        newBooking.ExitTime = DateTime.Parse(TextBoxFinalTime.Text);
        newBooking.IdVehicle.Id = DropDownListVehicleFormUser.SelectedValue.Trim();
        newBooking.IdUser.Id = currentUser.Id;
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