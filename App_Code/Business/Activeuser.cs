using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ActiveUser
/// </summary>
public class ActiveUser
{
    public ActiveUser()
    {

    }
    public DataTable GetDataTableOfActiveProfessor()
    {
        UserData usd = new UserData();
        return usd.GetActiveProfessor();
    }
    public DataTable GetDataTableOfActivestudent()
    {
        UserData usd = new UserData();
        return usd.GetActiveStudent();
    }
}