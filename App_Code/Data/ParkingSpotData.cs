using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ParkingSpotData
/// </summary>
public class ParkingSpotData : BaseData
{
    public void Insert(ParkingSpot newSpot)
    {
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Insert_Parkingspot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Spottype", newSpot.SpotType);
                sqlCommand.Parameters.AddWithValue("@IdParking", newSpot.IdParking);
                sqlCommand.Parameters.AddWithValue("@Position", newSpot.Position);
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