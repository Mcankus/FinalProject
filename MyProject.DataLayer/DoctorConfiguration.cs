using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.DataLayer
{
    class DoctorConfiguration : EntityTypeConfiguration<Doctor>
    {

        public DoctorConfiguration()
        {
            Property(d => d.DoctorName).HasMaxLength(30).IsRequired();
            Property(d => d.PracticeName).HasMaxLength(30).IsOptional();
            Property(d => d.Photo).HasMaxLength(20).IsOptional();
            Ignore(d=> d.ObjectState);
        }
    }
}