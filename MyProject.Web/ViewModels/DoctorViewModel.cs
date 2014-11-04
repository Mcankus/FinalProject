using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Model;

namespace MyProject.Web.ViewModels
{
    public class DoctorViewModel : IObjectWithState
    {
        public DoctorViewModel()
        {
            Patients = new List<PatientViewModel>();
            PatientsToDelete = new List<int>();
        }

        public string DoctorName { get; set; }
        public string PracticeName { get; set; }
        public int DoctorId { get; set; }
        public string Photo { get; set; }

        public string MessageToClient { get; set; }




        public ObjectState ObjectState { get; set; }

        public  List<PatientViewModel> Patients { get; set; }

        public List<int> PatientsToDelete { get; set; } 
  
    }
}