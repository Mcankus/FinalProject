using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.DataLayer
{
    public class PatientConfiguration : EntityTypeConfiguration<Patient>
    {

        public PatientConfiguration()
        {
            Property(p => p.FirstName).HasMaxLength(25).IsRequired();
            Property(p => p.LastName).HasMaxLength(30).IsRequired();
            Property(p => p.Street).HasMaxLength(50).IsOptional();
            Property(p => p.City).HasMaxLength(25).IsOptional();
            Property(p => p.State).HasMaxLength(2).IsOptional();
            Property(p => p.ZipCode).HasMaxLength(5).IsOptional();
            Property(p => p.PhoneNumber).HasMaxLength(12).IsOptional();
            Ignore(p=>p.ObjectState);

        }
    }
}
 