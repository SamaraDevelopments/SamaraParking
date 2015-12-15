using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_RerportActiveUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        FillDropDownListYearReport();
        ReportBusiness rb = new ReportBusiness();
        Session["REPORTLIST"] = rb.getUsersAndProfesors(2015);
    }

    protected void UpdateParking_SelectedIndexChange(object sender, EventArgs e)
    {
        ReportBusiness rb = new ReportBusiness();
        Session["REPORTLIST"] = rb.getUsersAndProfesors(Int32.Parse(DropDownListYearReport.SelectedValue));
    }

    public void FillDropDownListYearReport()
    {
        string year = "";

        for (int i = 1; i <= 50; i++)
        {
            if (i.ToString().Length <= 2)
            {
                year = "20" + i.ToString();
            }
            else
            {
                year = "200" + i.ToString();
            }
            DropDownListYearReport.Items.Add(year);
        }
    }
}
