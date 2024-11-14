using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Model
{
    public class User
    {
        public string Name { get; set; }
        public HashSet<string> Interests { get; set; }
        private readonly IssueList _issueList;

        ///////////////////////
        private ServiceRequestGraph serviceRequestGraph;
        public ObservableCollection<ServiceRequest> ServiceRequests { get; set; }

        public User(string name, HashSet<string> interests)
        {
            Name = name;
            Interests = interests;
            _issueList = new IssueList();

            //InitializeGraph();
            //ServiceRequests = new ObservableCollection<ServiceRequest>();
        }

        public IEnumerable<Issue> GetAllIssues()
        {
            return _issueList.GetAllIssues();
        }
        public void ReportIssue(Issue issue)
        {
            _issueList.AddIssue(issue);
        }

        ////////////////////////////////
        public void InitializeGraph()
        {
            serviceRequestGraph = new ServiceRequestGraph();

            // Add mock data
            var request1 = new ServiceRequest { ID = "SR001", Description = "Fix printer", Status = "Pending", Date = DateTime.Now.AddDays(-5) };
            var request2 = new ServiceRequest { ID = "SR002", Description = "Setup PC", Status = "Ongoing", Date = DateTime.Now.AddDays(-2) };
            var request3 = new ServiceRequest { ID = "SR003", Description = "Update payroll", Status = "Done", Date = DateTime.Now };

            serviceRequestGraph.GetNode("Pending").AddRequest(request1);
            serviceRequestGraph.GetNode("Ongoing").AddRequest(request2);
            serviceRequestGraph.GetNode("Done").AddRequest(request3);
        }

        //private void DisplayServiceRequests(string status)
        //{
        //    var node = serviceRequestGraph.GetNode(status);
        //    if (node != null)
        //    {
        //        ServiceRequestDataGrid.ItemsSource = node.GetAllRequests();
        //    }
        //}

        public IEnumerable<ServiceRequest> GetServiceRequests(string status)
        {
            var node = serviceRequestGraph.GetNode(status);
            if (node != null)
            {
                foreach (var serviceRequest in node.GetAllRequests())
                {
                    ServiceRequests.Add(serviceRequest);
                }
            }
            return ServiceRequests;
        }
    }
}
