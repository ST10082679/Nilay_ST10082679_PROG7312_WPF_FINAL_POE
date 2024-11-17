using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class ServiceRequest
    {
        public string UUID { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }
        //--------------------------------------------------------------------------------------//
        public ServiceRequest(string uuid, string location, string status, int priority, string name)
        {
            UUID = uuid;
            Location = location;
            Status = status;
            Priority = priority;
            Name = name;
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//