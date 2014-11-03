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
      new Doctor { DoctorName = "Dr. Alan Smith", PracticeName = "Alachua Family Health" },
      new Doctor { DoctorName = "Dr. Kevin Ricker", PracticeName = "Alachua Family Health" },
      new Doctor { DoctorName = "Dr. Bruce Dillon", PracticeName = "Alachua Family Health" },
      new Doctor { DoctorName = "Dr. Amy Merino", PracticeName = "Alachua Family Health" },
      new Doctor { DoctorName = "Dr. Leslie Veech", PracticeName = "GainesVille Health Clinic" },
      new Doctor { DoctorName = "Dr. William Wong", PracticeName = "GainesVille Health Clinic" },
      new Doctor { DoctorName = "Dr. Mark Harden", PracticeName = "Family Medical Services" },
      new Doctor { DoctorName = "Dr. James Grooms", PracticeName = "Jacksonville Health" },
      new Doctor { DoctorName = "Dr. Ginger Wells", PracticeName = "Jacksonville Health" },
      new Doctor { DoctorName = "Dr. Bonnie Tate", PracticeName = "Alachua Family Health" },
      new Doctor { DoctorName = "Dr. Jerry Rogers", PracticeName = "Alachua Family Health" }

      );
       
        }
    }
}
