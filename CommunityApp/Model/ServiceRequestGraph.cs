using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Model
{
    public class ServiceRequestGraph
    {
        private Dictionary<string, GraphNode> nodes;

        public ServiceRequestGraph()
        {
            nodes = new Dictionary<string, GraphNode>
            {
                { "Pending", new GraphNode("Pending") },
                { "Ongoing", new GraphNode("Ongoing") },
                { "Done", new GraphNode("Done") }
             };

            // Define transitions (directed edges) between statuses
            nodes["Pending"].Neighbors.Add(nodes["Ongoing"]);
            nodes["Ongoing"].Neighbors.Add(nodes["Done"]);
        }

        public GraphNode GetNode(string status)
        {
            return nodes.ContainsKey(status) ? nodes[status] : null;
        }

        //public void RemoveRequest(string status, ServiceRequest request)
        //{
        //    var node = GetNode(status);
        //    node.RemoveRequest(request);
        //}

        //public void MoveRequest(string requestId, string oldStatus, string newStatus)
        //{
        //    var oldNode = GetNode(oldStatus);
        //    var newNode = GetNode(newStatus);

        //    var request = oldNode.GetRequestById(requestId);
        //    if (request != null)
        //    {
        //        oldNode.RemoveRequest(request);
        //        newNode.AddRequest(request);
        //    }
        //}
    }
}
