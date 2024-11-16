using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    using System;
    using System.Collections.Generic;

    public class ServiceRequestGraphLocation
    {
        private Dictionary<ServiceRequest, List<ServiceRequest>> adjacencyList;

        public ServiceRequestGraphLocation()
        {
            adjacencyList = new Dictionary<ServiceRequest, List<ServiceRequest>>();
        }

        // Add a service request node to the graph
        public void AddRequest(ServiceRequest request)
        {
            if (!adjacencyList.ContainsKey(request))
                adjacencyList[request] = new List<ServiceRequest>();
        }

        // Add an edge between two requests (relationship)
        public void AddRelationship(ServiceRequest request1, ServiceRequest request2)
        {
            if (!adjacencyList.ContainsKey(request1))
                AddRequest(request1);
            if (!adjacencyList.ContainsKey(request2))
                AddRequest(request2);

            adjacencyList[request1].Add(request2);
            adjacencyList[request2].Add(request1); // Undirected relationship; remove if directed
        }

        public List<ServiceRequest> GetAllRequests()
        {
            return new List<ServiceRequest>(adjacencyList.Keys);
        }


        // Get related service requests
        public List<ServiceRequest> GetRelatedRequests(ServiceRequest request)
        {
            if (adjacencyList.ContainsKey(request))
                return adjacencyList[request];

            return new List<ServiceRequest>();
        }

        // Example graph traversal (e.g., Depth-First Search)
        public void Traverse(ServiceRequest startRequest, HashSet<ServiceRequest> visited = null)
        {
            if (visited == null)
                visited = new HashSet<ServiceRequest>();

            if (!visited.Contains(startRequest))
            {
                Console.WriteLine("Visited: " + startRequest.UUID);
                visited.Add(startRequest);

                foreach (var neighbor in adjacencyList[startRequest])
                {
                    Traverse(neighbor, visited);
                }
            }
        }
    }

}
