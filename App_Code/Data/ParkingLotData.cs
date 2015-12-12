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
                sqlCommand.Parameters.AddWithValue("@DimensionX", newParkingLot.DimensionX);
                sqlCommand.Parameters.AddWithValue("@DimensionY", newParkingLot.DimensionY);
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
    public int VerifyName(ParkingLot newParkingLot)
    {
        int insertResult = -1;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Verify_ParkingName", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", newParkingLot.Name);
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
                sqlCommand.ExecuteNonQuery();
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }

        return insertResult;
    }

    public int Delete(ParkingLot newParkingLot)
    {
        int insertResult = 0;
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Delete_ParkingLot", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", newParkingLot.Name);
                sqlCommand.ExecuteNonQuery();
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }

        return insertResult;
    }
    public DataSet GetParkingForBooking()
    {
        DataSet dataSet = new DataSet();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Get_Parking", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);  // fill dataset
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }
        return dataSet;
    }
    public ParkingLot GetParkingTable(ParkingLot parkingToTable)
    {

        try
        {
            using (SqlCommand sqlCommand = new SqlCommand("Get_ParkingDimension", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", parkingToTable.Id);
                using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                {
                    if (sqlReader.Read())
                    {
                        parkingToTable.DimensionX = (int)sqlReader["DimensionX"];
                        parkingToTable.DimensionY = (int)sqlReader["DimensionY"];
                    }
                } 
            }
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }

        return parkingToTable;
    }

}