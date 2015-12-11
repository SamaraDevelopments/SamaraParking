using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookingData
/// </summary>
public class BookingData : BaseData
{
    public void GetBooking(Booking newBooking)
    {
        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("get_booking", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;

            }

            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
    }

    public void Insert(Booking newBooking)
    {
        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Insert_Booking", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IdUser", newBooking.IdUser.Id);
                sqlCommand.Parameters.AddWithValue("@IdVehicle", newBooking.IdVehicle.Id);
                sqlCommand.Parameters.AddWithValue("@IdParkingSpot", newBooking.IdParkingSpot.Id);
                sqlCommand.Parameters.AddWithValue("@IdParkingLot", newBooking.IdParkingLot.Id);
                sqlCommand.Parameters.AddWithValue("@EntryTime", newBooking.EntryTime);
                sqlCommand.Parameters.AddWithValue("@ExitTime", newBooking.ExitTime);
                sqlCommand.Parameters.AddWithValue("@CurrentDate", newBooking.Date);
            }

            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
    }

    public void Update(Booking booking)
    {
        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("update_booking", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@idBooking", SqlDbType.Int).Value = booking.IdBooking;
                sqlCommand.Parameters.Add("@idPerson", SqlDbType.Int).Value = booking.IdUser.Id;
                sqlCommand.Parameters.Add("@idVehicle", SqlDbType.NVarChar).Value = booking.IdVehicle.Id;
                sqlCommand.Parameters.Add("@idParkingSpot", SqlDbType.Int).Value = booking.IdParkingSpot.Id;
                sqlCommand.Parameters.Add("@entryTime", SqlDbType.DateTime).Value = booking.EntryTime;
                sqlCommand.Parameters.Add("@entryTime", SqlDbType.DateTime).Value = booking.ExitTime;
                sqlCommand.Parameters.Add("@entryTime", SqlDbType.DateTime).Value = booking.Date;
            }

            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
    }

    public void Delete(Booking booking)
    {
        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("update_booking", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@idBooking", SqlDbType.Int).Value = booking.IdBooking;
                sqlCommand.ExecuteNonQuery();

            }

            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
    }
    public DataTable GetReportBooking()
    {

        DataTable dt = new DataTable();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            SqlCommand sqlCommand = new SqlCommand("Get_Report_Booking", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dt);
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        return dt;
    }
    public int[] GetUsersAndProfesors()
    {
        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Insert_Booking", connection))
            {

            }

            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
    }

}