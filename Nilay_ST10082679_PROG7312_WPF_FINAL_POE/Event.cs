using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public string Category { get; set; }
        //--------------------------------------------------------------------------------------//
        // Constructor 
        public Event(string name, string description, DateTime date, TimeSpan duration, string category)
        {
            Name = name;
            Description = description;
            Date = date;
            Duration = duration;
            Category = category;
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//