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
            FillTableDesignOfNewParking();
            TextBoxNameOfNewParking.Enabled = false;
            TextBoxLocationOfNewParking.Enabled = false;
            TextBoxDimensionsOfParkingX.Enabled = false;
            TextBoxDimensionsOfParkingY.Enabled = false;          
        }
        else
        {
            TextBoxNormalSpot.Enabled = false;
            TextBoxNameOfNewParking.Enabled = true;
            TextBoxLocationOfNewParking.Enabled = true;
            TextBoxDimensionsOfParkingX.Enabled = true;
            TextBoxDimensionsOfParkingY.Enabled = true;
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
        int validNameResult = 0;

        if (TextBoxNameOfNewParking.Text.Equals("") || TextBoxLocationOfNewParking.Text.Equals("") || TextBoxDimensionsOfParkingX.Text.Equals("") || TextBoxDimensionsOfParkingY.Text.Equals(""))
        {
            LabelError.Text = "Espacios vacíos";
        }
        else
        {
            pl.Name = TextBoxNameOfNewParking.Text;
            pl.Location = TextBoxLocationOfNewParking.Text;
            pl.DimensionX = Int32.Parse(TextBoxDimensionsOfParkingX.Text);
            pl.DimensionY = Int32.Parse(TextBoxDimensionsOfParkingY.Text);
            Session["PARKINGLOT"] = pl;
            validNameResult = pb.VerifyParking(pl);
            if (validNameResult == -1)
            {
                LabelError.Text = "Nombre del parqueo ya existe";
                TextBoxNormalSpot.Enabled = true;
                TextBoxNameOfNewParking.Enabled = true;
                TextBoxLocationOfNewParking.Enabled = true;
                TextBoxDimensionsOfParkingX.Enabled = true;
                TextBoxDimensionsOfParkingY.Enabled = true;
            }
            else
            {
                ButtonNext.Enabled = false;
                ButtonCancel.Enabled = false;
                TextBoxNormalSpot.Text = "" + pl.DimensionX * pl.DimensionY; 
                Session["AddParking"] = 1;
            }
        }
    }

    public void FillTableDesignOfNewParking()
    {
        if (TextBoxDimensionsOfParkingX.Text == string.Empty || TextBoxDimensionsOfParkingY.Text == string.Empty)
        {

        }
        else
        {
            for (int counterRow = 0; counterRow < Int32.Parse(TextBoxDimensionsOfParkingX.Text); counterRow++)
            {
                TableRow tr = new TableRow();
                for (int counterColumn = 0; counterColumn < Int32.Parse(TextBoxDimensionsOfParkingY.Text); counterColumn++)
                {
                    TableCell tc = new TableCell();
                    tc.CssClass = "btn-error";
                    tc.Controls.Add(addButton(counterColumn, counterRow));
                    tr.Cells.Add(tc);
                }
                TableDesignOfNewParking.Rows.Add(tr);
            }
        }
    }

    protected void btnStreet_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        string column = "";
        string row = "";
        string getColumnAndRow = btn.CommandArgument;
        char holder = getColumnAndRow [0];
        int counter = 1;
        while (!char.IsWhiteSpace(holder))
        {
            column += holder;
            holder = getColumnAndRow[counter];
            counter++;

        }
        while (counter < getColumnAndRow.Length)
        {
            holder = getColumnAndRow[counter];
            row += holder;
            counter++;
        }
        switch (TableDesignOfNewParking.Rows[Int32.Parse(row)].Cells[Int32.Parse(column)].BackColor.Name)
        {
            case "Transparent":
                TableDesignOfNewParking.Rows[Int32.Parse(row)].Cells[Int32.Parse(column)].BackColor = Color.DarkGray;
                TextBoxNormalSpot.Text = "" + (Int32.Parse(TextBoxNormalSpot.Text) - 1);
                break;
            case "DarkGray":
                TableDesignOfNewParking.Rows[Int32.Parse(row)].Cells[Int32.Parse(column)].BackColor = Color.Blue;
                break;
            case "Blue":
                TableDesignOfNewParking.Rows[Int32.Parse(row)].Cells[Int32.Parse(column)].BackColor = Color.Yellow;
                TextBoxNormalSpot.Text = "" + (Int32.Parse(TextBoxNormalSpot.Text) + 1);
                break;
            case "Yellow":
                TableDesignOfNewParking.Rows[Int32.Parse(row)].Cells[Int32.Parse(column)].BackColor = Color.Transparent;
                break;
            default:
                TableDesignOfNewParking.Rows[Int32.Parse(row)].Cells[Int32.Parse(column)].BackColor = Color.DarkGray;
                TextBoxNormalSpot.Text = "" + (Int32.Parse(TextBoxNormalSpot.Text) - 1);
                break;
        }
    }
    public Button addButton(int counterColumn, int counterRow)
    {
        Button btnStreet = new Button();
        btnStreet.Click += new System.EventHandler(btnStreet_Click);
        btnStreet.Text = "";
        btnStreet.ID = "" + (((counterRow + 1) * 100) + counterColumn + 1);
        btnStreet.CommandArgument = counterColumn + " " + counterRow;
        btnStreet.CssClass = "btn-link";
        return btnStreet;
    }


    protected void btnAddNewParking_Click(object sender, EventArgs e)
    {
        ParkingSpot ps = new ParkingSpot();
        ParkingBusiness pb = new ParkingBusiness();
        ParkingLot currentParking = (ParkingLot)Session["PARKINGLOT"];
        ps.IdParking = pb.AddParking(currentParking);
        currentParking.Id = ps.IdParking;
        if (ps.IdParking == -1)
        {
            LabelError.Text = "El nombre del parqueo ya existe";
        }
        else
        {
            pb.AddParkingSpot(TableDesignOfNewParking, currentParking);
        }
    }

    public void btnCancel_Click(object sender, EventArgs e)
    {
        
        TextBoxNormalSpot.Text = string.Empty;
        TextBoxNameOfNewParking.Text = string.Empty;
        TextBoxLocationOfNewParking.Text = string.Empty;
        TextBoxDimensionsOfParkingX.Text = string.Empty;
        TextBoxDimensionsOfParkingY.Text = string.Empty;
        TextBoxNameOfNewParking.Enabled = true;
        TextBoxLocationOfNewParking.Enabled = true;
        TextBoxDimensionsOfParkingX.Enabled = true;
        TextBoxDimensionsOfParkingY.Enabled = true;

    }
    public void ButtonCancelAddParking_Click(object sender, EventArgs e)
    {
        TableDesignOfNewParking.Rows.Clear();
        TextBoxNormalSpot.Text = string.Empty;
        TextBoxNameOfNewParking.Text = string.Empty;
        TextBoxLocationOfNewParking.Text = string.Empty;
        TextBoxDimensionsOfParkingX.Text = string.Empty;
        TextBoxDimensionsOfParkingY.Text = string.Empty;
        TextBoxNameOfNewParking.Enabled = true;
        TextBoxLocationOfNewParking.Enabled = true;
        TextBoxDimensionsOfParkingX.Enabled = true;
        TextBoxDimensionsOfParkingY.Enabled = true;
        Session["AddParking"] = 0;
        ButtonNext.Enabled = true;
        ButtonCancel.Enabled = true;
    }
}