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
        //public BinarySearchTree bst;
        public AVLTree avl;
        public MinHeap minHeap;
        public ServiceRequestGraph graph;
        //--------------------------------------------------------------------------------------//
        public ServiceRequestStatus()
        {
            InitializeComponent();   
            avl = new AVLTree();
            minHeap = new MinHeap();
            graph = new ServiceRequestGraph();
            LoadData();
            DisplayServiceRequestsAVL();   
        }
        //--------------------------------------------------------------------------------------//
        public void LoadData()
        {
            // Sample data insertion
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location A", "Pending", 1, "John Good"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location B", "In Progress", 34, "Jane Bob"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location C", "Completed", 4, "Alice Jacob"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location A", "Pending", 4, "John Doe"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location B", "In Progress", 67, "Jane Smith"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location C", "Completed", 100, "Alice Johnson"));
        }
        //--------------------------------------------------------------------------------------//
        public void InsertRequest(ServiceRequest request)
        {
            // Insert into AVL tree and MinHeap
            avl.InsertServiceRequestAVL(request);
            minHeap.Insert(request);

            // Add the request to the graph
            graph.AddRequest(request);

            // Dynamically add relationships based on location
            foreach (var existingRequest in graph.GetAllRequests())
            {
                if (existingRequest.Location == request.Location && existingRequest != request)
                {
                    graph.AddRelationship(request, existingRequest);
                }
            }
        }

        //--------------------------------------------------------------------------------------//
        public void DisplayServiceRequestsAVL()
        {
            stackPanelServiceRequests.Children.Clear();
            avl.InOrderTraversalAVL(avl.avlRoot, DisplayStackPanelForRequest);
        }
        //--------------------------------------------------------------------------------------//
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please enter a UUID to search for.");
                return;
            }
            stackPanelServiceRequests.Children.Clear();
            avl.SearchPartialUUID(avl.avlRoot, txtSearch.Text, DisplayStackPanelForRequest);

            //DisplayPanel(requestList);
        }
        //--------------------------------------------------------------------------------------//
        public void DisplayPanel(List<ServiceRequest> requestList)
        {
            stackPanelServiceRequests.Children.Clear();

            foreach (var request in requestList)
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
                    Padding = new Thickness(5)
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
        }

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
                Padding = new Thickness(5)
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

        private void HandleRelatedButtonClick(ServiceRequest request)
        {
            stackPanelServiceRequests.Children.Clear();
            var requestList = graph.GetRelatedRequests(request);

            foreach (var relatedRequest in requestList)
            {
                DisplayStackPanelForRequest(relatedRequest);
            }
            //DisplayPanel(relatedRequests);
        }

        //--------------------------------------------------------------------------------------//
        private void BtnSortByPriority_Click(object sender, RoutedEventArgs e)
        {
            stackPanelServiceRequests.Children.Clear();
            minHeap.GetRequestsInPriorityOrder(DisplayStackPanelForRequest);
        }
        //--------------------------------------------------------------------------------------//
        private void BtnGetUrgent_Click(object sender, RoutedEventArgs e)
        {
            var serviceRequest = minHeap.ExtractMin();
            MessageBox.Show(serviceRequest.Priority + " " + serviceRequest.Name); 
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            DisplayServiceRequestsAVL();
        }
    }
}
