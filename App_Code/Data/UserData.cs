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
            sqlCommand.Parameters.Add("@registry", SqlDbType.Bit).Value = newUser.Registry;
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

        public DataTable GetActiveProfessor()
    {
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT Name, Lastname, Email FROM Users WHERE Registry=0 AND Roletype=2";
        DataTable dt = new DataTable();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand=command;

        try
        {
            /*dt.Columns.Add("Nombre");
            dt.Columns.Add("Last Name");
            dt.Columns.Add("Email");
            dt.Rows.Add*/
            dataAdapter.Fill(dt);
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
        //open database connection
        SqlConnection connection = ManageDatabaseConnection("Open");
        DataTable dt = new DataTable();
        try
        {
            
            dt.Columns.Add("Name");
            dt.Rows.Add("SELECT Name FROM Users WHERE Registry=1 AND Roletype=3");

            dt.Rows.Add("SELECT Lastname FROM Users WHERE Registry=1 AND Roletype=3");
            dt.Columns.Add("Lastname");

            dt.Columns.Add("Email");
            dt.Rows.Add("SELECT Email FROM Users WHERE Registry=1 AND Roletype=3");
            dt.AcceptChanges();

            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {

            throw sqlException;
        }

        return dt;

    }

    }