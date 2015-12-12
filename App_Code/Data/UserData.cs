﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

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
                
                using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                {
                    if (sqlReader.Read())
                    {
                        receivedUser.Id = (int)sqlReader["Id"];
                        receivedUser.Name = sqlReader["Name"].ToString();
                        receivedUser.Lastname = sqlReader["Lastname"].ToString();
                        receivedUser.Password = sqlReader["Password"].ToString();
                        receivedUser.Email = sqlReader["Email"].ToString();
                        receivedUser.Roletype = (int)sqlReader["Roletype"];
                        receivedUser.Registry = (bool)sqlReader["Registry"];
                    }
                    sqlReader.Close();
                            
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

        try
        {

            using (SqlCommand sqlCommand = new SqlCommand("Update_User", ManageDatabaseConnection("Open")))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", newUser.Id);
                sqlCommand.Parameters.AddWithValue("@Name", newUser.Name);
                sqlCommand.Parameters.AddWithValue("@Lastname", newUser.Lastname);
                sqlCommand.Parameters.AddWithValue("@Roletype", newUser.Roletype);
                sqlCommand.Parameters.AddWithValue("@Registry", newUser.Registry);
                ManageDatabaseConnection("Close");
            }
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

        DataTable dataTable = new DataTable();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            SqlCommand sqlCommand = new SqlCommand("Active_Professor", connection);

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


    public DataTable GetActiveStudent()
    {

        DataTable dataTable = new DataTable();

        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            SqlCommand sqlCommand = new SqlCommand("Active_Student", connection);

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
    public void ChangeRegistry(User user)
    {
        try
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            SqlCommand sqlCommand = new SqlCommand("Active_Registry", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Email", user.Email);
            sqlCommand.Parameters.AddWithValue("@Registry", user.Registry);
            ManageDatabaseConnection("Close");
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
    }
    public MailMessage EmailForActivationRegistry(string emailOfUser) 
        {
        MailMessage mail = new MailMessage("maurisho01@gmail.com",emailOfUser);
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.EnableSsl = true;
        NetworkCredential networkCred = new NetworkCredential("maurisho01@gmail.com", "misho506");
        smtpClient.UseDefaultCredentials = true;
        smtpClient.Credentials = networkCred;
        smtpClient.Port = 587;
        smtpClient.Send(mail);

        return mail;
        }
}