using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace MyProject.Model
{
    public class Patient : IObjectWithState
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public ObjectState ObjectState { get; set; }
        
    }
}
