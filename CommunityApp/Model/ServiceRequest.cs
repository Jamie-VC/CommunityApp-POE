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
        //public ServiceRequest(string iD, string name, string description, string status, DateTime date)
        //{
        //    ID = iD;
        //    Name = name;
        //    Description = description;
        //    Status = status;
        //    Date = date;
        //}

        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status {  get; set; }
        public DateTime Date { get; set; }
        
    }
}
