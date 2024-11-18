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
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Hatfield, Pretoria", "Pending", 10, "Repair water main"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Bryanston, Johannesburg", "In Progress", 23, "Upgrade electrical substation"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Morningside, Durban", "Pending", 35, "Replace street signs"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sea Point, Cape Town", "Completed", 47, "Fix broken benches"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Hatfield, Pretoria", "In Progress", 8, "Install public Wi-Fi"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sea Point, Cape Town", "Pending", 19, "Repair sidewalk cracks"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Rosebank, Johannesburg", "Completed", 29, "Trim overgrown trees"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Westville, Durban", "In Progress", 11, "Repaint pedestrian crossings"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Rondebosch, Cape Town", "Pending", 39, "Fix streetlights"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Kempton Park, Johannesburg", "Completed", 15, "Clean illegal dumping site"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Rosebank, Johannesburg", "In Progress", 42, "Repair park equipment"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Stellenbosch, Cape Town", "Pending", 9, "Remove invasive plants"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "La Lucia, Durban", "Completed", 22, "Clear storm debris"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Fourways, Johannesburg", "In Progress", 13, "Install speed bumps"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Durban North, Durban", "Pending", 27, "Fix leaking fire hydrant"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Claremont, Cape Town", "Completed", 50, "Replace park fences"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Fourways, Johannesburg", "In Progress", 44, "Repair traffic lights"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Ballito, Durban", "Pending", 33, "Upgrade drainage system"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Somerset West, Cape Town", "Completed", 20, "Paint public benches"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Randburg, Johannesburg", "In Progress", 14, "Fill potholes"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Durban CBD, Durban", "Pending", 26, "Replace damaged traffic signs"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Constantia, Cape Town", "Completed", 12, "Prune municipal gardens"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Bryanston, Johannesburg", "In Progress", 31, "Resurface road"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Durban North, Durban", "Pending", 21, "Repaint street lines"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Lynnwood, Pretoria", "Completed", 5, "Repair broken swings"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Rosebank, Johannesburg", "Pending", 51, "Fix municipal building leak"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Clifton, Cape Town", "In Progress", 1, "Repair stormwater drain"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Umhlanga, Durban", "Completed", 2, "Fix streetlights"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sandton, Johannesburg", "Pending", 6, "Repair potholes"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sandton, Johannesburg", "Pending", 12, "Fix drainage"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Clifton, Cape Town", "In Progress", 34, "Repair potholes"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Umhlanga, Durban", "Completed", 45, "Clean park"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Sandton, Johannesburg", "Pending", 78, "Install streetlights"));
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