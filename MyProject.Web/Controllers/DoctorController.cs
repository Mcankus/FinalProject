using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MyProject.Model;
using MyProject.DataLayer;
using MyProject.Web.ViewModels;

namespace MyProject.Web.Controllers
{
    public class DoctorController : Controller
    {
        private DoctorContext doctorContext;

        public DoctorController()
        {
            doctorContext = new DoctorContext();
        }
        //
        // GET: /Doctor/

        public ActionResult Index()
        {
            return View(doctorContext.Doctors.ToList());
        }

        //
        // GET: /Doctor/Details/5

        public ActionResult Details(int? id)
        {
            Doctor doctor = doctorContext.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            

            DoctorViewModel doctorViewModel = ViewModels.Helpers.CreateDoctorViewModelFromDoctor(doctor);

           

            return View(doctorViewModel);
        }

        //
        // GET: /Doctor/Create

        public ActionResult Create()
        {
            DoctorViewModel doctorViewModel = new DoctorViewModel();
            doctorViewModel.ObjectState = ObjectState.Added;
            return View(doctorViewModel);
        }

     

        //
        // GET: /Doctor/Edit/5

        public ActionResult Edit(int? id)
        {
            Doctor doctor = doctorContext.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            DoctorViewModel doctorViewModel = ViewModels.Helpers.CreateDoctorViewModelFromDoctor(doctor);
            
            doctorViewModel.MessageToClient = string.Format("The original Doctor name is {0}.", doctorViewModel.DoctorName);
            //doctorViewModel.ObjectState = ObjectState.Unchanged;//you changed this
          
            

            return View(doctorViewModel);
        }

  
        //
        // GET: /Doctor/Delete/5

        public ActionResult Delete(int? id)
        {
            Doctor doctor = doctorContext.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            DoctorViewModel doctorViewModel = ViewModels.Helpers.CreateDoctorViewModelFromDoctor(doctor);
         
            doctorViewModel.MessageToClient = string.Format("You are about to permenantly delete this doctor!");
            doctorViewModel.ObjectState = ObjectState.Deleted;  

            return View(doctorViewModel);

        }

        //
        // POST: /Doctor/Delete/5

     

        protected override void Dispose(bool disposing)
        {
            doctorContext.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult Save(DoctorViewModel doctorViewModel)
        {
            Doctor doctor = ViewModels.Helpers.CreateDoctorFromDoctorViewModel(doctorViewModel);

            doctorContext.Doctors.Attach(doctor);
            if (doctor.ObjectState == ObjectState.Deleted)
            {
                foreach (PatientViewModel patientViewModel in doctorViewModel.Patients)
                {
                    Patient patient = doctorContext.Patients.Find(patientViewModel.PatientId);

                    if (patient != null)
                    {
                        patient.ObjectState = ObjectState.Deleted;
                    }
                }
            }
            else
            {

                foreach (int patientId in doctorViewModel.PatientsToDelete)
                {
                    Patient patient = doctorContext.Patients.Find(patientId);

                    if (patient != null)
                    {
                        patient.ObjectState = ObjectState.Deleted;
                    }
                }
            }

            doctorContext.ApplyStateChanges();
            doctorContext.SaveChanges();

            if (doctor.ObjectState == ObjectState.Deleted)
                return Json(new {newLocation = "/Doctor/Index"});

            string messageToClient = ViewModels.Helpers.GetMessageToClient(doctorViewModel.ObjectState, doctor.DoctorName);

            doctorViewModel = ViewModels.Helpers.CreateDoctorViewModelFromDoctor(doctor);
            doctorViewModel.MessageToClient = messageToClient;
          
       
            

            return Json(new {doctorViewModel});

        }
    }
}