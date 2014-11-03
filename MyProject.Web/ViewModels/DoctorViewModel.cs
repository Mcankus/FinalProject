using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Model;

namespace MyProject.Web.ViewModels
{
    public class DoctorViewModel : IObjectWithState
    {

        public string DoctorName { get; set; }
        public string PracticeName { get; set; }
        public int DoctorId { get; set; }

        public string MessageToClient { get; set; }




        public ObjectState ObjectState { get; set; }
  
    }
}