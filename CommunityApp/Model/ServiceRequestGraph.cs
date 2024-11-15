using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Model
{
    public class ServiceRequestGraph
    {
        public Dictionary<int, List<int>> dependencies;
        public BinarySearchTree bst;

        public ServiceRequestGraph(BinarySearchTree bst)
        {
            dependencies = new Dictionary<int, List<int>>();
            this.bst = bst;
        }

        // Add a new request to the graph and BST
        public void AddRequest(ServiceRequest request)
        {
            bst.Insert(request);
            dependencies[request.ID] = new List<int>();
        }

        // Add a dependency: fromRequestId must be completed before toRequestId
        public void AddDependency(int fromRequestId, int toRequestId)
        {
            if (dependencies.ContainsKey(fromRequestId))
            {
                dependencies[fromRequestId].Add(toRequestId);
            }
        }

        // Update status of a request in the graph and BST
        public bool UpdateRequestStatus(int requestId, string newStatus)
        {
            var request = bst.Search(requestId);
            if (request != null)
            {
                request.UpdateStatus(newStatus);
                return true;
            }
            return false;
        }

        // Display all requests and their dependencies
        public void DisplayDependencies()
        {
            foreach (var entry in dependencies)
            {
                var request = bst.Search(entry.Key);
                Console.WriteLine($"Request ID: {request.ID}, Status: {request.Status}");
                foreach (var dep in entry.Value)
                {
                    var depRequest = bst.Search(dep);
                    Console.WriteLine($"  -> Depends on: Request ID {depRequest.ID}, Status: {depRequest.Status}");
                }
            }
        }
    }
}
