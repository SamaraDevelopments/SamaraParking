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
        if (IsPostBack)
        {
            FillTableDesignOfNewParking();
            TextBoxNormalSpot.Enabled = false;
            TextBoxNameOfNewParking.Enabled = false;
            TextBoxLocationOfNewParking.Enabled = false;
            TextBoxDimensionsOfParkingX.Enabled = false;
            TextBoxDimensionsOfParkingY.Enabled = false;
            TextBoxMotocyclesForRegularSpot.Enabled = false;
        }
        else
        {
            TextBoxNormalSpot.Enabled = true;
            TextBoxNameOfNewParking.Enabled = true;
            TextBoxLocationOfNewParking.Enabled = true;
            TextBoxDimensionsOfParkingX.Enabled = true;
            TextBoxDimensionsOfParkingY.Enabled = true;
            TextBoxMotocyclesForRegularSpot.Enabled = true;
        }
    }

    public void btnNext_Click(object sender, EventArgs e)
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
            }
        }
    }
    public void FillTableDesignOfNewParking()
    {
        for (int counterRow = 0; counterRow < Int32.Parse(TextBoxDimensionsOfParkingY.Text); counterRow++)
        {
            TableRow tr = new TableRow();
            for (int counterColumn = 0; counterColumn < Int32.Parse(TextBoxDimensionsOfParkingX.Text); counterColumn++)
            {
                TableCell tc = new TableCell();
                tc.CssClass = "btn-error";
                tc.Controls.Add(addButton(counterColumn, counterRow));
                tr.Cells.Add(tc);
            }
            TableDesignOfNewParking.Rows.Add(tr);
        }
    }

    protected void btnStreet_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        string getColumnAndRow = btn.CommandArgument;
        switch (TableDesignOfNewParking.Rows[(int)Char.GetNumericValue(getColumnAndRow[2])].Cells[(int)Char.GetNumericValue(getColumnAndRow[0])].BackColor.Name)
        {
            case "Transparent":
                TableDesignOfNewParking.Rows[(int)Char.GetNumericValue(getColumnAndRow[2])].Cells[(int)Char.GetNumericValue(getColumnAndRow[0])].BackColor = Color.DarkGray;
                break;
            case "DarkGray":
                TableDesignOfNewParking.Rows[(int)Char.GetNumericValue(getColumnAndRow[2])].Cells[(int)Char.GetNumericValue(getColumnAndRow[0])].BackColor = Color.Blue;
                break;
            case "Blue":
                TableDesignOfNewParking.Rows[(int)Char.GetNumericValue(getColumnAndRow[2])].Cells[(int)Char.GetNumericValue(getColumnAndRow[0])].BackColor = Color.Transparent;
                break;
            default:
                TableDesignOfNewParking.Rows[(int)Char.GetNumericValue(getColumnAndRow[2])].Cells[(int)Char.GetNumericValue(getColumnAndRow[0])].BackColor = Color.Gray;
                break;
        }
        totalRoadToAdd++;
    }
    public Button addButton(int counterColumn, int counterRow)
    {
        Button btnStreet = new Button();
        btnStreet.Click += new System.EventHandler(btnStreet_Click);
        btnStreet.Text = "";
        btnStreet.ID = "s" + (((counterRow+1)*100)+counterColumn+1);
        btnStreet.CommandArgument = counterColumn + "," + counterRow;
        btnStreet.CssClass = "btn-success";
        return btnStreet;
    }


    protected void btnAddNewParking_Click(object sender, EventArgs e)
    {

    }
}
