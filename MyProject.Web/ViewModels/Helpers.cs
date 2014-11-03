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


            return doctorViewModel;


        }

        public static Doctor CreateDoctorFromDoctorViewModel(DoctorViewModel doctorViewModel)
        {
            Doctor doctor = new Doctor();
            doctor.DoctorId = doctorViewModel.DoctorId;
            doctor.DoctorName = doctorViewModel.DoctorName;
            doctor.PracticeName = doctorViewModel.PracticeName;

            return doctor;
        }

        public static string GetMessageToClient(ObjectState objectState, string doctorName)
        {
            string messageToClient = string.Empty;
            switch (objectState)
            {
                case ObjectState.Added:
                    messageToClient = string.Format("{0} has been added to the database", doctorName);
                    break;

                case ObjectState.Modified:
                   messageToClient = string.Format("The doctors name has been updated to {0} in the database.", doctorName);
                    break;

            }
            return messageToClient;
        }
    }
}