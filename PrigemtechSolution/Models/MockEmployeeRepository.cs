using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrigemtechSolution.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            //_employeeList = new List<Employee>()
            //{
            //    new Employee(){Id=1,Name = "Abayomi", Email = "grace@mail.com", Deparment="support"},
            //    new Employee(){Id=2,Name = "comfort", Email = "prue@mail.com", Deparment="database"},
            //    new Employee(){Id=3,Name = "adekunle", Email = "kunle@mail.com", Deparment="development"}

            //};
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1,Name = "Abayomi", Email = "grace@mail.com"},
                new Employee(){Id=2,Name = "comfort", Email = "prue@mail.com"},
                new Employee(){Id=3,Name = "adekunle", Email = "kunle@mail.com"}

            };
        }
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList.ToList();
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

       public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Deparment = employeeChanges.Deparment;

            }
            return employee;
        }

       public Employee Delete(int Id)
        {
         Employee employee =  _employeeList.FirstOrDefault(e => e.Id == Id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
               
            }
            return employee;
        }
    }
}
