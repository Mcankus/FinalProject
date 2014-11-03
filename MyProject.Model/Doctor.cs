using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Model
{
    public class Doctor : IObjectWithState
    {
        public Doctor()
        {
            Patients = new List<Patient>();
        }
        public string DoctorName { get; set; }
        public string PracticeName { get; set; }
        public int DoctorId { get; set; }

        public ObjectState ObjectState { get; set; }

        public virtual List<Patient> Patients { get; set; } 
    }
}