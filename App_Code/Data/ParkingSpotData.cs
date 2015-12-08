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
        int insertResult = 1;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Insert_Parkingspot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Spottype", newSpot.SpotType);
                sqlCommand.Parameters.AddWithValue("@IdParking", newSpot.IdParking);
                sqlCommand.Parameters.AddWithValue("@Position", newSpot.Position);
                insertResult = Convert.ToInt32(sqlCommand.ExecuteScalar());
                sqlCommand.Dispose();
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
    }

    public int GetSpot(int selectedPosition, int parkingId)
    {
        int spotId = 0;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Get_Spot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ParkingId", parkingId);
                sqlCommand.Parameters.AddWithValue("@Position", selectedPosition);
                spotId = Convert.ToInt32(sqlCommand.ExecuteScalar());
                sqlCommand.Dispose();
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        return spotId;
    }
    public string GetSpotType(int spotId)
    {
        string spotType = "";
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Get_SpotType", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", spotId);
                spotType = Convert.ToString(sqlCommand.ExecuteScalar());
                sqlCommand.Dispose();
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        return spotType;
    }
}