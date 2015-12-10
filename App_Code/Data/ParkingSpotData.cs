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
        ParkingSpot ps = new ParkingSpot();
        ps.IdParking = currentParking.Id;
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
                                ps.SpotType = "Normal Spot";
                                ps.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= ps.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value =ps.IdParking;
                                sqlCommand.Parameters["@Position"].Value =ps.Position;
                                break;
                            case "DarkGray":
                                ps.SpotType = "Road Spot";
                                ps.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= ps.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value =ps.IdParking;
                                sqlCommand.Parameters["@Position"].Value =ps.Position;
                                break;
                            case "Blue":
                                ps.SpotType = "Handicap Spot";
                                ps.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= ps.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value =ps.IdParking;
                                sqlCommand.Parameters["@Position"].Value =ps.Position;
                                break;
                            case "Yellow":
                                ps.SpotType = "Motorcycle Spot";
                                ps.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= ps.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value =ps.IdParking;
                                sqlCommand.Parameters["@Position"].Value =ps.Position;
                                break;
                            default:
                                ps.SpotType = "Normal Spot";
                                ps.Position = counter;
                                sqlCommand.Parameters["@Spottype"].Value= ps.SpotType;
                                sqlCommand.Parameters["@IdParking"].Value =ps.IdParking;
                                sqlCommand.Parameters["@Position"].Value =ps.Position;
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

    public ParkingSpot GetSpot(ParkingSpot spotToRecieve, int selectedPosition)
    {
        
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Get_Spot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ParkingId", spotToRecieve.IdParking);
                sqlCommand.Parameters.AddWithValue("@Position", selectedPosition);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        spotToRecieve.Id = (int)reader["Id"];
                        spotToRecieve.SpotType = reader["Spottype"].ToString().Trim();
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