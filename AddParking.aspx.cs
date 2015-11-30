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

            if (pb.AddParking(pl) == -1)
            {
                LabelError.Text = "Parqueo ya existe";
            }
            else
            {
                pl.Id = pb.AddParking(pl);
                for (int counter = 0; counter < Int32.Parse(TextBoxReserveSpot.Text); counter++)
                {
                    ps.SpotType = "Espacio Reservado";//Spot for disabled people
                    ps.IdParking = pl.Id;
                    pb.AddParkingSpot(ps);
                    pl.ListOfSpots.Add(ps);
                }
                for (int counter = 0; counter < Int32.Parse(TextBoxMotorcycleSpots.Text); counter++)
                {
                    ps.SpotType = "Espacio para motocicletas";//MotorcycleSpot
                    ps.IdParking = pl.Id;
                    pb.AddParkingSpot(ps);
                    pl.ListOfSpots.Add(ps);
                }
                for (int counter = 0; counter < Int32.Parse(TextBoxNormalSpot.Text); counter++)
                {
                    ps.SpotType = "Normal Spot";//Normal Spot
                    ps.IdParking = pl.Id;
                    pb.AddParkingSpot(ps);
                    pl.ListOfSpots.Add(ps);
                }
                pl.Capacity = pl.ListOfSpots.Count;
                pb.UpdateParking(pl);

                TextBoxNormalSpot.Text = null;
                TextBoxNameOfNewParking.Text = null;
                TextBoxReserveSpot.Text = null;
                TextBoxMotorcycleSpots.Text = null;
                TextBoxLocationOfNewParking.Text = null;
            }


        }
    }
}