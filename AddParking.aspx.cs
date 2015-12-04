using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Form_addparking : System.Web.UI.Page
{
    int totalRoadToAdd = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void btnAddNewParking_Click(object sender, EventArgs e)
    {
        ParkingBusiness pb = new ParkingBusiness();
        ParkingLot pl = new ParkingLot();
        pl.ListOfSpots = new List<ParkingSpot>();
        ParkingSpot ps = new ParkingSpot();

        if (TextBoxNameOfNewParking.Text.Equals("") || TextBoxLocationOfNewParking.Text.Equals("") || TextBoxNormalSpot.Text.Equals("") || TextBoxDimensionsOfParkingX.Text.Equals("") || TextBoxDimensionsOfParkingY.Text.Equals("") || TextBoxMotocyclesForRegularSpot.Text.Equals(""))
        {
            LabelError.Text = "Espacios vacíos";
        }
        else
        {
            pl.Name = TextBoxNameOfNewParking.Text;
            pl.Location = TextBoxLocationOfNewParking.Text;
            pl.Id = pb.AddParking(pl);
            if (pl.Id == -1)
            {
                LabelError.Text = "Parqueo ya existe";
            }
            else
            {
                

                for (int counter = 0; counter < Int32.Parse(TextBoxNormalSpot.Text); counter++)
                {
                    ps.SpotType = "Normal Spot";//Normal Spot
                    ps.IdParking = pl.Id;
                    //pb.AddParkingSpot(ps);
                    pl.ListOfSpots.Add(ps);
                }
                pl.Capacity = pl.ListOfSpots.Count;
                pb.UpdateParking(pl);
                FillTableDesignOfNewParking(pl.Id);

                TextBoxNormalSpot.Text = null;
                TextBoxNameOfNewParking.Text = null;
                TextBoxLocationOfNewParking.Text = null;
                TextBoxDimensionsOfParkingX.Text = null;
                TextBoxDimensionsOfParkingY.Text = null;
                TextBoxMotocyclesForRegularSpot.Text = null;

            }
        }
    }
    public void FillTableDesignOfNewParking(int id)
    {


        for (int counterRow = 0; counterRow < Int32.Parse(TextBoxDimensionsOfParkingY.Text); counterRow++)
        {
            TableRow tr = new TableRow();

            for (int counterColumn = 0; counterColumn < Int32.Parse(TextBoxDimensionsOfParkingX.Text); counterColumn++)
            {
                TableCell tc = new TableCell();
                tc.CssClass = "btn-error";

                Button btnStreet = new Button();
                btnStreet.UseSubmitBehavior = false;
                btnStreet.Click += new System.EventHandler(btnStreet_Click);
                btnStreet.Text = "";
                btnStreet.ID = ""+id;
                btnStreet.CommandArgument = counterColumn+","+counterRow;
                btnStreet.Attributes.Add("onclick", "return false");
                btnStreet.CssClass = "btn-success";

                Button btnReserve = new Button();
                btnReserve.UseSubmitBehavior = false;
                btnReserve.Click += new System.EventHandler(btnHandicap_Click);
                btnReserve.Text = "";
                btnReserve.ID = ""+id;
                btnReserve.CommandArgument = counterColumn + "," + counterRow;
                btnReserve.Attributes.Add("onclick", "return false");
                btnReserve.CssClass = "btn-primary";

                tc.Controls.Add(btnStreet);
                tc.Controls.Add(btnReserve);

                tr.Cells.Add(tc);
            }

            TableDesignOfNewParking.Rows.Add(tr);
        }
    }

    protected void btnStreet_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        string getColumnAndRow = btn.CommandArgument;
        TableDesignOfNewParking.Rows[getColumnAndRow[1]].Cells[getColumnAndRow[3]].Enabled = false;
        TableDesignOfNewParking.Rows[getColumnAndRow[1]].Cells[getColumnAndRow[3]].BackColor = Color.Gray;

        totalRoadToAdd++;
    }

    protected void btnHandicap_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string getColumnAndRow = btn.CommandArgument;
        TableDesignOfNewParking.Rows[getColumnAndRow[1]].Cells[getColumnAndRow[3]].Enabled = false;
        TableDesignOfNewParking.Rows[getColumnAndRow[1]].Cells[getColumnAndRow[3]].BackColor = Color.Gray;


    }
    
}
