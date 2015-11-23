using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{

    private int id;
    private string name;
    private string lastname;
    private string password;
    private string email;
    private int roletype;
    private bool registry;
    private DateTime createdDate;
    private DateTime lastLogin;
    private List<Vehicle> listOfVehicles;

    public User()
    {

    }
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Lastname
    {
        get { return lastname; }
        set { lastname = value; }
    }
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public int Roletype
    {
        get { return roletype; }
        set { roletype = value; }
    }
    public bool Registry
    {
        get { return registry; }
        set { registry = value; }
    }

    public List<Vehicle> ListOfVehicles
    {
        get
        {
            return listOfVehicles;
        }

        set
        {
            listOfVehicles = value;
        }
    }

}
