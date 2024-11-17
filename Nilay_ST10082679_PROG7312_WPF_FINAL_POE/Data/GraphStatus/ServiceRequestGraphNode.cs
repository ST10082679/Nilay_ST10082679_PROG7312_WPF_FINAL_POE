using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class ServiceRequestGraphNode
    {
        public string Status { get; set; }
        public List<ServiceRequest> Requests { get; set; }
        public List<ServiceRequestGraphNode> Neighbors { get; set; }
        //--------------------------------------------------------------------------------------//
        // Constructor
        public ServiceRequestGraphNode(string status)
        {
            Status = status;
            Requests = new List<ServiceRequest>();
            Neighbors = new List<ServiceRequestGraphNode>();
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//