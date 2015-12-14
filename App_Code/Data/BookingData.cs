using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

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

            using (SqlCommand sqlCommand = new SqlCommand("Insert_Booking", ManageDatabaseConnection("Open")))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IdUser", newBooking.IdUser.Id);
                sqlCommand.Parameters.AddWithValue("@IdVehicle", newBooking.IdVehicle.Id);
                sqlCommand.Parameters.AddWithValue("@IdParkingSpot", newBooking.IdParkingSpot.Id);
                sqlCommand.Parameters.AddWithValue("@IdParkingLot", newBooking.IdParkingLot.Id);
                sqlCommand.Parameters.AddWithValue("@EntryTime", newBooking.EntryTime);
                sqlCommand.Parameters.AddWithValue("@ExitTime", newBooking.ExitTime);
                sqlCommand.Parameters.AddWithValue("@CurrentDate", newBooking.Date);
                sqlCommand.ExecuteNonQuery();
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
    public DataTable GetReportBooking()
    {

        DataTable dataTable = new DataTable();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            SqlCommand sqlCommand = new SqlCommand("Get_Report_Booking", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        return dataTable;
    }
    public DataTable GetBookigsForSecurity(ParkingLot parkingLot,  DateTime initialHour)
    {
            DataTable dataTable = new DataTable();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            SqlCommand sqlCommand = new SqlCommand("Get_BookingsForSecurity", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlCommand.Parameters.AddWithValue("@IdParking", parkingLot.Id);
                sqlCommand.Parameters.AddWithValue("@InitialHour", initialHour);
                sqlDataAdapter.Fill(dataTable);
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        return dataTable;
    }
    public Table VerifyReserve(ParkingLot parkingTable, Table bookingTable, DateTime lowerLimit, DateTime upperLimit)
    {
        Booking bookingToVerify = new Booking();
        ParkingSpot parkingSpot = new ParkingSpot();
        parkingSpot.IdParking = parkingTable.Id;
        bookingToVerify.IdParkingLot = parkingTable;
        bookingToVerify.IdParkingSpot = parkingSpot;

        try
        {
            string statement = "SELECT * FROM Booking WHERE IdParking = @ParkingId";
            using (SqlCommand sqlCommand = new SqlCommand(statement, ManageDatabaseConnection("Open")))
            {
                sqlCommand.Parameters.AddWithValue("@ParkingId", bookingToVerify.IdParkingLot.Id);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookingToVerify.IdParkingSpot.Id = (int)reader["IdParkingSpot"];
                        bookingToVerify.EntryTime = (DateTime)reader["EntryTime"];
                        bookingToVerify.ExitTime = (DateTime)reader["ExitTime"];
                        if (bookingToVerify.EntryTime >= lowerLimit && bookingToVerify.EntryTime < upperLimit || bookingToVerify.ExitTime > lowerLimit && bookingToVerify.ExitTime <= upperLimit || bookingToVerify.EntryTime <= lowerLimit && bookingToVerify.ExitTime >= upperLimit)
                        {
                            string secondStatement = "SELECT * FROM ParkingLotSpots WHERE Id = @SpotId";
                            using (SqlCommand sqlCommandSecond = new SqlCommand(secondStatement, ManageDatabaseConnection("Open")))
                            {
                                sqlCommandSecond.Parameters.AddWithValue("@SpotId", bookingToVerify.IdParkingSpot.Id);
                                using (SqlDataReader secondReader = sqlCommandSecond.ExecuteReader())
                                {
                                    if (secondReader.Read())
                                    {
                                        bookingToVerify.IdParkingSpot.Position = (int)secondReader["Position"];
                                    }
                                }
                                int counter = 0;
                                for (int counterRow = 0; counterRow < parkingTable.DimensionX; counterRow++)
                                {
                                    for (int counterColumn = 0; counterColumn < parkingTable.DimensionY; counterColumn++)
                                    {
                                        if (bookingToVerify.IdParkingSpot.Position == counter)
                                        {
                                            bookingTable.Rows[counterRow].Cells[counterColumn].BackColor = Color.Red;
                                            bookingTable.Rows[counterRow].Cells[counterColumn].Enabled = false;
                                        }
                                        counter++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            string secondStatement = "SELECT * FROM ParkingLotSpots WHERE Id = @SpotId";
                            using (SqlCommand sqlCommandSecond = new SqlCommand(secondStatement, ManageDatabaseConnection("Open")))
                            {
                                sqlCommandSecond.Parameters.AddWithValue("@SpotId", bookingToVerify.IdParkingSpot.Id);
                                using (SqlDataReader secondReader = sqlCommandSecond.ExecuteReader())
                                {
                                    if (secondReader.Read())
                                    {
                                        bookingToVerify.IdParkingSpot.Position = (int)secondReader["Position"];
                                        bookingToVerify.IdParkingSpot.SpotType = secondReader["Spottype"].ToString().Trim();
                                    }
                                }
                                int counter = 0;
                                for (int counterRow = 0; counterRow < parkingTable.DimensionX; counterRow++)
                                {
                                    for (int counterColumn = 0; counterColumn < parkingTable.DimensionY; counterColumn++)
                                    {
                                        if (bookingToVerify.IdParkingSpot.Position == counter)
                                        {
                                            if (bookingTable.Rows[counterRow].Cells[counterColumn].BackColor == Color.Red)
                                            {
                                                switch (parkingSpot.SpotType)
                                                {
                                                    case "Normal Spot":
                                                        bookingTable.Rows[counterRow].Cells[counterColumn].Enabled = true;
                                                        bookingTable.Rows[counterRow].Cells[counterColumn].BackColor = Color.Transparent;
                                                        break;
                                                    case "Motorcycle Spot":
                                                        bookingTable.Rows[counterRow].Cells[counterColumn].Enabled = true;
                                                        bookingTable.Rows[counterRow].Cells[counterColumn].BackColor = Color.Transparent;
                                                        break;
                                                }

                                            }
                                        }
                                        counter++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        return bookingTable;
    }
}