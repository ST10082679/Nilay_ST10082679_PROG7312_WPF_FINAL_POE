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
        public ServiceRequestStatus()
        {
            InitializeComponent();
            controller = new ServiceRequestStatusController();
            PopulateStatusComboBox();
            DisplayServiceRequestsAVL();   
        }

        //--------------------------------------------------------------------------------------//
        public void DisplayServiceRequestsAVL()
        {
            stackPanelServiceRequests.Children.Clear();
            controller.HandleNormalViewRequests(DisplayStackPanelForRequest);
        }
        //--------------------------------------------------------------------------------------//
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Please enter a UUID to search for.");
                    return;
                }
                stackPanelServiceRequests.Children.Clear();
                controller.HandleSearchViewRequests(DisplayStackPanelForRequest, txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when searching for service requests. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //--------------------------------------------------------------------------------------//
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
        private void HandleRelatedButtonClick(ServiceRequest request)
        {
            try
            {
                stackPanelServiceRequests.Children.Clear();
                var requestList = controller.GetRelatedRequests(request);

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
        private void BtnGetUrgent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var serviceRequest = controller.GetMostUrgentRequest();
                MessageBox.Show(serviceRequest.Priority + " " + serviceRequest.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when getting the most urgent service request. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
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
        private void BtnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }

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

        private void cmbStatuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedStatus = cmbStatuses.SelectedItem as string;
            try
            {
                if (!string.IsNullOrEmpty(selectedStatus))
                {
                    // Perform an action with the selected status
                    stackPanelServiceRequests.Children.Clear();
                    var requestList = controller.GetRequestsForStatus(selectedStatus);

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