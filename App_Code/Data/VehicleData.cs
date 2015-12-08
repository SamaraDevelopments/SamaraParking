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

    public DataTable GetVehiclesFromUser(User user)
    {

        DataTable dt = new DataTable();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Get_VehiclesFromUser", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", user.Id);

                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {

                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(dt);
                    
                }

            }

            ManageDatabaseConnection("Close");

        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }

        return dt;
    }

    public Vehicle LoadVehicles(Vehicle vehicleToAdd)
    {
        Vehicle LoadedVehicle = new Vehicle();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Get_Vehicle", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@VehicleId", vehicleToAdd.Id);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        LoadedVehicle.Id = reader["Id"].ToString();
                        LoadedVehicle.Brand = reader["Brand"].ToString();
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
    public int Edit(Vehicle editVehicle)
    {
        int editResult = 0;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Update_Vehicle", ManageDatabaseConnection("Open")))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@VehicleId", editVehicle.Id);
                sqlCommand.Parameters.AddWithValue("@Brand", editVehicle.Brand);
                sqlCommand.Parameters.AddWithValue("@Vehicletype", editVehicle.VehicleType);
                editResult = Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }

        return editResult;
    }
    public int Delete(Vehicle deleteVehicle, User currentUser)
    {
        int deleteResult = 0;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Delete_Vehicle", ManageDatabaseConnection("Open")))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", currentUser.Id);
                sqlCommand.Parameters.AddWithValue("@VehicleId", deleteVehicle.Id);
                deleteResult = Convert.ToInt32(sqlCommand.ExecuteScalar());
                sqlCommand.Dispose();
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }

        return deleteResult;
    }
    public DataSet GetVehiclesForBoking(User user)
    {
        DataSet ds = new DataSet();
        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Get_VehiclesForBooking", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
                SqlDataAdapter sqlda = new SqlDataAdapter(sqlCommand);
                sqlda.Fill(ds);  // fill dataset
                sqlCommand.Dispose();
            }

            ManageDatabaseConnection("Close");

        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }

        return ds;
    }

}