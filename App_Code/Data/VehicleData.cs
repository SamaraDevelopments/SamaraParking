﻿using System;
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
        SqlConnection connection = ManageDatabaseConnection("Open");

        string databaseCommand = "Insert_Vehicle";

        SqlCommand sqlCommand;

        try
        {

            sqlCommand = new SqlCommand(databaseCommand, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserId", currentUser.Id);
            sqlCommand.Parameters.AddWithValue("@VehicleId", newVehicle.Id);
            sqlCommand.Parameters.AddWithValue("@Brand", newVehicle.Brand);
            sqlCommand.Parameters.AddWithValue("@Vehicletype", newVehicle.VehicleType);
            insertResult = Convert.ToInt32(sqlCommand.ExecuteScalar());
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }
        if (insertResult == 0)
        {
            currentUser.AddVehicle(newVehicle);
        }
        return insertResult;
    }

    public Vehicle LoadVehicle(User userToValidate)
    {
        Vehicle vehicleToAdd = new Vehicle();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Get_Vehicles", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", userToValidate.Id);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        receivedUser.Id = (int)reader["Id"];
                        receivedUser.Name = reader["Name"].ToString();
                        receivedUser.Lastname = reader["Lastname"].ToString();
                        receivedUser.Password = reader["Password"].ToString();
                        receivedUser.Email = reader["Email"].ToString();
                        receivedUser.Roletype = (int)reader["Roletype"];
                        receivedUser.Registry = (bool)reader["Registry"];
                    }

                }

            }

            ManageDatabaseConnection("Close");

        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }

        return receivedUser;
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