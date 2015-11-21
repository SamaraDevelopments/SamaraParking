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
    private string lastName;
    private string username;
    private string password;
    private string email;
    private int roletype;
    private bool registry;
    private DateTime createdDate;
    private DateTime lastLogin;
    private List<Vehicle> listOfCars;

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
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public string Username
    {
        get { return username; }
        set { username = value; }
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
    
    
    
    
    public User()
    {

    }

    public List<Vehicle> AddVehicle(Vehicle vehicle)
    {
        ListOfCars.Add(vehicle);
        return ListOfCars;
    }
}
