using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CommunityApp.Model
{
    public class TreeNode
    {
        public ServiceRequest Data;
        public TreeNode Left, Right;

        public TreeNode(ServiceRequest data)
        {
            Data = data;
            Left = Right = null;
        }
    }
    public class BinarySearchTree
    {
        private TreeNode root;

        // Insert a new service request into the BST
        public void Insert(ServiceRequest request)
        {
            root = InsertRec(root, request);
        }

        private TreeNode InsertRec(TreeNode root, ServiceRequest request)
        {
            if (root == null)
                return new TreeNode(request);

            if (request.ID < root.Data.ID)
                root.Left = InsertRec(root.Left, request);
            else if (request.ID > root.Data.ID)
                root.Right = InsertRec(root.Right, request);

            return root;
        }

        // Retrieve a service request by ID
        public ServiceRequest Search(int requestId)
        {
            return SearchRec(root, requestId)?.Data;
        }

        private TreeNode SearchRec(TreeNode root, int requestId)
        {
            if (root == null || root.Data.ID == requestId)
                return root;

            if (requestId < root.Data.ID)
                return SearchRec(root.Left, requestId);

            return SearchRec(root.Right, requestId);
        }

        // In-order traversal to display all service requests
        //public void InOrderTraversal(TreeNode node)
        //{
        //    if (node != null)
        //    {
        //        InOrderTraversal(node.Left);
        //        Console.WriteLine($"Request ID: {node.Data.ID}, Status: {node.Data.Status}, Description: {node.Data.Description}");
        //        InOrderTraversal(node.Right);
        //    }
        //}
        public void InOrderTraversal(TreeNode root, Action<ServiceRequest> process)
        {
            if (root == null) return;

            // Traverse the left subtree
            InOrderTraversal(root.Left, process);

            // Process the current node
            process(root.Data);

            // Traverse the right subtree
            InOrderTraversal(root.Right, process);
        }

        public TreeNode GetRoot()
        {
            return root;
        }
    }
}
