using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    /// <summary>
    /// Interaction logic for ReportList.xaml
    /// </summary>
    public partial class ReportList : Window
    { 
        public ReportList()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            // Display the data in the DataGrid
            DashboardDataGrid.ItemsSource = DataProvider.ReportIssues;
        }
        //--------------------------------------------------------------------------------------//
        // Button to go back to the Report Issues Page
        private void BtnBackToReportIssues_Click(object sender, RoutedEventArgs e)
        {
            ReportIssues rep = new ReportIssues();
            rep.Show();
            this.Close();
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//