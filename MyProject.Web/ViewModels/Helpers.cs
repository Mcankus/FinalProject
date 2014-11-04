using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Model;

namespace MyProject.Web.ViewModels
{
    public class Helpers
    {

        public static DoctorViewModel CreateDoctorViewModelFromDoctor(Doctor doctor)
        {
            DoctorViewModel doctorViewModel = new DoctorViewModel();
            doctorViewModel.DoctorId = doctor.DoctorId;
            doctorViewModel.DoctorName = doctor.DoctorName;
            doctorViewModel.PracticeName = doctor.PracticeName;
            doctorViewModel.Photo = doctor.Photo;
            doctorViewModel.ObjectState = ObjectState.Unchanged;

            foreach (Patient patient in doctor.Patients)
            {
                PatientViewModel patientViewModel = new PatientViewModel();
                patientViewModel.PatientId = patient.PatientId;
                patientViewModel.FirstName = patient.FirstName;
                patientViewModel.LastName = patient.LastName;
                patientViewModel.Street = patient.Street;
                patientViewModel.City = patient.City;
                patientViewModel.State = patient.State;
                patientViewModel.ZipCode = patient.ZipCode;
                patientViewModel.PhoneNumber = patient.PhoneNumber;

                patientViewModel.ObjectState = ObjectState.Unchanged;

                patientViewModel.DoctorId = patient.DoctorId;
                doctorViewModel.Patients.Add(patientViewModel);
            }


            return doctorViewModel;


        }

        public static Doctor CreateDoctorFromDoctorViewModel(DoctorViewModel doctorViewModel)
        {
            Doctor doctor = new Doctor();
            doctor.DoctorId = doctorViewModel.DoctorId;
            doctor.DoctorName = doctorViewModel.DoctorName;
            doctor.PracticeName = doctorViewModel.PracticeName;
            doctor.Photo = doctorViewModel.Photo;
            doctor.ObjectState = doctorViewModel.ObjectState;

            int temporaryPatientId = -1;

            foreach (PatientViewModel patientViewModel in doctorViewModel.Patients)
            {
                Patient patient = new Patient();
                patient.FirstName = patientViewModel.FirstName;
                patient.LastName = patientViewModel.LastName;
                patient.Street = patientViewModel.Street;
                patient.City = patientViewModel.City;
                patient.State = patientViewModel.State;
                patient.ZipCode = patientViewModel.ZipCode;
                patient.PhoneNumber = patientViewModel.PhoneNumber;
                patient.ObjectState = patientViewModel.ObjectState;


                if (patientViewModel.ObjectState != ObjectState.Added)
                    patient.PatientId = patientViewModel.PatientId;
                else
                {
                    patientViewModel.PatientId = temporaryPatientId;
                    temporaryPatientId--;
                }
                patient.DoctorId = doctorViewModel.DoctorId;

                doctor.Patients.Add(patient);



            }

            return doctor;
        }

        public static string GetMessageToClient(ObjectState objectState, string doctorName)
        {
            string messageToClient = string.Empty;
            switch (objectState)
            {
                case ObjectState.Added:
                    messageToClient = string.Format("{0}'s has been added the database.", doctorName);
                    break;

                case ObjectState.Modified:
                   messageToClient = string.Format("{0}'s profile has been updated in the database.", doctorName);
                    break;

            }
            return messageToClient;
        }
    }
}