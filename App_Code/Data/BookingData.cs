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
                sqlCommand.Dispose();

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

            using (SqlCommand sqlCommand = new SqlCommand("insert_booking", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@IdUser", SqlDbType.Int).Value = newBooking.IdUser.Id;
                sqlCommand.Parameters.Add("@IdVehicle", SqlDbType.NVarChar).Value = newBooking.IdVehicle.Id;
                sqlCommand.Parameters.Add("@IdParkingSpot", SqlDbType.Int).Value = newBooking.IdParkingSpot.Id;
                sqlCommand.Parameters.Add("@IdParkingLot", SqlDbType.Int).Value = newBooking.IdParkingLot.Id;
                sqlCommand.Parameters.Add("@EntryTime", SqlDbType.DateTime).Value = newBooking.EntryTime;
                sqlCommand.Parameters.Add("@ExitTime", SqlDbType.DateTime).Value = newBooking.ExitTime;
                sqlCommand.Parameters.Add("@CurrentDate", SqlDbType.DateTime).Value = newBooking.Date;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();

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
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();

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
                sqlCommand.Dispose();

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

}