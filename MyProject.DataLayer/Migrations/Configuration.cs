using MyProject.Model;


namespace MyProject.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyProject.DataLayer.DoctorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyProject.DataLayer.DoctorContext context)
        {
            context.Doctors.AddOrUpdate(
      d => d.DoctorName,
      new Doctor { DoctorName = "Dr. Alan Smith", PracticeName = "Alachua Family Health", Photo ="doctor-1.jpg", Patients =
      {
          new Patient{FirstName = "Robert", LastName = "Green", Street = "123 Main St.", City = "Alachua", State = "FL", ZipCode = "34567", PhoneNumber = "456-989-0909"},
          new Patient{FirstName = "Amy", LastName = "Bridgers", Street = "47 Elm St.", City = "Alachua", State = "FL", ZipCode = "34562", PhoneNumber = "555-56-5968"}
      }},
     new Doctor { DoctorName = "Dr. Kevin Ricker", PracticeName = "Alachua Family Health", Photo ="doctor-5.jpg"  },
      new Doctor { DoctorName = "Dr. Bruce Dillon", PracticeName = "Alachua Family Health", Photo = "doctor-4.jpg" },
      new Doctor { DoctorName = "Dr. Amy Merino", PracticeName = "Alachua Family Health", Photo = "doctor-6.jpg" },
      new Doctor { DoctorName = "Dr. Leslie Veech", PracticeName = "Gainesville Health Clinic", Photo = "doctor-3.jpg" },
      new Doctor { DoctorName = "Dr. William Wong", PracticeName = "Gainesville Health Clinic", Photo = "doctor-1.jpg" },
      new Doctor { DoctorName = "Dr. Mark Harden", PracticeName = "Family Medical Services", Photo = "doctor-4.jpg" },
      new Doctor { DoctorName = "Dr. James Grooms", PracticeName = "Jacksonville Health", Photo = "doctor-5.jpg" },
      new Doctor { DoctorName = "Dr. Ginger Wells", PracticeName = "Jacksonville Health", Photo = "doctor-2.jpg" },
      new Doctor { DoctorName = "Dr. Bonnie Tate", PracticeName = "Alachua Family Health", Photo = "doctor-3.jpg" },
      new Doctor { DoctorName = "Dr. Jerry Rogers", PracticeName = "Alachua Family Health", Photo = "doctor-1.jpg" }

      );
       
        }
    }
}
