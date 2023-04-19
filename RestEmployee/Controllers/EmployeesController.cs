using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace RestEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //get employees
        [HttpGet]   
        public ObservableCollection<Employee> GetEmployees()
        {
            EmployeeDataAccess access = new EmployeeDataAccess();
            var employees = access.GetEmployees();
            return employees;
        }

        [HttpGet("{name}")]
        public Employee GetEmployeeByName(string name)
        {
            EmployeeDataAccess access = new EmployeeDataAccess();
            var employee = access.GetEmployeeByName(name);
            return employee;
        }

        [HttpPost]
        public void AddEmployee(Employee emp)
        {
            EmployeeDataAccess access = new EmployeeDataAccess();
            access.AddEmployee(emp);
        }

        [HttpPut]
        public void EditEmployee(Employee emp)
        {
            EmployeeDataAccess access = new EmployeeDataAccess();
            access.EditEmployee(emp);
        }

        [HttpDelete("{id}")]
        public void RemoveEmployee(int id)
        {
            EmployeeDataAccess access = new EmployeeDataAccess();
            access.RemoveEmployee(id);
        }
    }
}
