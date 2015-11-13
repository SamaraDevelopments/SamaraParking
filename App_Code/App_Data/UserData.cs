using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserData
/// </summary>
public class UserData : BaseData
{
    public void Insert(User newUser)
    {
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");

        string databaseCommand = "insert_person";

        SqlCommand sqlCommand;

        try
        {

            sqlCommand = new SqlCommand(databaseCommand, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = newUser.Name;
            sqlCommand.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = newUser.Lastname;
            sqlCommand.Parameters.Add("@roletype", SqlDbType.Int).Value = newUser.Roletype;
            sqlCommand.Parameters.Add("@registry", SqlDbType.Bit).Value = newUser.Registration;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }


    }
    public void Update(User newUser)
    {
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");

        string databaseCommand = "update_person";

        SqlCommand sqlCommand;

        try
        {

            sqlCommand = new SqlCommand(databaseCommand, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newUser.Id;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = newUser.Name;
            sqlCommand.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = newUser.Lastname;
            sqlCommand.Parameters.Add("@roletype", SqlDbType.Int).Value = newUser.Roletype;
            sqlCommand.Parameters.Add("@registry", SqlDbType.Bit).Value = newUser.Registration;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }


    }

    public void Delete(User newUser)
    {
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");

        string databaseCommand = "delete_person";

        SqlCommand sqlCommand;

        try
        {

            sqlCommand = new SqlCommand(databaseCommand, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newUser.Id;
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