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
            FillDropDownListVehiclesFromUser();
            FillDropDownListParking();
            FillTableDesignOfNewParking(Int32.Parse(DropDownListParking.SelectedValue));
        }
        else
        {
            FillTableDesignOfNewParking((int)Session["DropDownIndex"]);
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
        int spotId = pb.GetSpotFromPosition(selectedPosition, Int32.Parse(DropDownListParking.SelectedValue));

        newBooking.EntryTime = DateTime.Parse(TextBoxInitialTime.Text);
        newBooking.ExitTime = DateTime.Parse(TextBoxFinalTime.Text);
        newBooking.IdVehicle.Id = DropDownListVehicleFormUser.SelectedValue;
        newBooking.IdUser.Id = currentUser.Id;
        newBooking.Date = DateTime.Today;
        newBooking.IdParkingSpot.Id = spotId;
    }

    public void FillTableDesignOfNewParking(int parkingName)
    {
        TableDesignOfNewParking.Rows.Clear();
        ParkingBusiness pb = new ParkingBusiness();
        ParkingLot parkingTable = new ParkingLot();
        parkingTable.Id = parkingName;
        int counter = 0;
        int spotId = 0;
        string spotType = "";
        parkingTable = pb.GetDimensions(parkingTable);
        for (int counterRow = 0; counterRow < parkingTable.DimensionX; counterRow++)
        {
            TableRow tr = new TableRow();
            for (int counterColumn = 0; counterColumn < parkingTable.DimensionY; counterColumn++)
            {
                TableCell tc = new TableCell();
                tc.CssClass = "btn-error";
                tc.Controls.Add(addButton(counter));
                spotId = pb.GetSpotFromPosition(counter, parkingTable.Id);
                spotType = pb.GetSpotType(spotId).Trim();

                switch (spotType)
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
    }
    protected void UpdateParking_SelectedIndexChange(object sender, EventArgs e)
    {
        if (Int32.Parse(DropDownListParking.SelectedValue) > 0)
        {
            Session["DropDownIndex"] = DropDownListParking.SelectedIndex;
            DropDownListParking.SelectedIndex = (int)Session["DropDownIndex"];
            FillTableDesignOfNewParking(Int32.Parse(DropDownListParking.SelectedValue));
        }
    }
}