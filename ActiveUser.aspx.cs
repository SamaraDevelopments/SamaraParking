using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_activeUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public DataTable GetProfessor() {
        UserData usd = new UserData();
    return usd.GetActiveProfessor();
    }
    public DataTable GetStudent()
    {
        UserData usd = new UserData();
        return usd.GetActiveStudent();
    }
}