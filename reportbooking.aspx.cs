using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillTableReportBooking();
    }
    protected void FillTableReportBooking()
    {
       BookingBusiness bb = new BookingBusiness();
        DataTable bookingReportDataTable = bb.GetReportBooking();
        foreach (DataRow dr in bookingReportDataTable.Rows)
        {
            TableRow tr = new TableRow();

            foreach (DataColumn dc in bookingReportDataTable.Columns)
            {
                TableCell tc = new TableCell();
                tc.Text = string.Format(dr[dc.ColumnName].ToString());
                tr.Cells.Add(tc);
                TableReportBooking.Rows.Add(tr);
            }           
        }
    }
}