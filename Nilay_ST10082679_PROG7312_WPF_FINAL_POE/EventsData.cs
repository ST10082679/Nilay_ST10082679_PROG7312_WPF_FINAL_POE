using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class EventsData
    {
        // Dictionary to store events by date
        public SortedDictionary<DateTime, Queue<Event>> eventsDictionary = new SortedDictionary<DateTime, Queue<Event>>();
        // HashSet to store unique categories
        public HashSet<string> uniqueCategoriesSet = new HashSet<string>();
        // Dictionary to store search frequency
        public Dictionary<string, int> searchFrequency = new Dictionary<string, int>();
        //--------------------------------------------------------------------------------------//
        public EventsData()
        {
            InitializeEvents();
            InitializeCategories();
        }
        //--------------------------------------------------------------------------------------//
       public void InitializeEvents()
        {
            // Adds events to the events dictionary
            Queue<Event> eventsQueue = new Queue<Event>();
            /*eventsQueue.Enqueue(new Event("Music Festival", "Enjoy live music from various artists.", new DateTime(2024, 10, 15), TimeSpan.FromHours(5), "Music"));
            eventsQueue.Enqueue(new Event("Tech Conference", "Learn about the latest in technology.", new DateTime(2024, 10, 20), TimeSpan.FromHours(3), "Technology"));
            eventsQueue.Enqueue(new Event("Food Expo", "Taste delicious food from around the world.", new DateTime(2024, 10, 25), TimeSpan.FromHours(6), "Food"));
            eventsQueue.Enqueue(new Event("Art Exhibition", "Explore modern and classical art.", new DateTime(2024, 10, 30), TimeSpan.FromHours(4), "Art"));
            */
            eventsQueue.Enqueue(new Event("Water Supply Maintenance", "Scheduled maintenance of water supply lines in downtown.", new DateTime(2024, 10, 15), TimeSpan.FromHours(8), "Maintenance"));
            eventsQueue.Enqueue(new Event("Road Resurfacing on N1", "Resurfacing of the N1 highway to improve road safety.", new DateTime(2024, 10, 17), TimeSpan.FromHours(6), "Infrastructure"));
            eventsQueue.Enqueue(new Event("Community Health Outreach", "Free health screenings for residents.", new DateTime(2024, 10, 20), TimeSpan.FromHours(5), "Health"));
            eventsQueue.Enqueue(new Event("Park Beautification Day", "Clean-up event for local parks and green spaces.", new DateTime(2024, 10, 22), TimeSpan.FromHours(4), "Environmental"));
            eventsQueue.Enqueue(new Event("Fire Safety Awareness", "Workshop on fire safety and prevention for homes.", new DateTime(2024, 10, 24), TimeSpan.FromHours(3), "Safety"));
            eventsQueue.Enqueue(new Event("City Budget Meeting", "Review of the 2024/2025 municipal budget.", new DateTime(2024, 10, 25), TimeSpan.FromHours(3), "Civic Engagement"));
            eventsQueue.Enqueue(new Event("Traffic Signal Upgrade", "Upgrading traffic lights in central Johannesburg.", new DateTime(2024, 10, 27), TimeSpan.FromHours(5), "Infrastructure"));
            eventsQueue.Enqueue(new Event("Urban Farming Workshop", "Learn how to start an urban farm.", new DateTime(2024, 10, 29), TimeSpan.FromHours(3), "Community"));
            eventsQueue.Enqueue(new Event("Waste Management Workshop", "Seminar on waste reduction and recycling.", new DateTime(2024, 11, 1), TimeSpan.FromHours(4), "Environmental"));
            eventsQueue.Enqueue(new Event("Library Renovation", "Renovation of the main municipal library.", new DateTime(2024, 11, 3), TimeSpan.FromHours(7), "Maintenance"));

            eventsQueue.Enqueue(new Event("Electricity Grid Maintenance", "Upgrading electricity infrastructure in Soweto.", new DateTime(2024, 11, 5), TimeSpan.FromHours(8), "Maintenance"));
            eventsQueue.Enqueue(new Event("Public Transport Meeting", "Discussion on expanding Rea Vaya bus routes.", new DateTime(2024, 11, 7), TimeSpan.FromHours(2), "Public Services"));
            eventsQueue.Enqueue(new Event("Sports Complex Opening", "Opening of the new sports complex in Cape Town.", new DateTime(2024, 11, 10), TimeSpan.FromHours(3), "Recreation"));
            eventsQueue.Enqueue(new Event("Housing Development Briefing", "Briefing on upcoming RDP housing projects.", new DateTime(2024, 11, 12), TimeSpan.FromHours(3), "Housing"));
            eventsQueue.Enqueue(new Event("Emergency Response Drill", "City-wide disaster preparedness drill.", new DateTime(2024, 11, 15), TimeSpan.FromHours(5), "Safety"));
            eventsQueue.Enqueue(new Event("Arbor Day Tree Planting", "Tree-planting event for urban greening.", new DateTime(2024, 11, 17), TimeSpan.FromHours(4), "Environmental"));
            eventsQueue.Enqueue(new Event("Winter Blanket Drive", "Collecting blankets for vulnerable communities.", new DateTime(2024, 11, 20), TimeSpan.FromHours(6), "Community"));
            eventsQueue.Enqueue(new Event("Public Safety Town Hall", "Discussion on crime prevention strategies.", new DateTime(2024, 11, 22), TimeSpan.FromHours(3), "Safety"));
            eventsQueue.Enqueue(new Event("Youth Job Fair", "Job fair for youth with local businesses.", new DateTime(2024, 11, 25), TimeSpan.FromHours(5), "Employment"));
            eventsQueue.Enqueue(new Event("Holiday Lights Festival", "Annual holiday lights festival in Durban.", new DateTime(2024, 11, 30), TimeSpan.FromHours(6), "Recreation"));
 

            foreach (var e in eventsQueue)
            {
                if (!eventsDictionary.ContainsKey(e.Date))
                    eventsDictionary[e.Date] = new Queue<Event>();

                eventsDictionary[e.Date].Enqueue(e);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Method to initialize the unique categories
        public void InitializeCategories()
        {
            foreach (var eventQueue in eventsDictionary.Values)
            {
                foreach (var e in eventQueue)
                {
                    uniqueCategoriesSet.Add(e.Category);
                }
            }
        }
        //--------------------------------------------------------------------------------------//
        // Method to search events by category
        public List<Event> SearchByCategory(string category)
        {
            List<Event> result = new List<Event>();
            foreach (var eventQueue in eventsDictionary.Values)
            {
                foreach (var e in eventQueue)
                {
                    if (e.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(e);
                    }
                }
            }
            return result;
        }
        //--------------------------------------------------------------------------------------//
        // Method to search events by date
        public List<Event> SearchByDate(DateTime date)
        {
            if (eventsDictionary.ContainsKey(date))
            {
                return eventsDictionary[date].ToList();
            }
            return new List<Event>();
        }
        //--------------------------------------------------------------------------------------//
        // Method to search events by keyword
        public void UpdateSearchFrequency(string searchTerm)
        {
            if (searchFrequency.ContainsKey(searchTerm))
            {
                searchFrequency[searchTerm]++;
            }
            else
            {
                searchFrequency[searchTerm] = 1;
            }
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//