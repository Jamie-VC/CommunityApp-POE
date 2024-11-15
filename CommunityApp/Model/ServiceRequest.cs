using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Model
{
    public class ServiceRequest
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string Description { get; set; }

        public ServiceRequest(int id, string status, DateTime dateSubmitted, string description)
        {
            ID = id;
            Status = status;
            DateSubmitted = dateSubmitted;
            Description = description;
        }

        // Method to update status
        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }

    }
}

//    public class BSTNode
//{
//    public ServiceRequest Data { get; set; }
//    public BSTNode Left { get; set; }
//    public BSTNode Right { get; set; }

//    public BSTNode(ServiceRequest data)
//    {
//        Data = data;
//        Left = null;
//        Right = null;
//    }
//}

//public class ServiceRequestBST
//{
//    private BSTNode root;

//    // Method to update the status of a specific request
//    public bool UpdateRequestStatus(int requestId, string newStatus)
//    {
//        var request = Search(requestId); // Use the Search method to find the request
//        if (request != null)
//        {
//            request.UpdateStatus(newStatus);
//            return true; // Successfully updated
//        }
//        return false; // Request not found
//    }

//    public void Insert(ServiceRequest request)
//    {
//        root = InsertRec(root, request);
//    }

//    private BSTNode InsertRec(BSTNode node, ServiceRequest request)
//    {
//        if (node == null)
//            return new BSTNode(request);

//        if (request.ID < node.Data.ID)
//            node.Left = InsertRec(node.Left, request);
//        else if (request.ID > node.Data.ID)
//            node.Right = InsertRec(node.Right, request);

//        return node;
//    }

//    public ServiceRequest Search(int requestId)
//    {
//        return SearchRec(root, requestId);
//    }

//    private ServiceRequest SearchRec(BSTNode node, int requestId)
//    {
//        if (node == null || node.Data.ID == requestId)
//            return node?.Data;

//        if (requestId < node.Data.ID)
//            return SearchRec(node.Left, requestId);
//        else
//            return SearchRec(node.Right, requestId);
//    }

//    // Optional: In-order traversal to retrieve all service requests in sorted order
//    public void InOrderTraversal(Action<ServiceRequest> action)
//    {
//        InOrderTraversalRec(root, action);
//    }

//    private void InOrderTraversalRec(BSTNode node, Action<ServiceRequest> action)
//    {
//        if (node != null)
//        {
//            InOrderTraversalRec(node.Left, action);
//            action(node.Data);
//            InOrderTraversalRec(node.Right, action);
//        }
//    }
//}
//}
