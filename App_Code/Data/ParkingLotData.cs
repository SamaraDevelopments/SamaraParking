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
        int insertResult = -1;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Insert_Parkinglot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", newParkingLot.Name);
                sqlCommand.Parameters.AddWithValue("@Location", newParkingLot.Location);
                sqlCommand.Parameters.AddWithValue("@Capacity", newParkingLot.Capacity);
                insertResult = Convert.ToInt32(sqlCommand.ExecuteScalar());
               
            }
            ManageDatabaseConnection("Close");
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
                sqlCommand.Parameters.AddWithValue("@Id", newParkingLot.Id);
                sqlCommand.Parameters.AddWithValue("@Name", newParkingLot.Name);
                sqlCommand.Parameters.AddWithValue("@Location", newParkingLot.Location);
                sqlCommand.Parameters.AddWithValue("@Capacity", newParkingLot.Capacity);
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