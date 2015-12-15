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

    public string EmailForActivationRegistry(string emailOfUser, MailMessage mail)
    {

        string status = "";
        
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.EnableSsl = true;
        smtpClient.Port = 587;
        smtpClient.UseDefaultCredentials = true;
        NetworkCredential networkCred = new NetworkCredential("latinatest@gmail.com", "ULatina506");
        smtpClient.Credentials = networkCred;

        try
        {
            smtpClient.Send(mail);
            status = "Enviado";
        }
        catch
        {
            status = "No Enviado";

        }

        return status;
    }

}