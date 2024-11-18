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
    /// Interaction logic for ServiceRequestStatus.xaml
    /// </summary>
    public partial class ServiceRequestStatus : Window
    {
        public ServiceRequestStatusController controller;

        //--------------------------------------------------------------------------------------//
        // Constructor
        public ServiceRequestStatus()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            controller = new ServiceRequestStatusController();
            PopulateStatusComboBox();
            DisplayServiceRequestsAVL();   
        }
        //--------------------------------------------------------------------------------------//
        // Method to display all service requests
        public void DisplayServiceRequestsAVL()
        {
            // Clear the stack panel
            stackPanelServiceRequests.Children.Clear();
            controller.HandleNormalViewRequests(DisplayStackPanelForRequest);
        }
        //--------------------------------------------------------------------------------------//
        // Button to search for a service request
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {// Check if the search text box is empty
                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Please enter a valid or partial UUID to search for.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                // Clear the stack panel
                stackPanelServiceRequests.Children.Clear();
                controller.HandleSearchViewRequests(DisplayStackPanelForRequest, txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when searching for service requests. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Method to display a service request in a StackPanel
        public void DisplayStackPanelForRequest(ServiceRequest request)
        {
            Border eventBorder = new Border
            {
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(10),
                Margin = new Thickness(0, 10, 0, 0),
                Background = Brushes.LightBlue
            };

            StackPanel items = new StackPanel { Orientation = Orientation.Vertical };

            // Add the event details to the StackPanel
            items.Children.Add(new TextBlock { Text = $"UUID: {request.UUID}", FontWeight = FontWeights.Bold });
            items.Children.Add(new TextBlock { Text = $"Location: {request.Location}", FontWeight = FontWeights.Bold });
            items.Children.Add(new TextBlock { Text = $"Priority: {request.Priority}", FontWeight = FontWeights.Bold });
            items.Children.Add(new TextBlock { Text = $"Name: {request.Name}", FontWeight = FontWeights.Bold });
            items.Children.Add(new TextBlock { Text = $"Status: {request.Status}", FontWeight = FontWeights.Bold });

            // Create a button for the service request
            Button actionButton = new Button
            {
                Content = "View Related Service Requests",
                Margin = new Thickness(5, 10, 5, 0),
                Padding = new Thickness(5),
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Background = Brushes.DarkGray
            };

            // Assign an event handler to the button
            actionButton.Click += (s, e) => HandleRelatedButtonClick(request);

            // Add the button to the StackPanel
            items.Children.Add(actionButton);

            // Add the StackPanel to the Border
            eventBorder.Child = items;

            // Add the event Border to the StackPanel
            stackPanelServiceRequests.Children.Add(eventBorder);
        }
        //--------------------------------------------------------------------------------------//
        // Method to handle the button click for related service requests
        private void HandleRelatedButtonClick(ServiceRequest request)
        {
            try
            {// Clear the stack panel
                stackPanelServiceRequests.Children.Clear();
                // Get the related service requests
                var requestList = controller.GetRelatedRequests(request);
                // Iterate through the list of related service requests
                foreach (var relatedRequest in requestList)
                {
                    DisplayStackPanelForRequest(relatedRequest);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when getting related service requests. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //--------------------------------------------------------------------------------------//
        // Button to sort service requests by priority
        private void BtnSortByPriority_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                stackPanelServiceRequests.Children.Clear();
                controller.HandlePriorityViewRequests(DisplayStackPanelForRequest);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when sorting service requests by priority. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Button to get the most urgent service request
        private void BtnGetUrgent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var serviceRequest = controller.GetMostUrgentRequest();

                if (serviceRequest != null)
                {
                    // Format the details for display, including UUID
                    string message = $"UUID: {serviceRequest.UUID}\n" +
                                     $"Location: {serviceRequest.Location}\n" +
                                     $"Priority: {serviceRequest.Priority}\n" +
                                     $"Status: {serviceRequest.Status}\n" +
                                     $"Name: {serviceRequest.Name}";

                    // Display the details in a message box
                    MessageBox.Show(message, "Most Urgent Service Request", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when getting the most urgent service request. Please restart the application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Button to reset the service requests
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DisplayServiceRequestsAVL();
                cmbStatuses.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when resetting service requests. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
        // Method to populate the status ComboBox
        private void PopulateStatusComboBox()
        {
            // Retrieve all statuses from the graph
            List<string> allStatuses = controller.GetStatuses();

            // Clear the ComboBox (if necessary)
            cmbStatuses.Items.Clear();

            // Add each status to the ComboBox
            foreach (string status in allStatuses)
            {
                cmbStatuses.Items.Add(status);
            }
        }
        //--------------------------------------------------------------------------------------//
        private void cmbStatuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {// Get the selected status
            string selectedStatus = cmbStatuses.SelectedItem as string;
            try
            {// Check if a status was selected
                if (!string.IsNullOrEmpty(selectedStatus))
                {
                    // Perform an action with the selected status
                    stackPanelServiceRequests.Children.Clear();
                    var requestList = controller.GetRequestsForStatus(selectedStatus);
                    // Iterate through the list of related service requests
                    foreach (var relatedRequest in requestList)
                    {
                        DisplayStackPanelForRequest(relatedRequest);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when selecting a status. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//