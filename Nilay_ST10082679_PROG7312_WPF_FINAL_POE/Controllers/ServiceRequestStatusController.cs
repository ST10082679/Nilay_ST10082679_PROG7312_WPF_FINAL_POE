using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class ServiceRequestStatusController
    {
        public AVLTree avl;
        public MinHeap minHeap;
        public ServiceRequestGraphLocation graphLocation;
        public ServiceRequestGraphStatus graphStatuses;

        public ServiceRequestStatusController()
        {
            avl = new AVLTree();
            minHeap = new MinHeap();
            graphLocation = new ServiceRequestGraphLocation();
            graphStatuses = new ServiceRequestGraphStatus();
            LoadData();
        }

        public void LoadData()
        {
            // Sample data insertion
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location A", "Pending", 1, "John Good"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location B", "In Progress", 34, "Jane Bob"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location C", "Completed", 4, "Alice Jacob"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location A", "Pending", 4, "John Doe"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location B", "In Progress", 67, "Jane Smith"));
            InsertRequest(new ServiceRequest(Guid.NewGuid().ToString(), "Location C", "Completed", 100, "Alice Johnson"));
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
                    graphLocation.AddRelationship(request, existingRequest);
                }
            }
        }

        public void HandleNormalViewRequests (Action<ServiceRequest> action)
        {
            avl.InOrderTraversalAVL(avl.avlRoot, action);
        }

        public void HandleSearchViewRequests(Action<ServiceRequest> action, string searchValue)
        {
            avl.SearchPartialUUID(avl.avlRoot, searchValue, action);
        }

        public List<ServiceRequest> GetRelatedRequests(ServiceRequest request)
        {
            return graphLocation.GetRelatedRequests(request);
        }

        public ServiceRequest GetMostUrgentRequest()
        {
            return minHeap.Peek();
        }

        public void HandlePriorityViewRequests(Action<ServiceRequest> action)
        {
            minHeap.GetRequestsInPriorityOrder(action);
        }

        public List<string> GetStatuses()
        {
            return graphStatuses.GetAllStatuses();
        }

        public List<ServiceRequest> GetRequestsForStatus(string status)
        {
            return graphStatuses.GetRequestsByStatus(status);
        }
    }
}