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

        if (TextBoxNameOfNewParking.Text.Equals("") || TextBoxLocationOfNewParking.Text.Equals("") || TextBoxNormalSpot.Text.Equals("") || TextBoxReserveSpot.Text.Equals("") || TextBoxDimensionsOfParkingX.Text.Equals("") || TextBoxDimensionsOfParkingY.Text.Equals("") || TextBoxMotocyclesForRegularSpot.Text.Equals(""))
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
                    ParkingSpot ps = new ParkingSpot();
                    ps.SpotType = "Espacio Reservado";//Spot for disabled people
                    ps.IdParking = pl.Id;
                    pb.AddParkingSpot(ps);
                    pl.ListOfSpots.Add(ps);
                }
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
                TextBoxReserveSpot.Text = null;
                TextBoxLocationOfNewParking.Text = null;
                TextBoxDimensionsOfParkingX.Text = null;
                TextBoxDimensionsOfParkingY.Text = null;
                TextBoxMotocyclesForRegularSpot.Text = null;

            }
        }
    }
    public void FillTableDesignOfNewParking()
    {
        string idToRadiobutton = "";
        DataTable tableDesingOfParking = new DataTable();
        for (int counteRow=0; counteRow < Int32.Parse(TextBoxDimensionsOfParkingX.Text); counteRow++)
        {
            foreach (DataRow dtr in tableDesingOfParking.Rows)
            {
                TableRow tr = new TableRow();
                for (int counterColumn = 0; counterColumn < Int32.Parse(TextBoxDimensionsOfParkingY.Text); counterColumn++)
                {
                    foreach (DataColumn dtc in tableDesingOfParking.Columns)
                    {
                        TableCell tc = new TableCell();

                        CheckBox rdbStreet = new CheckBox();
                        rdbStreet.Text = "Calle";
                        rdbStreet.ID = idToRadiobutton + "nothing";
                        rdbStreet.CssClass = "checkbox";

                        CheckBox rdbReserveSpot = new CheckBox();
                        rdbReserveSpot.Text = "Discapacitados";
                        rdbReserveSpot.ID = idToRadiobutton + "reserveSpot";
                        rdbReserveSpot.CssClass = "checkbox";

                        CheckBox rdbRegularSpot = new CheckBox();
                        rdbRegularSpot.Text = "Regulares";
                        rdbRegularSpot.ID = idToRadiobutton + "RegularSpot";
                        rdbRegularSpot.CssClass = "checkbox";

                        tc.Controls.Add(rdbStreet);
                        tc.Controls.Add(rdbReserveSpot);
                        tc.Controls.Add(rdbRegularSpot);

                        tr.Cells.Add(tc);
                    }
                }
                TableDesignOfNewParking.Rows.Add(tr);
            }
        }
    }
}