using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Model
{
    public class ServiceRequestNode
    {
        public ServiceRequest Request { get; set; }
        public ServiceRequestNode Left { get; set; }
        public ServiceRequestNode Right { get; set; }

        public ServiceRequestNode(ServiceRequest request)
        {
            Request = request;
            Left = null;
            Right = null;
        }
    }

    public class ServiceRequestTree
    {
        public ServiceRequestNode Root { get; private set; }

        public void Insert(ServiceRequest request)
        {
            Root = InsertRec(Root, request);
        }

        private ServiceRequestNode InsertRec(ServiceRequestNode root, ServiceRequest request)
        {
            if (root == null)
                return new ServiceRequestNode(request);

            if (string.Compare(request.ID, root.Request.ID) < 0)
                root.Left = InsertRec(root.Left, request);
            else if (string.Compare(request.ID, root.Request.ID) > 0)
                root.Right = InsertRec(root.Right, request);

            return root;
        }

        public ServiceRequest Find(string id)
        {
            return FindRec(Root, id)?.Request;
        }

        private ServiceRequestNode FindRec(ServiceRequestNode root, string id)
        {
            if (root == null || root.Request.ID == id)
                return root;

            if (string.Compare(id, root.Request.ID) < 0)
                return FindRec(root.Left, id);

            return FindRec(root.Right, id);
        }

        public void InOrderTraversal(ServiceRequestNode node, List<ServiceRequest> result)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, result);
                result.Add(node.Request);
                InOrderTraversal(node.Right, result);
            }
        }

        public List<ServiceRequest> GetAllRequests()
        {
            var result = new List<ServiceRequest>();
            InOrderTraversal(Root, result);
            return result;
        }
    }
}
