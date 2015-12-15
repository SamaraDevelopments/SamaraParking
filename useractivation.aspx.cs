using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_UserActivation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }

        Session["EMAILALERT"] = "";
        User requestingUser = (User)Session["USER"];

        LabelSessionId.Text = requestingUser.Id.ToString();
        LabelSessionName.Text = requestingUser.Name;
        LabelSessionLastname.Text = requestingUser.Lastname;
        LabelSessionEmail.Text = requestingUser.Email;
        VehicleBusiness vb = new VehicleBusiness();
        FillTableUserVehicles();
        requestingUser.ListOfVehicles = vb.LoadListOfVehicles(requestingUser);

    }
    protected void TextBoxIdVehicle_TextChanged(object sender, EventArgs e)
    {
        TextBoxIdOfVehicle.Text = TextBoxIdOfVehicle.Text.ToUpper();
    }

    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {

        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        Vehicle vehicleToAdd = new Vehicle();

        vehicleToAdd.Id = TextBoxIdOfVehicle.Text;
        vehicleToAdd.Brand = TextBoxBrandOfVehicle.Text;

        if (CheckBoxIsMotrocycle.Checked)
        {
            vehicleToAdd.VehicleType = true;
        }
        else
        {
            vehicleToAdd.VehicleType = false;
        }
        if (vehicleToAdd.Id == "")
        {
            LabelError.Text = "Porfavor ingrese una marca";
        }
        else if (vehicleToAdd.Brand == "")
        {
            LabelError.Text = "Porfavor ingrese una placa";
        }
        else if (vb.ValidateLicensePlate(vehicleToAdd))
        {

            if (vb.AddVehicle(vehicleToAdd, currentUser) != null)
            {

                LabelError.Text = vb.AddVehicle(vehicleToAdd, currentUser);
            }
            else
            {
                Session["Vehicle"] = vehicleToAdd;
                currentUser.Registry = true;
                FillTableRequestRegistry();
            }
        }
        else
        {
            LabelError.Text = "El formato de placa esta equivocado";
        }
    }

    protected void btnCreateRegistry_Click(object sender, EventArgs e)
    {

        User currentUser = (User)Session["USER"];
        Vehicle vehicleToAdd = new Vehicle();
        RegistryBusiness registrybusiness = new RegistryBusiness();
        FillTableRequestRegistry();

        Session["Vehicle"] = vehicleToAdd;
        currentUser.Registry = true;
        registrybusiness.ActiveRegistry(currentUser);

    }


    protected void FillTableUserVehicles()
    {
        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        DataTable userVehiclesTable = vb.GetVehiclesFromUser(currentUser);

        foreach (DataRow dr in userVehiclesTable.Rows)
        {
            TableRow tr = new TableRow();
            int counterCells = 0;

            foreach (DataColumn dc in userVehiclesTable.Columns)
            {
                TableCell tc = new TableCell();
                if (counterCells == 3)
                {

                }
                else
                {
                    try
                    {
                        bool isMoto = (bool)dr[dc.ColumnName];
                        if (isMoto)
                        {
                            tc.Text = string.Format("M");
                        }
                        else
                        {
                            tc.Text = string.Format("VL");
                        }
                    }
                    catch (Exception)
                    {
                        tc.Text = string.Format(dr[dc.ColumnName].ToString());
                    }

                    tr.Cells.Add(tc);
                }

                counterCells++;
                TableRegisteredVehicles.Rows.Add(tr);

            }
        }
    }
    protected void FillTableRequestRegistry()
    {
        VehicleBusiness vb = new VehicleBusiness();
        User currentUser = (User)Session["USER"];
        DataTable userVehiclesTable = vb.GetVehiclesFromUser(currentUser);

        foreach (DataRow dr in userVehiclesTable.Rows)
        {
            TableRow tr = new TableRow();
            tr.ForeColor = System.Drawing.Color.Black;
            int counterCells = 0;

            foreach (DataColumn dc in userVehiclesTable.Columns)
            {
                TableCell tc = new TableCell();
                if (counterCells >= 2)
                {

                }
                else
                {
                    try
                    {
                        bool isMoto = (bool)dr[dc.ColumnName];
                        if (isMoto)
                        {
                            tc.Text = string.Format("M");
                        }
                        else
                        {
                            tc.Text = string.Format("VL");
                        }
                    }
                    catch (Exception)
                    {
                        tc.Text = string.Format(dr[dc.ColumnName].ToString());
                    }

                    tr.Cells.Add(tc);
                }

                counterCells++;
                TableRequestRegistry.Rows.Add(tr);

            }
        }
    }

    protected void btnRequestRegistry_Click(object sender, EventArgs e)
    {
        Session["EMAILALERT"] = SendMail();

    }

    protected string SendMail()
    {
        string status = "";
        User currentUser = (User)Session["USER"];
        RegistryBusiness registrybusiness = new RegistryBusiness();
        VehicleBusiness vb = new VehicleBusiness();
        DataTable userVehiclesTable = vb.GetVehiclesFromUser(currentUser);

        MailMessage mail = new MailMessage("latinatest@gmail.com", currentUser.Email);
        mail.Subject = "Activación de Marchamo";

        string htmlimg = "<img src=\"http://latinatest.azurewebsites.net/img/ulatinalogoverde.png\"/><br><br>";
        string messageBody = htmlimg;

        string htmlIntro = "ID: " + currentUser.Id + "<br>" + "Nombre: " + currentUser.Name + "<br>" +
        "Apellido(s): " + currentUser.Lastname + "<br>" + "<br><font>Vehiculos Registrados:</font><br><br>";  
        string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
        string htmlTableEnd = "</table>";
        string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
        string htmlHeaderRowEnd = "</tr>";
        string htmlTrStart = "<tr style =\"color:#555555;\">";
        string htmlTrEnd = "</tr>";
        string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
        string htmlTdEnd = "</td>";

        messageBody += htmlIntro;
        messageBody += htmlTableStart;
        messageBody += htmlHeaderRowStart;
        messageBody += htmlTdStart + "Placa" + htmlTdEnd;
        messageBody += htmlTdStart + "Marca" + htmlTdEnd;
        messageBody += htmlHeaderRowEnd;

        foreach (DataRow Row in userVehiclesTable.Rows)
        {
            int counterCells = 0;
            messageBody = messageBody + htmlTrStart;

            foreach (DataColumn dc in userVehiclesTable.Columns)
            {
                if (counterCells >= 2)
                {

                }
                else
                {
                    messageBody = messageBody + htmlTdStart + Row[dc.ColumnName].ToString().Trim() + htmlTdEnd;
                }
                counterCells++;

            }

            messageBody = messageBody + htmlTrEnd;
        }
        messageBody = messageBody + htmlTableEnd;

        mail.Body = messageBody;
        mail.IsBodyHtml = true;
        status = registrybusiness.EmailForActivationRegistry(currentUser.Email, mail);

        return status;
    }



}


