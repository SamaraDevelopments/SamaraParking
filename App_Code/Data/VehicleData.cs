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
    public int Insert(Vehicle newVehicle, User currentUser)
    {
        int insertResult = 0;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Insert_Vehicle", ManageDatabaseConnection("Open")))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", currentUser.Id);
                sqlCommand.Parameters.AddWithValue("@VehicleId", newVehicle.Id);
                sqlCommand.Parameters.AddWithValue("@Brand", newVehicle.Brand);
                sqlCommand.Parameters.AddWithValue("@Vehicletype", newVehicle.VehicleType);
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

    public List<Vehicle> GetIdVehiclesFromUserVehicles(User user)
    {
        List<Vehicle> listOfVehicles = new List<Vehicle>();
        Vehicle vehicleToAdd = new Vehicle();
        
        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Get_Vehicles", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", user.Id);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            vehicleToAdd.Id = (int)reader["Vehicleid"];
                            listOfVehicles.Add(LoadVehicles(vehicleToAdd));

                        }
                        reader.NextResult();                             
                    }
                    reader.Close();
                }
            }

            ManageDatabaseConnection("Close");

        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }

        return listOfVehicles;
    }

    public Vehicle LoadVehicles(Vehicle vehicleToAdd)
    {
        Vehicle LoadedVehicle = new Vehicle();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Get_VehiclesFromUser", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@VehicleId", vehicleToAdd.Id);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        LoadedVehicle.Id = (int)reader["Id"];
                        LoadedVehicle.Brand = (string)reader["Brand"];
                        LoadedVehicle.VehicleType = (bool)reader["Vehicletype"];

                    }

                }

            }

            ManageDatabaseConnection("Close");

        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }

        return LoadedVehicle;
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