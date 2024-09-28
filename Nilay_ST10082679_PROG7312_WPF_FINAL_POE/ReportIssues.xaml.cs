using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    /// Interaction logic for ReportIssues.xaml
    /// </summary>
    public partial class ReportIssues : Window
    {
        //List to store the selected files
        public List<string> selectedFiles = new List<string>();
        //--------------------------------------------------------------------------------------//
        public ReportIssues()
        {
            InitializeComponent();
            lblCounter.Content = "Number of Reports: " + DataProvider.ReportIssues.Count.ToString();
        }
        //--------------------------------------------------------------------------------------//
        //Back to main menu button
        private void BtnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
        //--------------------------------------------------------------------------------------//
        // Method that checks if the report has any errors
        private bool ReportHasErrors() {
            string errorText = "";
            bool hasErrors = false;
            // this gets the text from the rich text box
            TextRange textRange = new TextRange(RichTxtDescription.Document.ContentStart, RichTxtDescription.Document.ContentEnd);

            // Retrieve the text from the TextRange
            string rtfText = textRange.Text.Trim();

            //Checks if the description is null or empty    
            if (string.IsNullOrEmpty(rtfText) || rtfText.Equals("\r\n"))
            {
                errorText += "Please enter a description\n";
                hasErrors = true;
            }
            //Checks if the location is null or empty 
            if (string.IsNullOrEmpty(TxtLocation.Text))
            {
                errorText += "Please enter a location\n";
                hasErrors = true;
            }
            //Checks if the category is selected
            if (ListBoxCategorySelection.SelectedIndex == -1)
            {
                errorText += "Please select a category\n";
                hasErrors = true;
            }
            //Checks if theres any attackments, the user needs to at least add one attachment
            if (selectedFiles.Count == 0)
            {
                errorText += "Please add at least one attachment";
                hasErrors = true;
            }
            // if there are any errors, theres a message box that will display the errors
            if (hasErrors)
            {
                MessageBox.Show(errorText, "Error Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return hasErrors;
        }
        //--------------------------------------------------------------------------------------//
        // Submit button to sumbit the report issue
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // this gets the text from the rich text box
            TextRange textRange = new TextRange(RichTxtDescription.Document.ContentStart, RichTxtDescription.Document.ContentEnd);

            // Retrieve the text from the TextRange
            string rtfText = textRange.Text.Trim(); 
            
            bool isReportValid = ReportHasErrors();
            if (isReportValid)
            {
                return;
            }
            //Creating a new report issue object
            ReportIssue reportIssue = new ReportIssue
            {
                // Assigns the values to the properties
                Location = TxtLocation.Text,
                CategorySelection = (ListBoxCategorySelection.SelectedItem as ListBoxItem).Content.ToString(),
                Description = rtfText,
                ImagesOrDocs = new List<string>(selectedFiles)
            };
            DataProvider.AddReportIssue(reportIssue);
            ResetAll();
        }
        //--------------------------------------------------------------------------------------//
        // Method that resets all the fields    
        private void ResetAll()
        {
            lblCounter.Content = "Number of Reports: " + DataProvider.ReportIssues.Count.ToString();
            TxtLocation.Clear();
            selectedFiles.Clear();
            RichTxtDescription.Document.Blocks.Clear();
            ListBoxCategorySelection.SelectedIndex = -1;
            ListBoxCategorySelection.ClearValue(ItemsControl.ItemsSourceProperty);
            ProgressBar.Value = 0;
            LblEncourage.Content = "Help us improve. Lets get going";
            LblAttachments.Content = "No attachments selected";
        }
        //--------------------------------------------------------------------------------------//
        // Method that allows the user to add attachments
        private void BtnMediaAttachment_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Allow multiple file types images and documents
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|"
                                  + "Document Files (*.pdf;*.docx;*.txt)|*.pdf;*.docx;*.txt|"
                                  + "All Files (*.*)|*.*";

            openFileDialog.FilterIndex = 1; // Default to showing images first
            openFileDialog.Multiselect = true; // Enables multi-selection of files

            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected files' paths
                foreach (var item in openFileDialog.FileNames)
                {
                    selectedFiles.Add(item);
                };
               // Display the number of selected files
               LblAttachments.Content = "Attachments: " + selectedFiles.Count.ToString() + " files selected";
            }
            CalculateProgress();
        }
        //--------------------------------------------------------------------------------------//
        // Button that that takes the user to the list of reports
        private void BtnListOfReports_Click(object sender, RoutedEventArgs e)
        {
            ReportList rep = new ReportList();
            rep.Show();
            this.Close();
        }
        //--------------------------------------------------------------------------------------//
        private void TxtLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateProgress();      
        }
        //--------------------------------------------------------------------------------------//
        private void RichTxtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateProgress();
        }
        //--------------------------------------------------------------------------------------//
        // Method that calculates the progress of the report
        private void CalculateProgress()
        {
            int progress = 0;
            if (selectedFiles.Count > 0)
            {
                progress += 25;
            }
            // testing 
            TextRange textRange = new TextRange(RichTxtDescription.Document.ContentStart, RichTxtDescription.Document.ContentEnd);

            // Retrieve the text from the TextRange
            string rtfText = textRange.Text.Trim();
            // if the description is not null or empty, the progress will increase by 25
            if (!string.IsNullOrEmpty(rtfText) && !rtfText.Equals("\r\n"))
            {
                progress += 25;
            }
            // if the location is not null or empty, the progress will increase by 25
            if (!string.IsNullOrEmpty(TxtLocation.Text))
            {
                progress += 25;
            }
            // if the category is selected, the progress will increase by 25
            if (ListBoxCategorySelection != null && ListBoxCategorySelection.SelectedIndex != -1)
            {
              progress += 25;
            }
            // the progress bar will be updated based on the progress
            if (ProgressBar != null)
            {
                ProgressBar.Value = progress;
            }

            // Encouraging message label will be updated based on the progress
            if (LblEncourage != null)
            {
                if (progress == 0)
                {
                    LblEncourage.Content = "Help us improve. Lets get going";
                }
                else if (progress == 25)
                {
                    LblEncourage.Content = "Great start. Keep going";
                }
                else if (progress == 50)
                {
                    LblEncourage.Content = "Halfway there. Keep going";
                }
                else if (progress == 75)
                {
                    LblEncourage.Content = "Almost there. Keep going";
                }
                else if (progress == 100)
                {
                    LblEncourage.Content = "Well done. You are ready to submit";
                }
            }
        }
        //--------------------------------------------------------------------------------------//
        private void ListBoxCategorySelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateProgress();
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//