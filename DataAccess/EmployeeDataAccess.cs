using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccess.Models;


namespace DataAccess
{
    public class EmployeeDataAccess
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory+"DemoDBEmployees.csv";
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public ObservableCollection<Employee> GetEmployees()
        {
            return this.Employees;
        }

        public EmployeeDataAccess()
        {
            ReadEmployees();
        }
        private void ReadEmployees()
        {
            using (var reader = new StreamReader(path))
            {
                Employees.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');
                    Enum.TryParse(values[5], out Department dept);

                    Employee emp = new Employee()
                    {
                        Id = Convert.ToInt32(values[0]),
                        FirstName = values[1],
                        LastName = values[2],
                        PhoneNumber = Convert.ToUInt64(values[3]),
                        Address = values[4],
                        Department = dept,
                        BaseSalary = Convert.ToDecimal(values[6]),
                    };

                    Employees.Add(emp);
                }
            }
        }
        private void SaveEmployees()
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (Employee emp in Employees)
                {

                       string Id = emp.Id.ToString();
                       string FirstName = emp.FirstName;
                       string LastName = emp.LastName;
                       string PhoneNumber = emp.PhoneNumber.ToString();
                       string Address = emp.Address;
                       string Department = emp.Department.ToString();
                       string BaseSalary = emp.BaseSalary.ToString();

                       string line = string.Format("{0};{1};{2};{3};{4};{5};{6}",
                        Id, FirstName, LastName, PhoneNumber, Address, Department, BaseSalary); 
                    writer.WriteLine(line);
                    }

                
            }
        }
    
        public Employee GetEmployeeByName(string name)
        {
            Employee emp=Employees.FirstOrDefault(c=>c.FirstName==name);
            return emp;
        }

        public void AddEmployee(Employee emp)
        {
            emp.Id = this.GetNextId();
            Employees.Add(emp);
            SaveEmployees();
        }

        public void RemoveEmployee(int id)
        {
            
            Employee temp = Employees.First(x=> x.Id==id);
            Employees.Remove(temp);
            SaveEmployees();
        }

        public void EditEmployee(Employee emp)
        {
            Employee temp = Employees.First(x => x.Id == emp.Id);
            int index = Employees.IndexOf(temp);
            Employees[index] = emp;
            SaveEmployees();
        }

        public int GetNextId()
        {
            int index = Employees.Any() ? Employees.Max(x => x.Id) + 1 : 1; 
            return index;
        }

    }
}
