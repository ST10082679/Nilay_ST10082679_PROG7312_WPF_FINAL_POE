﻿using System;
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
    public partial class LocalEvents : Window
    {
        // Instance of the EventsData class
        public EventsData eventsData;
        //--------------------------------------------------------------------------------------//
        // Constructor
        public LocalEvents()
        {
            InitializeComponent();
            eventsData = new EventsData();
            DisplayAllEvents();
            DisplayRecommendedEvents();
            DisplayTopSearches();
            ShowUniqueCategories();
        }
        //--------------------------------------------------------------------------------------//
        // Method to display all events
        public void DisplayAllEvents()
        {
            stackPanelEvents.Children.Clear();

            foreach (var eventQueue in eventsData.eventsDictionary.Values)
            {
                foreach (var e in eventQueue)
                {
                    // Create a Border to represent the card
                    Border eventBorder = new Border
                    {
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(1),
                        CornerRadius = new CornerRadius(10),
                        Padding = new Thickness(10),
                        Margin = new Thickness(60, 10, 0, 0),
                        Background = Brushes.LightBlue

                    };

                    // Create a StackPanel to hold event details
                    StackPanel eventDetails = new StackPanel { Orientation = Orientation.Vertical };
                   
                    eventDetails.Children.Add(new TextBlock { Text = $"Name: {e.Name}", FontWeight = FontWeights.Bold });
                    eventDetails.Children.Add(new TextBlock { Text = $"Description: {e.Description}" });
                    eventDetails.Children.Add(new TextBlock { Text = $"Category: {e.Category}" });
                    eventDetails.Children.Add(new TextBlock { Text = $"Date and Time: {e.Date:yyyy-MM-dd HH:mm:ss}" });
                    eventDetails.Children.Add(new TextBlock { Text = $"Duration: {e.Duration}" });

                    // Add the StackPanel to the Border
                    eventBorder.Child = eventDetails;

                    // Add the event card to the StackPanel
                    stackPanelEvents.Children.Add(eventBorder);
                }
            }
        }
        //--------------------------------------------------------------------------------------//
        //Method to search for events
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string category = txtSearchByCategory.Text;
                DateTime? selectedDate = dateTimePickerSearchByDate.SelectedDate;

                List<Event> events = new List<Event>();

                // Case 1: Both category and date are specified
                if (!string.IsNullOrWhiteSpace(category) && selectedDate.HasValue)
                {
                    foreach (var eventQueue in eventsData.eventsDictionary)
                    {
                        foreach (var ev in eventQueue.Value)
                        {
                            if (ev.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0 && ev.Date.Date == selectedDate.Value.Date)
                            {
                                events.Add(ev);
                            }
                        }
                    }
                }
                // Case 2: Only category is specified (with substring search)
                else if (!string.IsNullOrWhiteSpace(category))
                {
                    foreach (var eventQueue in eventsData.eventsDictionary)
                    {
                        foreach (var ev in eventQueue.Value)
                        {
                            if (ev.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0) // Substring search
                            {
                                events.Add(ev);
                            }
                        }
                    }
                }
                // Case 3: Only date is specified
                else if (selectedDate.HasValue)
                {
                    events = eventsData.SearchByDate(selectedDate.Value);
                }
                // Case 4: Neither category nor date is specified, show all events
                else
                {
                    foreach (var eventQueue in eventsData.eventsDictionary)
                    {
                        foreach (var ev in eventQueue.Value)
                        {
                            events.Add(ev);
                        }
                    }
                }

                // Clear the existing events from the StackPanel
                stackPanelEvents.Children.Clear();

                // Display the search results
                foreach (var ev in events)
                {
                    // Create a Border for each event
                    Border eventBorder = new Border
                    {
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(1),
                        CornerRadius = new CornerRadius(10),
                        Padding = new Thickness(10),
                        Margin = new Thickness(60, 10, 0, 0),
                        Background = Brushes.LightBlue
                    };

                    // Create a StackPanel for event details
                    StackPanel eventDetails = new StackPanel { Orientation = Orientation.Vertical };

                    // Add the event details to the StackPanel
                    eventDetails.Children.Add(new TextBlock { Text = $"Name: {ev.Name}", FontWeight = FontWeights.Bold });
                    eventDetails.Children.Add(new TextBlock { Text = $"Description: {ev.Description}" });
                    eventDetails.Children.Add(new TextBlock { Text = $"Category: {ev.Category}" });
                    eventDetails.Children.Add(new TextBlock { Text = $"Date and Time: {ev.Date:yyyy-MM-dd HH:mm:ss}" });
                    eventDetails.Children.Add(new TextBlock { Text = $"Duration: {ev.Duration}" });

                    // Add the StackPanel to the Border
                    eventBorder.Child = eventDetails;

                    // Add the event Border to the StackPanel
                    stackPanelEvents.Children.Add(eventBorder);
                }

                // Update search term frequency
                if (!string.IsNullOrWhiteSpace(category))
                {
                    eventsData.UpdateSearchFrequency(category.ToLower());
                }
                if (selectedDate.HasValue)
                {
                    eventsData.UpdateSearchFrequency(selectedDate.Value.ToShortDateString());
                }

                DisplayRecommendedEvents();
                DisplayTopSearches();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Method to display the recommended events
        private void DisplayRecommendedEvents()
        {
            try { 
            List<Event> recommendedEvents = new List<Event>();

            // Sort search terms by frequency and pick top 5
            var topSearchTerms = eventsData.searchFrequency.OrderByDescending(pair => pair.Value)
                                                .Take(5)
                                                .Select(pair => pair.Key)
                                                .ToList();

            foreach (var eventQueue in eventsData.eventsDictionary)
            {
                foreach (var ev in eventQueue.Value)
                {
                    foreach (var searchTerm in topSearchTerms)
                    {
                        if (ev.Category.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            ev.Date.ToShortDateString().Equals(searchTerm))
                        {
                            if (recommendedEvents.Count < 5)
                            {
                                recommendedEvents.Add(ev);
                            }
                            break; 
                        }
                    }
                }
            }

            // Bind the recommended events to the DataGrid
            dataGridRecommendedEvents.ItemsSource = recommendedEvents;
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when displaying recommended events. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Method to display the top searches
        private void DisplayTopSearches()
        {
            try
            {
                // Sort search terms by frequency and display top 5
                var topSearchTerms = eventsData.searchFrequency.OrderByDescending(pair => pair.Value)
                                                    .Take(5)
                                                    .Select(pair => $"{pair.Key} (Searched {pair.Value} times)")
                                                    .ToList();

                // Display top searches
                listBoxTopSearches.Items.Clear();
                foreach (var searchTerm in topSearchTerms)
                {
                    listBoxTopSearches.Items.Add(searchTerm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops an error occurred when displaying top searches. Please restart application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Method to display the unique categories
        private void ShowUniqueCategories()
        {
            listBoxUniqueCategories.Items.Clear();
            foreach (var category in eventsData.uniqueCategoriesSet)
            {
                listBoxUniqueCategories.Items.Add(category);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Button to go back to the Main Menu
        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Close();
        }
        //--------------------------------------------------------------------------------------//
        // Method to display the events of the selected category
        private void listBoxUniqueCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxUniqueCategories.SelectedItem != null)
            {
                txtSearchByCategory.Text = listBoxUniqueCategories.SelectedItem.ToString();
            }
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//