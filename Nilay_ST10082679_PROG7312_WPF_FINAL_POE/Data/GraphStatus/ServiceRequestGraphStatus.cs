using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class ServiceRequestGraphStatus
    {
        private Dictionary<string, ServiceRequestGraphNode> nodes;
        //--------------------------------------------------------------------------------------//
        // Constructor
        public ServiceRequestGraphStatus()
        {
            nodes = new Dictionary<string, ServiceRequestGraphNode>();
        }
        //--------------------------------------------------------------------------------------//
        // Add a status node if it doesn't exist
        public void AddStatus(string status)
        {
            if (!nodes.ContainsKey(status))
            {
                nodes[status] = new ServiceRequestGraphNode(status);
            }
        }
        //--------------------------------------------------------------------------------------//
        // Add a service request to a status node
        public void AddServiceRequest(ServiceRequest request)
        {
            AddStatus(request.Status);
            nodes[request.Status].Requests.Add(request);
        }
        //--------------------------------------------------------------------------------------//
        // Add a relationship between statuses 
        public void AddStatusRelationship(string status1, string status2)
        {
            AddStatus(status1);
            AddStatus(status2);

            var node1 = nodes[status1];
            var node2 = nodes[status2];
            // Add a relationship between the two nodes
            if (!node1.Neighbors.Contains(node2))
                node1.Neighbors.Add(node2);
            
            if (!node2.Neighbors.Contains(node1))
                node2.Neighbors.Add(node1);
        }
        //--------------------------------------------------------------------------------------//
        // Get all service requests for a specific status
        public List<ServiceRequest> GetRequestsByStatus(string status)
        {
            if (nodes.ContainsKey(status))
                return nodes[status].Requests;

            return new List<ServiceRequest>();
        }
        //--------------------------------------------------------------------------------------//
        // Traverse the graph to find all connected statuses
        public List<string> GetConnectedStatuses(string status)
        {
            if (!nodes.ContainsKey(status))
                return new List<string>();
            
            HashSet<string> visited = new HashSet<string>();
            List<string> connectedStatuses = new List<string>();
            Traverse(nodes[status], visited, connectedStatuses);
            return connectedStatuses;
        }
        //--------------------------------------------------------------------------------------//
        // Get all statuses in the graph
        public List<string> GetAllStatuses()
        {
            return nodes.Keys.ToList();
        }
        //--------------------------------------------------------------------------------------//
        // Traverse the graph using Depth First Search starting from the specified node
        private void Traverse(ServiceRequestGraphNode node, HashSet<string> visited, List<string> result)
        {
            if (visited.Contains(node.Status)) return;

            visited.Add(node.Status);
            result.Add(node.Status);
            // Traverse all neighbors
            foreach (var neighbor in node.Neighbors)
            {
                Traverse(neighbor, visited, result);
            }
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//