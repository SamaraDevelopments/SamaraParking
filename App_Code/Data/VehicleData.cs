using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VehibleData
/// </summary>

public class VehicleData : BaseData
{
    public void Insert(Vehicle newVehicle)
    {
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");

        string databaseCommand = "insert_vehicle";

        SqlCommand sqlCommand;

        try
        {

            sqlCommand = new SqlCommand(databaseCommand, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = newVehicle.Brand;
            sqlCommand.Parameters.Add("@location", SqlDbType.NVarChar).Value = newVehicle.VehicleType;

            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }


    }

    public void Update(Vehicle newVehicle)
    {
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");

        string databaseCommand = "update_vehicle";

        SqlCommand sqlCommand;

        try
        {

            sqlCommand = new SqlCommand(databaseCommand, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newVehicle.Id;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = newVehicle.Brand;
            sqlCommand.Parameters.Add("@location", SqlDbType.NVarChar).Value = newVehicle.VehicleType;

            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }


    }

    public void Delete(Vehicle newVehicle)
    {
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");

        string databaseCommand = "delete_vehicle";

        SqlCommand sqlCommand;

        try
        {

            sqlCommand = new SqlCommand(databaseCommand, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newVehicle.Id;
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