/*  Database Final Froject                            Group 3
 *  Names: Ian Carlos, Roshan Persaud, Vinay Thapar
 *  
 *  --------------Room Utilization Report--------------------
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomUtilizationReport
{
    public partial class frmRoomUtiliationReport : Form
    {
        public frmRoomUtiliationReport()
        {
            InitializeComponent();
        }
        //Data object declarations 
        //Dataset object 
        private MVCH_group3DataSet roomInvoicesDataSet; //Table Adapter Objects
        private MVCH_group3DataSetTableAdapters.tblAdmittanceTableAdapter admitanceTableAdapter;
        private MVCH_group3DataSetTableAdapters.tblPatientsTableAdapter patientTableAdapter;
        private MVCH_group3DataSetTableAdapters.tblRoomTableAdapter roomTableAdapter;

        private void frmRoomUtiliationReport_Load(object sender, EventArgs e)
        {
            //Declare a report object for use at runtime 
            RoonUtiliation aCustomerInvoicesReport;
            //Intantiate the report
            aCustomerInvoicesReport = new RoonUtiliation();
            try
            {
                //Instantiate the dataset and table adapters
                roomInvoicesDataSet = new MVCH_group3DataSet();
                admitanceTableAdapter = new MVCH_group3DataSetTableAdapters.tblAdmittanceTableAdapter();
                patientTableAdapter = new MVCH_group3DataSetTableAdapters.tblPatientsTableAdapter();
                roomTableAdapter = new MVCH_group3DataSetTableAdapters.tblRoomTableAdapter();
                //Fill the dataset using via the two table adapters 
                //Fill with customers
                admitanceTableAdapter.Fill(roomInvoicesDataSet.tblAdmittance);
                //Fill with invoices 
                patientTableAdapter.Fill(roomInvoicesDataSet.tblPatients);
                roomTableAdapter.Fill(roomInvoicesDataSet.tblRoom);
                //Assign the filled dataset as the datasource for the report 
                aCustomerInvoicesReport.SetDataSource(roomInvoicesDataSet);
                //Set up the report viewer object on the form to  
                //show the runtime report object
                crystalReportViewer1.ReportSource = aCustomerInvoicesReport;
            }
            catch (Exception dataException)
            {
                //Catch any exception thrown during data object instantiation 
                //or report generation and display based on the dataset
                MessageBox.Show("Data Error Encountered: " + dataException.Message);
            }
        }
    }
}


