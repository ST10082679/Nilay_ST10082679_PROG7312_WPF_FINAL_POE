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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------------------//
        // Button to go to the Report Issues Page
        private void BtnReportIssues_Click(object sender, RoutedEventArgs e)
        {
            ReportIssues rep = new ReportIssues();
            rep.Show();
            this.Close();
        }
        //--------------------------------------------------------------------------------------//
        // Button to go to the Local Events and Announcements Page
        private void BtnLocalEventsAndAnnouncements_Click(object sender, RoutedEventArgs e)
        {
            LocalEvents local = new LocalEvents();
            local.Show();
            this.Close();
        }
        //--------------------------------------------------------------------------------------//
        // Button to go to the Service Request Status Page
        private void BtnServiceRequestStatus_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequestStatus service = new ServiceRequestStatus();
            service.Show();
            this.Close();
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//
