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
    public void Insert(ParkingSpot newSpot, int position)
    {
        int insertResult = 1;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Insert_Parkingspot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Spottype", newSpot.SpotType);
                sqlCommand.Parameters.AddWithValue("@IdParking", newSpot.IdParking);
                insertResult = Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            ManageDatabaseConnection("Close");

            using (SqlCommand sqlCommand = new SqlCommand("Update_ParkingSpotPosition", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Position", position);
                sqlCommand.Parameters.AddWithValue("@IdSpot", newSpot.Id);
                sqlCommand.Parameters.AddWithValue("@IdParking", newSpot.IdParking);
                insertResult = Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
    }

    public void Delete(ParkingSpot newSpot)
    {
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");

        string databaseCommand = "delete_parkinglotspot";

        SqlCommand sqlCommand;

        try
        {

            sqlCommand = new SqlCommand(databaseCommand, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newSpot.Id;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }


    }
}