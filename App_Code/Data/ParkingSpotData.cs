using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

/// <summary>
/// Summary description for ParkingSpotData
/// </summary>
public class ParkingSpotData : BaseData
{
    public void Insert(Table parkingToAddSpots, ParkingLot currentParking)
    {
        ParkingSpot parkingSpot = new ParkingSpot();
        parkingSpot.IdParking = currentParking.Id;
        try
        {
            string statement = "INSERT INTO dbo.ParkingLotSpots(ParkingId, Spottype, Position) VALUES(@IdParking, @Spottype, @Position)";
            SqlCommand sqlCommand = new SqlCommand(statement, ManageDatabaseConnection("Open"));
            {
                int counter = 0;
                sqlCommand.Parameters.Add("@Spottype", SqlDbType.NChar, 25);
                sqlCommand.Parameters.Add("@IdParking", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Position", SqlDbType.Int);
                for (int counterRow = 0; counterRow < currentParking.DimensionY; counterRow++)
                {
                    for (int counterColumn = 0; counterColumn < currentParking.DimensionY; counterColumn++)
                    {
                        switch (parkingToAddSpots.Rows[counterRow].Cells[counterColumn].BackColor.Name)
                        {
                            case "Transparent":
                                parkingSpot.SpotType = "Normal Spot";
                                parkingSpot.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= parkingSpot.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value = parkingSpot.IdParking;
                                sqlCommand.Parameters["@Position"].Value = parkingSpot.Position;
                                break;
                            case "DarkGray":
                                parkingSpot.SpotType = "Road Spot";
                                parkingSpot.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= parkingSpot.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value = parkingSpot.IdParking;
                                sqlCommand.Parameters["@Position"].Value = parkingSpot.Position;
                                break;
                            case "Blue":
                                parkingSpot.SpotType = "Handicap Spot";
                                parkingSpot.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= parkingSpot.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value = parkingSpot.IdParking;
                                sqlCommand.Parameters["@Position"].Value = parkingSpot.Position;
                                break;
                            case "Yellow":
                                parkingSpot.SpotType = "Motorcycle Spot";
                                parkingSpot.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= parkingSpot.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value = parkingSpot.IdParking;
                                sqlCommand.Parameters["@Position"].Value = parkingSpot.Position;
                                break;
                            default:
                                parkingSpot.SpotType = "Normal Spot";
                                parkingSpot.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= parkingSpot.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value = parkingSpot.IdParking;
                                sqlCommand.Parameters["@Position"].Value = parkingSpot.Position;
                                break;
                        }
                        counter++;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
    }

    public Table GetSpot(ParkingLot parkingTable, Table bookingTable)
    {
        ParkingSpot parkingSpot = new ParkingSpot();
        parkingSpot.IdParking = parkingTable.Id;
        try
        {
            string statement = "SELECT Id, Spottype FROM ParkingLotSpots WHERE ParkingId = @ParkingId AND Position = @Position";
            using (SqlCommand sqlCommand = new SqlCommand(statement, ManageDatabaseConnection("Open")))
            {
                sqlCommand.Parameters.AddWithValue("@ParkingId", parkingSpot.IdParking);
                sqlCommand.Parameters.Add("@Position", SqlDbType.Int);
                int counter = 0;
                for (int counterRow = 0; counterRow < parkingTable.DimensionX; counterRow++)
                 {
                    TableRow tableRow = new TableRow();
                    for (int counterColumn = 0; counterColumn < parkingTable.DimensionY; counterColumn++)
                       {
                       TableCell tableCell = new TableCell();
                        tableCell.CssClass = "btn-error";
                        parkingSpot.Position = counter;
                       sqlCommand.Parameters["@Position"].Value = parkingSpot.Position;
                       sqlCommand.ExecuteNonQuery();
                       using (SqlDataReader reader = sqlCommand.ExecuteReader())
                       {
                           if (reader.Read())
                           {
                                parkingSpot.Id = (int)reader["Id"];
                                parkingSpot.SpotType = reader["Spottype"].ToString().Trim();
                           }
                       }
                         switch (parkingSpot.SpotType)
                         {
                             case "Normal Spot":
                                tableCell.BackColor = Color.Transparent;
                                 break;
                             case "Road Spot":
                                tableCell.BackColor = Color.DarkGray;
                                tableCell.Enabled = false;
                                  break;
                             case "Handicap Spot":
                                tableCell.BackColor = Color.Blue;
                                tableCell.Enabled = false;
                                 break;
                             case "Motorcycle Spot":
                                tableCell.BackColor = Color.Yellow;
                                 break;
                                  }
                        tableRow.Cells.Add(tableCell);
                          counter++;
                        }
                     bookingTable.Rows.Add(tableRow);
                  }
                
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        return bookingTable;
    }
    public ParkingSpot GetSpotForReserve(ParkingSpot spotToRecieve, int selectedPosition)
    {

        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Get_Spot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ParkingId", spotToRecieve.IdParking);
                sqlCommand.Parameters.AddWithValue("@Position", selectedPosition);
                using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                {
                    if (sqlReader.Read())
                    {
                        spotToRecieve.Id = (int)sqlReader["Id"];
                        spotToRecieve.SpotType = sqlReader["Spottype"].ToString().Trim();
                    }
                }
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        return spotToRecieve;
    }
}