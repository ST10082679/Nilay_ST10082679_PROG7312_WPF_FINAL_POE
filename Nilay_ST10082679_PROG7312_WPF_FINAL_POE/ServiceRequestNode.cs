using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class ServiceRequestNode
    {
        public ServiceRequest Data { get; set; }
        public ServiceRequestNode Left { get; set; }
        public ServiceRequestNode Right { get; set; }

        public ServiceRequestNode(ServiceRequest data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}