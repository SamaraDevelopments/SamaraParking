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

    public int ValidateUser(User userToValidate)
    {
        int verificationType = 0;

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Validate_User", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@email", userToValidate.Email);
                sqlCommand.Parameters.AddWithValue("@password", userToValidate.Password);
                verificationType = Convert.ToInt32(sqlCommand.ExecuteScalar());
                
            }
            ManageDatabaseConnection("Close");

        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }

        return verificationType;
    }

    public User GetUser(User userToValidate)
    {
        User receivedUser = new User();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            using (SqlCommand sqlCommand = new SqlCommand("Get_User", connection))
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@email", userToValidate.Email);
                
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
                    reader.Close();
                            
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
            sqlCommand.Parameters.Add("@registry", SqlDbType.Bit).Value = newUser.Registry;
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
            sqlCommand.Parameters.Add("@registry", SqlDbType.Bit).Value = newUser.Registry;
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
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }
    }

    public DataTable GetActiveProfessor()
    {

        DataTable dt = new DataTable();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            SqlCommand sqlCommand = new SqlCommand("Active_Professor", connection);

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


    public DataTable GetActiveStudent()
    {

        DataTable dt = new DataTable();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            SqlCommand sqlCommand = new SqlCommand("Active_Student", connection);

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