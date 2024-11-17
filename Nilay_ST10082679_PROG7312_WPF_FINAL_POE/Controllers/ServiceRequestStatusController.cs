using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class ServiceRequestStatusController
    {
        public AVLTree avl;
        public MinHeap minHeap;
        public ServiceRequestGraphLocation graphLocation;
        public ServiceRequestGraphStatus graphStatuses;
        //--------------------------------------------------------------------------------------//
        // Constructor
        public ServiceRequestStatusController()
        {
            avl = new AVLTree();
            minHeap = new MinHeap();
            graphLocation = new ServiceRequestGraphLocation();
            graphStatuses = new ServiceRequestGraphStatus();
            LoadData();
        }
        //--------------------------------------------------------------------------------------//
        // Load sample data
        public void LoadData()
        {
            // Sample data insertion
            // Generated from chat 
            // The UUID is auto generated and the rest of the data is random
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sandton, Johannesburg", "Pending", 12, "Fix drainage"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Clifton, Cape Town", "In Progress", 34, "Repair potholes"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Umhlanga, Durban", "Completed", 45, "Clean park"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sandton, Johannesburg", "Pending", 78, "Install streetlights"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Summerstrand, Port Elizabeth", "In Progress", 22, "Repair water pipeline"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sandton, Johannesburg", "Completed", 15, "Trim overgrown trees"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Langenhoven Park, Bloemfontein", "Pending", 56, "Clear blocked sewer"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sterpark, Polokwane", "In Progress", 89, "Repair electrical outage"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Cashan, Rustenburg", "Completed", 14, "Remove illegal dumping"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Green Point, Cape Town", "Pending", 33, "Repair road signage"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Melville, Johannesburg", "In Progress", 67, "Install speed bumps"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Dobsonville, Soweto", "Completed", 81, "Fix streetlights"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Umhlanga, Durban", "Pending", 3, "Repair stormwater drain"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Morningside, Durban", "In Progress", 19, "Clean illegal graffiti"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sandton, Johannesburg", "Completed", 91, "Replace manhole covers"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sonheuwel, Nelspruit", "Pending", 48, "Remove fallen tree"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Heather Park, George", "In Progress", 25, "Fix broken water main"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Clifton, Cape Town", "Completed", 5, "Repair park benches"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Monument Heights, Kimberley", "Pending", 84, "Fix public restroom plumbing"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Three Rivers, Vereeniging", "In Progress", 66, "Replace damaged curb"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Glenwood, Durban", "Completed", 73, "Clean up flooding debris"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sandton, Johannesburg", "Pending", 20, "Repair broken traffic light"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Nahoon, East London", "In Progress", 35, "Install new waste bins"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Summerstrand, Port Elizabeth", "Completed", 92, "Fix playground equipment"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Rosebank, Johannesburg", "Pending", 50, "Fix municipal building leak"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Clifton, Cape Town", "In Progress", 1, "Repair stormwater drain"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Umhlanga, Durban", "Completed", 2, "Fix streetlights"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sandton, Johannesburg", "Pending", 6, "Repair potholes"));
        }
        //--------------------------------------------------------------------------------------//
        public void InsertRequest(ServiceRequest request)
        {
            // Insert into AVL tree and MinHeap
            avl.InsertServiceRequestAVL(request);
            minHeap.Insert(request);

            // Add the request to the graph
            graphLocation.AddRequest(request);
            graphStatuses.AddServiceRequest(request);

            // Dynamically add relationships based on location
            foreach (var existingRequest in graphLocation.GetAllRequests())
            {
                if (existingRequest.Location == request.Location && existingRequest != request)
                { 
                    // Add a relationship between the new request and the existing request
                    graphLocation.AddRelationship(request, existingRequest);
                }
            }
        }
        //--------------------------------------------------------------------------------------//
        // The in-order traversal ensures the service requests are processed in sorted order
        public void HandleNormalViewRequests (Action<ServiceRequest> action)
        {
            avl.InOrderTraversalAVL(avl.avlRoot, action);
        }
        //--------------------------------------------------------------------------------------//
        // Search for a service request by UUID, the  UUID can be partial 
        public void HandleSearchViewRequests(Action<ServiceRequest> action, string searchValue)
        {
            avl.SearchPartialUUID(avl.avlRoot, searchValue, action);
        }
        //--------------------------------------------------------------------------------------//
        // Get all service requests related to a specific request
        public List<ServiceRequest> GetRelatedRequests(ServiceRequest request)
        {
            return graphLocation.GetRelatedRequests(request);
        }
        //--------------------------------------------------------------------------------------//
        // Provids the most urgetn service request based on priority 
        public ServiceRequest GetMostUrgentRequest()
        {
            return minHeap.Peek();
        }
        //--------------------------------------------------------------------------------------//
        // Get all service requests in priority order
        public void HandlePriorityViewRequests(Action<ServiceRequest> action)
        {
            minHeap.GetRequestsInPriorityOrder(action);
        }
        //--------------------------------------------------------------------------------------//
        // Get all unique statuses in the graph
        public List<string> GetStatuses()
        {
            return graphStatuses.GetAllStatuses();
        }
        //--------------------------------------------------------------------------------------//
        // Get all service requests for a specific status
        public List<ServiceRequest> GetRequestsForStatus(string status)
        {
            return graphStatuses.GetRequestsByStatus(status);
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//