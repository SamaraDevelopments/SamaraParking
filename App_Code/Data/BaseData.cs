using System.Data.SqlClient;

/// <summary>
/// Summary description for BaseData
/// </summary>
public class BaseData
{
    //method to open or close the database connection
    public SqlConnection ManageDatabaseConnection(string actionToPerform)
    {
        string connectionString = "Data Source=ph0ibk90ya.database.windows.net;Initial Catalog=ParkingLot;Integrated Security=False;User ID=samara;Password=s4m4r4DEV;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        try
        {
            //desicion to whether open or close the database connection
            if (actionToPerform.Equals("Open"))
            {
                sqlConnection.Open();
            }
            else
            {
                sqlConnection.Close();
            }

        }
        catch (SqlException sqlException)
        {

            //throw the exception to upper layers
            throw sqlException;
        }

        return sqlConnection;

    }


}
