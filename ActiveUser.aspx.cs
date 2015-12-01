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
        FillTableActiveProfessor();
        FillTableActiveStudent();
    }
    public void FillTableActiveProfessor()
    {
        RegistryBusiness rtb = new RegistryBusiness();
        DataTable dataTableProfessorActive = rtb.GetActiveProfessor();

        foreach (DataRow dr in dataTableProfessorActive.Rows)
        {
            TableRow tr = new TableRow();

            foreach (DataColumn dc in dataTableProfessorActive.Columns)
            {
                TableCell tc = new TableCell();
                tr.Cells.Add(tc);
                tc.Text = string.Format(dr[dc.ColumnName].ToString());           
                TableActiveProfessor.Rows.Add(tr);
            }
        }
    }
    public void FillTableActiveStudent()
    {
        RegistryBusiness rtb = new RegistryBusiness();
        DataTable dataTableStudentActive = rtb.GetActiveStudent();
        foreach (DataRow dr in dataTableStudentActive.Rows)
        {
            TableRow tr = new TableRow();

            foreach (DataColumn dc in dataTableStudentActive.Columns)
            {
                TableCell tc = new TableCell();
                tr.Cells.Add(tc);
                tc.Text = string.Format(dr[dc.ColumnName].ToString());
                TableActiveStudent.Rows.Add(tr);
            }
        }
    }
}