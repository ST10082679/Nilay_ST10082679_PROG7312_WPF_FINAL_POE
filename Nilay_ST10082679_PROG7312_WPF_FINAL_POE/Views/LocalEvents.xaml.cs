using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public partial class LocalEvents : Window
    {
        private LocalEventsController controller;
        //--------------------------------------------------------------------------------------//
        // Constructor
        public LocalEvents()
        {
            InitializeComponent();
            controller = new LocalEventsController();
            RenderAllEvents();
            RenderRecommendedEvents();
            RenderTopSearches();
            RenderUniqueCategories();
            this.SizeChanged += LocalEventWindow_SizeChanged;
        }
        //--------------------------------------------------------------------------------------//
        // Render all events
        public void RenderAllEvents()
        {
            stackPanelEvents.Children.Clear();
            var allEvents = controller.GetAllEvents();
            foreach (var e in allEvents)
            {
                AddEventToStackPanel(e, stackPanelEvents);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Method to search for events
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the search criteria
                string category = txtSearchByCategory.Text;
                DateTime? selectedDate = dateTimePickerSearchByDate.SelectedDate;

                var events = controller.SearchEvents(category, selectedDate);
                stackPanelEvents.Children.Clear();

                foreach (var ev in events)
                {
                    AddEventToStackPanel(ev, stackPanelEvents);
                }

                RenderRecommendedEvents();
                RenderTopSearches();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Method to render recommended events
        private void RenderRecommendedEvents()
        {
            try
            {
                var recommendedEvents = controller.GetRecommendedEvents();
                dataGridRecommendedEvents.ItemsSource = recommendedEvents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Render top searches
        private void RenderTopSearches()
        {
            try
            {
                var topSearchTerms = controller.GetTopSearches();
                listBoxTopSearches.Items.Clear();
                foreach (var searchTerm in topSearchTerms)
                {
                    listBoxTopSearches.Items.Add(searchTerm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Render unique categories
        private void RenderUniqueCategories()
        {
            var uniqueCategories = controller.GetUniqueCategories();
            listBoxUniqueCategories.Items.Clear();
            foreach (var category in uniqueCategories)
            {
                listBoxUniqueCategories.Items.Add(category);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Navigate back to the Main Menu
        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Close();
        }
        //--------------------------------------------------------------------------------------//
        // Display events of the selected category
        private void listBoxUniqueCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxUniqueCategories.SelectedItem != null)
            {
                txtSearchByCategory.Text = listBoxUniqueCategories.SelectedItem.ToString();
            }
        }
        //--------------------------------------------------------------------------------------//
        // Resize event handler
        private void LocalEventWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Adjust the layout based on the window size
            if (this.ActualWidth < 992)
            {
                FirstColumn.Width = new GridLength(1, GridUnitType.Star);
                SecondColumn.Width = new GridLength(0);
                Grid.SetColumnSpan(lblHeading, 1);
                lblHeading.FontSize = 16;
                lblHeading.Margin = new Thickness(150, 0, 0, 0);
                Grid.SetColumn(stackPanelRight, 0);
                Grid.SetRow(stackPanelRight, 5);
            }
            else
            {
                FirstColumn.Width = new GridLength(334, GridUnitType.Star);
                SecondColumn.Width = new GridLength(191, GridUnitType.Star);
                Grid.SetColumnSpan(lblHeading, 2);
                lblHeading.FontSize = 20;
                lblHeading.Margin = new Thickness(364, 0, 0, 0);
                Grid.SetColumn(stackPanelRight, 1);
                Grid.SetRow(stackPanelRight, 1);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Helper method to add events to the stack panel
        private void AddEventToStackPanel(Event ev, StackPanel panel)
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
            // Create a stack panel to hold the event details
            StackPanel eventDetails = new StackPanel { Orientation = Orientation.Vertical };
            // Add the event details to the StackPanel
            eventDetails.Children.Add(new TextBlock { Text = $"Name: {ev.Name}", FontWeight = FontWeights.Bold });
            eventDetails.Children.Add(new TextBlock { Text = $"Description: {ev.Description}" });
            eventDetails.Children.Add(new TextBlock { Text = $"Category: {ev.Category}" });
            eventDetails.Children.Add(new TextBlock { Text = $"Date and Time: {ev.Date:yyyy-MM-dd HH:mm:ss}" });
            eventDetails.Children.Add(new TextBlock { Text = $"Duration: {ev.Duration}" });
            // Add the StackPanel to the Border
            eventBorder.Child = eventDetails;
            panel.Children.Add(eventBorder);
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//