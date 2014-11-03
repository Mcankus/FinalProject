using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.DataLayer
{
    public class DoctorContext : DbContext
    {

        public DoctorContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DoctorConfiguration());
            modelBuilder.Configurations.Add(new PatientConfiguration());
        }
    }
}

