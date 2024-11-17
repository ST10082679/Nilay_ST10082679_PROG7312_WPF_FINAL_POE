using System.Collections.Generic;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class ReportIssuesController
    {
        public List<string> SelectedFiles { get; private set; }
        public int Progress { get; private set; }
        //--------------------------------------------------------------------------------------//
        // Constructor
        public ReportIssuesController()
        {
            SelectedFiles = new List<string>();
            Progress = 0;
        }
        //--------------------------------------------------------------------------------------//
        // Method to validate the report
        public bool ValidateReport(string description, string location, int selectedCategoryIndex, out string errorText)
        {
            errorText = "";
            bool hasErrors = false;

            if (string.IsNullOrEmpty(description) || description.Equals("\r\n"))
            {
                errorText += "Please enter a description\n";
                hasErrors = true;
            }

            if (string.IsNullOrEmpty(location))
            {
                errorText += "Please enter a location\n";
                hasErrors = true;
            }

            if (selectedCategoryIndex == -1)
            {
                errorText += "Please select a category\n";
                hasErrors = true;
            }

            if (SelectedFiles.Count == 0)
            {
                errorText += "Please add at least one attachment";
                hasErrors = true;
            }

            return !hasErrors;
        }
        //--------------------------------------------------------------------------------------//
        // Method to add attachments
        public void AddAttachments(IEnumerable<string> files)
        {
            SelectedFiles.AddRange(files);
        }
        //--------------------------------------------------------------------------------------//
        // Method to calculate the progress
        public void CalculateProgress(string description, string location, int selectedCategoryIndex)
        {
            Progress = 0;

            if (SelectedFiles.Count > 0)
            {
                Progress += 25;
            }

            if (!string.IsNullOrEmpty(description) && !description.Equals("\r\n"))
            {
                Progress += 25;
            }

            if (!string.IsNullOrEmpty(location))
            {
                Progress += 25;
            }

            if (selectedCategoryIndex != -1)
            {
                Progress += 25;
            }
        }       
    }
}
//---------------------------------End of FIle-----------------------------------------------------//