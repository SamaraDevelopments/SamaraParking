using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ResgistryBusiness
/// </summary>
public class RegistryBusiness
{
	public RegistryBusiness()
	{

	}
    public DataTable GetActiveProfessor() 
    {
        UserData ud = new UserData();
        return ud.GetActiveProfessor();
    }
    public DataTable GetActiveStudent()
    {
        UserData ud = new UserData();
        return ud.GetActiveStudent();
    }
    public void ActiveRegistry(User user)
    {
        UserData ud = new UserData();
        ud.Update(user);
    }
}