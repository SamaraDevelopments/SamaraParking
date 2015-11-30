using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ParkingLotData
/// </summary>
public class ParkingLotData : BaseData
{
    public int Insert(ParkingLot newParkingLot)
    {
        int insertResult = 0;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Insert_Parkinglot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", newParkingLot.Name);
                sqlCommand.Parameters.AddWithValue("@location", newParkingLot.Location);
                sqlCommand.Parameters.AddWithValue("@capacity", newParkingLot.Capacity);

                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                ManageDatabaseConnection("Close");

                insertResult = 1;
            }
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }

        return insertResult;
    }

    public int Update(ParkingLot newParkingLot)
    {
        int insertResult = 0;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Update_ParkingLot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", newParkingLot.Id);
                sqlCommand.Parameters.AddWithValue("@name", newParkingLot.Name);
                sqlCommand.Parameters.AddWithValue("@location", newParkingLot.Location);
                sqlCommand.Parameters.AddWithValue("@capacity", newParkingLot.Capacity);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                ManageDatabaseConnection("Close");
            }
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }

        return insertResult;
    }

    public void Delete(ParkingLot newParkingLot)
    {
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");

        string databaseCommand = "delete_parkinglot";

        SqlCommand sqlCommand;

        try
        {

            sqlCommand = new SqlCommand(databaseCommand, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newParkingLot.Id;
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