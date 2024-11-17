using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class LocalEventsController
    {
        private EventsData eventsData;
        //--------------------------------------------------------------------------------------//
        // Constructor
        public LocalEventsController()
        {
            eventsData = new EventsData();
        }
        //--------------------------------------------------------------------------------------//
        // Add event
        public List<Event> GetAllEvents()
        {
            var events = new List<Event>();
            foreach (var eventQueue in eventsData.eventsDictionary.Values)
            {
                events.AddRange(eventQueue);
            }
            return events;
        }
        //--------------------------------------------------------------------------------------//
        // Search events by category and/or date
        public List<Event> SearchEvents(string category, DateTime? selectedDate)
        {
            var events = new List<Event>();

            if (!string.IsNullOrWhiteSpace(category) && selectedDate.HasValue)
            {
                foreach (var eventQueue in eventsData.eventsDictionary)
                {
                    foreach (var ev in eventQueue.Value)
                    {
                        if (ev.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0 &&
                            ev.Date.Date == selectedDate.Value.Date)
                        {
                            events.Add(ev);
                        }
                    }
                }
            }
            else if (!string.IsNullOrWhiteSpace(category))
            {
                foreach (var eventQueue in eventsData.eventsDictionary)
                {
                    foreach (var ev in eventQueue.Value)
                    {
                        if (ev.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            events.Add(ev);
                        }
                    }
                }
            }
            else if (selectedDate.HasValue)
            {
                events = eventsData.SearchByDate(selectedDate.Value);
            }
            else
            {
                events = GetAllEvents();
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                eventsData.UpdateSearchFrequency(category.ToLower());
            }
            if (selectedDate.HasValue)
            {
                eventsData.UpdateSearchFrequency(selectedDate.Value.ToShortDateString());
            }

            return events;
        }
        //--------------------------------------------------------------------------------------//
        // Get recommended events
        public List<Event> GetRecommendedEvents()
        {
            var recommendedEvents = new List<Event>();
            var topSearchTerms = eventsData.searchFrequency
                .OrderByDescending(pair => pair.Value)
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
                            if (!recommendedEvents.Contains(ev) && recommendedEvents.Count < 5)
                            {
                                recommendedEvents.Add(ev);
                            }
                            break;
                        }
                    }
                }
            }

            return recommendedEvents;
        }
        //--------------------------------------------------------------------------------------//
        // Get top search terms
        public List<string> GetTopSearches()
        {
            return eventsData.searchFrequency
                .OrderByDescending(pair => pair.Value)
                .Take(5)
                .Select(pair => $"{pair.Key} (Searched {pair.Value} times)")
                .ToList();
        }
        //--------------------------------------------------------------------------------------//
        // Get unique categories
        public List<string> GetUniqueCategories()
        {
            return eventsData.uniqueCategoriesSet.ToList();
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//