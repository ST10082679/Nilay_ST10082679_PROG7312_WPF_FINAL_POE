using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    internal static class DataProvider
    {
        // List to store the Report Issues
        public static List<ReportIssue> ReportIssues  = new List<ReportIssue>();
        //--------------------------------------------------------------------------------------//
        // Method to add the Report Issue to the List
        public static void AddReportIssue(ReportIssue reportIssue)
        {
            ReportIssues.Add(reportIssue);
            // Displays the message
            string message = "Report Added Successfully: \nLocation: " + reportIssue.Location + "\nCategory: " + reportIssue.CategorySelection + "\nDescription: " + reportIssue.Description + "\nImages/Docs: " + string.Join(", ", reportIssue.ImagesOrDocs);  
            MessageBox.Show(message);
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//