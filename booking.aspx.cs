using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_booking : System.Web.UI.Page
{
    int selectedPosition = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }
        
        FillDropDownListVehiclesFromUser();
        FillDropDownListParking();
        FillTableDesignOfNewParking((string)Session["ParkingName"]);
        if (!IsPostBack)
        {
            FillTableDesignOfNewParking((string)Session["ParkingName"]);
        }
    }
    public void FillDropDownListParking()
    {
        string parkingName="";
        ParkingBusiness pb = new ParkingBusiness();
        pb.GetParkingForBooking();

        DropDownListParking.DataTextField = pb.GetParkingForBooking().Tables[0].Columns["Name"].ToString();
        DropDownListParking.DataValueField = pb.GetParkingForBooking().Tables[0].Columns["Id"].ToString();
        DropDownListParking.DataSource = pb.GetParkingForBooking().Tables[0];
        DropDownListParking.DataBind();
        parkingName = DropDownListParking.SelectedItem.Text;
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
        int spotId = pb.GetSpotFromPosition(selectedPosition, (string)Session["ParkingName"]);

        newBooking.EntryTime = DateTime.Parse(TextBoxInitialTime.Text);
        newBooking.ExitTime = DateTime.Parse(TextBoxFinalTime.Text);
        newBooking.IdVehicle.Id = DropDownListVehicleFormUser.SelectedValue;
        newBooking.IdUser.Id = currentUser.Id;
        newBooking.Date = DateTime.Today;
        newBooking.IdParkingSpot.Id = spotId;
    }

    public void FillTableDesignOfNewParking(string parkingName)
    {
        TableDesignOfNewParking.Rows.Clear();
        ParkingBusiness pb = new ParkingBusiness();
        ParkingLot parkingTable = new ParkingLot();
        parkingTable.Name = parkingName;
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
                tr.Cells.Add(tc);
                counter++;
            }
            counter++;
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
        string parkingName = "";
        parkingName = DropDownListParking.SelectedItem.Text;
        Session["ParkingName"] = parkingName;
        DropDownListParking.SelectedIndex = DropDownListParking.Items.IndexOf(DropDownListParking.Items.FindByText(parkingName));
    }
}