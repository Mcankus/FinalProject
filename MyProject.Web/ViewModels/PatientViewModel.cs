﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Model;

namespace MyProject.Web.ViewModels
{
    public class PatientViewModel : IObjectWithState
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

        public ObjectState ObjectState { get; set; }

        
       
    }
}