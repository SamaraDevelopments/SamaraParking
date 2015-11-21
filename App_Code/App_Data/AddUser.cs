using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Object for user to be used in sessions and to insert into database
/// </summary>
public class AddUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Roletype { get; set; }
    public bool Registry { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastLogin { get; set; }

	public AddUser(int id, string name, string lastname, string username, string password, string email,
        int roletype, bool registry, DateTime createdDate, DateTime lastLogin)
	{
        Id = id;
        Name = name;
        LastName = lastname;
        Username = username;
        Password = password;
        Email = email;
        Roletype = roletype;
        Registry = registry;
        CreatedDate = createdDate;
        LastLogin = lastLogin;
	}
}