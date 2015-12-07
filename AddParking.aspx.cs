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
    ParkingLot pl = new ParkingLot();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (IsPostBack)
        {
            
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
            Session["AddParking"] = 0;
            ButtonNext.Enabled = true;
            ButtonCancel.Enabled = true;
        }
    }

    public void btnNext_Click(object sender, EventArgs e)
    {
        ParkingBusiness pb = new ParkingBusiness();
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
            pl.DimensionX = Int32.Parse(TextBoxDimensionsOfParkingX.Text);
            pl.DimensionY = Int32.Parse(TextBoxDimensionsOfParkingY.Text);
            pl.Id = pb.AddParking(pl);
            Session["ParkingId"] = pl.Id;
            if (pl.Id == -1)
            {
                LabelError.Text = "Nombre del parqueo ya existe";
                TextBoxNormalSpot.Enabled = true;
                TextBoxNameOfNewParking.Enabled = true;
                TextBoxLocationOfNewParking.Enabled = true;
                TextBoxDimensionsOfParkingX.Enabled = true;
                TextBoxDimensionsOfParkingY.Enabled = true;
                TextBoxMotocyclesForRegularSpot.Enabled = true;
            }
            else
            {
                ButtonNext.CssClass = "btn btn-default";
                ButtonNext.Enabled = false;
                ButtonCancel.CssClass = "btn btn-default";
                ButtonCancel.Enabled = false;
                Session["AddParking"] = 1;
                FillTableDesignOfNewParking();
            }
        }
    }

    public void FillTableDesignOfNewParking()
    {
        for (int counterRow = 0; counterRow < Int32.Parse(TextBoxDimensionsOfParkingX.Text); counterRow++)
        {
            TableRow tr = new TableRow();
            for (int counterColumn = 0; counterColumn < Int32.Parse(TextBoxDimensionsOfParkingY.Text); counterColumn++)
            {
                TableCell tc = new TableCell();
                tc.CssClass = "btn-default";
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
                TableDesignOfNewParking.Rows[(int)Char.GetNumericValue(getColumnAndRow[2])].Cells[(int)Char.GetNumericValue(getColumnAndRow[0])].BackColor = Color.DarkGray;
                break;
        }
    }
    public Button addButton(int counterColumn, int counterRow)
    {
        Button btnStreet = new Button();
        btnStreet.Click += new System.EventHandler(btnStreet_Click);
        btnStreet.Text = "";
        btnStreet.ID = "" + (((counterRow + 1) * 100) + counterColumn + 1);
        btnStreet.CommandArgument = counterColumn + "," + counterRow;
        btnStreet.CssClass = "btn-success";
        return btnStreet;
    }


    protected void btnAddNewParking_Click(object sender, EventArgs e)
    {
        ParkingSpot ps = new ParkingSpot();
        ps.IdParking = (int)Session["ParkingId"];
        ParkingBusiness pb = new ParkingBusiness();
        int counter = 0;
        for (int counterRow = 0; counterRow < Int32.Parse(TextBoxDimensionsOfParkingY.Text); counterRow++)
        {

            for (int counterColumn = 0; counterColumn < Int32.Parse(TextBoxDimensionsOfParkingX.Text); counterColumn++)
            {
                switch (TableDesignOfNewParking.Rows[counterRow].Cells[counterColumn].BackColor.Name)
                {
                    case "Transparent":
                        ps.SpotType = "Normal Spot";
                        pb.AddParkingSpot(ps);
                        ps.Position = counter;
                        pb.UpdateParkingSpot(ps);
                        break;
                    case "DarkGray":
                        ps.SpotType = "Road Spot";
                        pb.AddParkingSpot(ps);
                        ps.Position = counter;
                        pb.UpdateParkingSpot(ps);
                        break;
                    case "Blue":
                        ps.SpotType = "Handicap Spot";
                        pb.AddParkingSpot(ps);
                        ps.Position = counter;
                        pb.UpdateParkingSpot(ps);
                        break;
                    default:
                        ps.SpotType = "Normal Spot";
                        pb.AddParkingSpot(ps);
                        ps.Position = counter;
                        pb.UpdateParkingSpot(ps);
                        break;
                }
                counter++;
            }
        }
    }

    public void btnCancel_Click(object sender, EventArgs e)
    {
        TextBoxNormalSpot.Text = string.Empty;
        TextBoxNameOfNewParking.Text = string.Empty;
        TextBoxLocationOfNewParking.Text = string.Empty;
        TextBoxDimensionsOfParkingX.Text = string.Empty;
        TextBoxDimensionsOfParkingY.Text = string.Empty;
        TextBoxMotocyclesForRegularSpot.Text = string.Empty;
        TextBoxNormalSpot.Enabled = true;
        TextBoxNameOfNewParking.Enabled = true;
        TextBoxLocationOfNewParking.Enabled = true;
        TextBoxDimensionsOfParkingX.Enabled = true;
        TextBoxDimensionsOfParkingY.Enabled = true;
        TextBoxMotocyclesForRegularSpot.Enabled = true;

    }
    public void ButtonCancelAddParking_Click(object sender, EventArgs e)
    {
        TextBoxNormalSpot.Text = string.Empty;
        TextBoxNameOfNewParking.Text = string.Empty;
        TextBoxLocationOfNewParking.Text = string.Empty;
        TextBoxDimensionsOfParkingX.Text = string.Empty;
        TextBoxDimensionsOfParkingY.Text = string.Empty;
        TextBoxMotocyclesForRegularSpot.Text = string.Empty;
        TextBoxNormalSpot.Enabled = true;
        TextBoxNameOfNewParking.Enabled = true;
        TextBoxLocationOfNewParking.Enabled = true;
        TextBoxDimensionsOfParkingX.Enabled = true;
        TextBoxDimensionsOfParkingY.Enabled = true;
        TextBoxMotocyclesForRegularSpot.Enabled = true;
        Session["AddParking"] = 0;
        ButtonNext.CssClass = "btn-primary";
        ButtonCancel.CssClass = "btn-danger";
        ButtonNext.Enabled = true;
        ButtonCancel.Enabled = true;
    }
}