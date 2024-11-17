using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public partial class ReportIssues : Window
    {
        private ReportIssuesController controller;
        //--------------------------------------------------------------------------------------//
        // Constructor
        public ReportIssues()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            controller = new ReportIssuesController();
            lblCounter.Content = "Number of Reports: " + DataProvider.ReportIssues.Count.ToString();
        }
        //--------------------------------------------------------------------------------------//
        // Button to go back to the Main Menu
        private void BtnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
        //--------------------------------------------------------------------------------------//
        // Method to submit a report
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextRange textRange = new TextRange(RichTxtDescription.Document.ContentStart, RichTxtDescription.Document.ContentEnd);
                string description = textRange.Text.Trim();
                // Validate the report
                if (!controller.ValidateReport(description, TxtLocation.Text, ListBoxCategorySelection?.SelectedIndex ?? -1, out string errorText))
                {
                    MessageBox.Show(errorText, "Error Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
               
                ReportIssue reportIssue = new ReportIssue
                {
                    Location = TxtLocation.Text,
                    CategorySelection = (ListBoxCategorySelection.SelectedItem as ListBoxItem)?.Content?.ToString(),
                    Description = description,
                    ImagesOrDocs = new List<string>(controller.SelectedFiles)
                };
                // Add the report to the data provider
                DataProvider.AddReportIssue(reportIssue);
                ResetAll();
            }
            catch (Exception ex)
            {// Display the error message
                MessageBox.Show($"An error occurred while submitting the report: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Method to reset all the fields
        private void ResetAll()
        {
            lblCounter.Content = "Number of Reports: " + DataProvider.ReportIssues.Count.ToString();
            TxtLocation.Clear();
            controller.SelectedFiles.Clear();
            RichTxtDescription.Document.Blocks.Clear();
            ListBoxCategorySelection.SelectedIndex = -1;
            ListBoxCategorySelection.ClearValue(ItemsControl.ItemsSourceProperty);
            ProgressBar.Value = 0;
            LblEncourage.Content = "Help us improve. Let's get going";
            LblAttachments.Content = "No attachments selected";
        }
        //--------------------------------------------------------------------------------------//
        // Method to add media attachments
        private void BtnMediaAttachment_Click(object sender, RoutedEventArgs e)
        {
            try
            {// Open the file dialog
                OpenFileDialog openFileDialog = new OpenFileDialog
                {// Set the filter
                    Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Document Files (*.pdf;*.docx;*.txt)|*.pdf;*.docx;*.txt|All Files (*.*)|*.*",
                    FilterIndex = 1,
                    Multiselect = true
                };
                // Add the attachments
                if (openFileDialog.ShowDialog() == true)
                {
                    controller.AddAttachments(openFileDialog.FileNames);
                    LblAttachments.Content = "Attachments: " + controller.SelectedFiles.Count.ToString() + " files selected";
                }
                // Update the progress
                UpdateProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting files: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Updates progress
        private void TxtLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProgress();
        }
        //--------------------------------------------------------------------------------------//
        // Updates progress
        private void RichTxtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProgress();
        }
        //--------------------------------------------------------------------------------------//
        // Method that updates progress
        private void UpdateProgress()
        {
            TextRange textRange = new TextRange(RichTxtDescription.Document.ContentStart, RichTxtDescription.Document.ContentEnd);
            string description = textRange.Text.Trim();
            
            if (controller == null)
            {
                return;
            }
            // Calculate the progress
            controller.CalculateProgress(description, TxtLocation.Text, ListBoxCategorySelection?.SelectedIndex ?? -1);

            ProgressBar.Value = controller.Progress;
            // Encourage the user with messages
            if (controller.Progress == 0)
                LblEncourage.Content = "Help us improve. Let's get going";
            else if (controller.Progress == 25)
                LblEncourage.Content = "Great start. Keep going";
            else if (controller.Progress == 50)
                LblEncourage.Content = "Halfway there. Keep going";
            else if (controller.Progress == 75)
                LblEncourage.Content = "Almost there. Keep going";
            else if (controller.Progress == 100)
                LblEncourage.Content = "Well done. You are ready to submit";
        }
        //--------------------------------------------------------------------------------------//
        // Updates progress
        private void ListBoxCategorySelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProgress();
        }
        //--------------------------------------------------------------------------------------//
        // Button to view the list of reports
        private void BtnListOfReports_Click(object sender, RoutedEventArgs e)
        {
            ReportList rep = new ReportList();
            rep.Show();
            this.Close();
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//