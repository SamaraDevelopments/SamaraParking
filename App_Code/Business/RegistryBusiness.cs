using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

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
        UserData userData = new UserData();
        return userData.GetActiveProfessor();
    }
    public DataTable GetActiveStudent()
    {
        UserData userData = new UserData();
        return userData.GetActiveStudent();
    }
    public void ActiveRegistry(User user)
    {
        UserData userData = new UserData();
        userData.Update(user);
    }
    public MailMessage EmailForActivationRegistry(string emailOfUSer)
    {
        UserData userData = new UserData();
        return userData.EmailForActivationRegistry(emailOfUSer);
    }
}