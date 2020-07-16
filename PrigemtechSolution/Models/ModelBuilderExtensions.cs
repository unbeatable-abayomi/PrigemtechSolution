using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrigemtechSolution.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                 new Employee() { Id = 1, Name = "Abayomi", Email = "grace@mail.com", Deparment = Dept.IT },
               new Employee() { Id = 2, Name = "comfort", Email = "prue@mail.com", Deparment = Dept.HR },
               new Employee() { Id = 3, Name = "adekunle", Email = "kunle@mail.com", Deparment = Dept.Payroll }
               );
        }
    }
}
