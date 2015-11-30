using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_addparking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void btnAddNewParking_Click(object sender, EventArgs e)
    {
        PakingBusiness pb = new PakingBusiness();
        ParkingSpot ps = new ParkingSpot(); ;
        ParkingLot pl = new ParkingLot();
        pl.ListOfSpots = new List<ParkingSpot>();

        if (TextBoxNameOfNewParking.Text.Equals(null) || TextBoxLocationOfNewParking.Text.Equals(null) || TextBoxMotorcycleSpots.Text.Equals(null) || TextBoxNormalSpot.Text.Equals(null) || TextBoxReserveSpot.Text.Equals(null))
        {
            LabelError.Text = "Espacios vacíos";
        }
        else
        {
            pl.Name = TextBoxNameOfNewParking.Text;
            pl.Location = TextBoxLocationOfNewParking.Text;
            pl.ListOfSpots = null;
           
            for (int counter = 0; counter < Convert.ToInt64(TextBoxReserveSpot.Text); counter++)
            {
                ps.SpotType = "Espacio Reservado";//Spot for disabled people
                pb.AddParkingSpot(ps,pl);
                pl.ListOfSpots.Add(ps);
            }
            for (int counter = 0; counter < Convert.ToInt64(TextBoxMotorcycleSpots.Text); counter++)
            {
                ps.SpotType = "Espacio para motocicletas";//MotorcycleSpot
                pb.AddParkingSpot(ps, pl);
                pl.ListOfSpots.Add(ps);
            }
            for (int counter = 0; counter < Convert.ToInt64(TextBoxNormalSpot.Text); counter++)
            {
                ps.SpotType = "Normal Spot";//Normal Spot
                pb.AddParkingSpot(ps, pl);
                pl.ListOfSpots.Add(ps);
            }
           
            if (pb.AddParking(pl) != null)
            {
                LabelError.Text = pb.AddParking(pl);
            }
            else
            {
                TextBoxNormalSpot.Text = null;
                TextBoxNameOfNewParking.Text = null;
                TextBoxReserveSpot.Text = null;
                TextBoxMotorcycleSpots.Text = null;
                TextBoxLocationOfNewParking.Text = null;
            }

        }
    }
}