using System;
using System.Collections.Generic;
using System.Data;
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
        ParkingLot pl = new ParkingLot();
        pl.ListOfSpots = new List<ParkingSpot>();

        if (TextBoxNameOfNewParking.Text.Equals("") || TextBoxLocationOfNewParking.Text.Equals("") || TextBoxNormalSpot.Text.Equals("") || TextBoxDimensionsOfParkingX.Text.Equals("") || TextBoxDimensionsOfParkingY.Text.Equals("") || TextBoxMotocyclesForRegularSpot.Text.Equals(""))
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
                /*for (int counter = 0; counter < Int32.Parse(TextBoxReserveSpot.Text); counter++)
                {
                    ParkingSpot ps = new ParkingSpot();
                    ps.SpotType = "Espacio Reservado";//Spot for disabled people
                    ps.IdParking = pl.Id;
                    pb.AddParkingSpot(ps);
                    pl.ListOfSpots.Add(ps);
                }*/
                for (int counter = 0; counter < Int32.Parse(TextBoxNormalSpot.Text); counter++)
                {
                    ParkingSpot ps = new ParkingSpot();
                    ps.SpotType = "Normal Spot";//Normal Spot
                    ps.IdParking = pl.Id;
                    pb.AddParkingSpot(ps);
                    pl.ListOfSpots.Add(ps);
                }
                pl.Capacity = pl.ListOfSpots.Count;
                pb.UpdateParking(pl);
                FillTableDesignOfNewParking();

                TextBoxNormalSpot.Text = null;
                TextBoxNameOfNewParking.Text = null;
                TextBoxLocationOfNewParking.Text = null;
                TextBoxDimensionsOfParkingX.Text = null;
                TextBoxDimensionsOfParkingY.Text = null;
                TextBoxMotocyclesForRegularSpot.Text = null;

            }
        }
    }
    public void FillTableDesignOfNewParking()
    {

        for (int counterRow=0; counterRow < Int32.Parse(TextBoxDimensionsOfParkingX.Text); counterRow++)
        {
                TableRow tr = new TableRow();
                for (int counterColumn = 0; counterColumn < Int32.Parse(TextBoxDimensionsOfParkingY.Text); counterColumn++)
                {
                        TableCell tc = new TableCell();

                        Button btnStreet = new Button();
                        //btnStreet.Click += new System.EventHandler(btnEditVehicle_Click);
                        btnStreet.Text = "Calle";
                        //btnStreet.ID = idToButton + "e";
                        btnStreet.CssClass = "btn btn-info";
                        
                        Button btnReserve = new Button();
                        //btnReserve.Click += new System.EventHandler(btnEditVehicle_Click);
                        btnReserve.Text = "Discapacitado";
                        //btnReserve.ID = idToButton + "e";
                        btnReserve.CssClass = "btn btn-info";

                        tc.Controls.Add(btnStreet);
                        tc.Controls.Add(btnReserve);

                        tr.Cells.Add(tc);
                    }
                
                TableDesignOfNewParking.Rows.Add(tr);
            }
        }
}