using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Models;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Net.Http;

namespace WpfEmployeeManagement
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private EmployeeDataAccess employeeDataAccess ;
        private Employee editingEmployee;
        private bool isEdit = false;

        public AddEditEmployee(EmployeeDataAccess empDataAccess)
        {
            InitializeComponent();
            employeeDataAccess= empDataAccess;
        }
          public AddEditEmployee(EmployeeDataAccess empDataAccess,Employee emp)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
            editingEmployee = emp;
            isEdit = true;
            tbFirstName.Text = editingEmployee.FirstName;
            tbLastName.Text = editingEmployee.LastName;
            tbPhoneNumber.Text = editingEmployee.PhoneNumber.ToString();
            tbAddress.Text = editingEmployee.Address;
            tbSalary.Text = editingEmployee.BaseSalary.ToString();
            comboDepartment.SelectedIndex = (int) editingEmployee.Department;
        }
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            isValid= CheckEmployeeValidity();
            if (isValid) 
            {
                if (isEdit)
                {
                    Employee emp = new Employee()
                    {
                        Id = editingEmployee.Id,
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                        BaseSalary = Convert.ToDecimal(tbSalary.Text),
                        Department = (Department)comboDepartment.SelectedIndex
                    };
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:5121/api/");
                        var postTask = client.PutAsJsonAsync<Employee>("Employees", emp);
                        postTask.Wait();

                        var result = postTask.Result;
                    }
                    //employeeDataAccess.EditEmployee(emp);

                }
                else
                {
                    Employee emp = new Employee()
                    {                        
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        Address = tbAddress.Text,
                        BaseSalary = Convert.ToDecimal(tbSalary.Text),
                        Department = (Department)comboDepartment.SelectedIndex
                    };

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:5121/api/");
                        var postTask = client.PostAsJsonAsync<Employee>("Employees", emp);
                        postTask.Wait();

                        var result = postTask.Result;
                    }

                    //employeeDataAccess.AddEmployee(emp);

                }
                
                this.Close();
            }
        
        }

      private bool CheckEmployeeValidity()
        {
            bool isValid = true;
            string FirstName = tbFirstName.Text.Trim().ToLower();
            string LastName = tbLastName.Text.Trim().ToLower();
            string PhoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            string Address = tbAddress.Text.Trim().ToLower();
            int Department = comboDepartment.SelectedIndex;
            string BaseSalary = tbSalary.Text.Trim().ToLower();  
            
            if(string.IsNullOrEmpty(FirstName))
            { 
                isValid= false;
                lblErroe.Content = "**First Name is invalid!";
            }

            else if (string.IsNullOrEmpty(LastName))
            {
                isValid = false;
                lblErroe.Content = "**Last Name is invalid!";
            }

           else if(!UInt64.TryParse(PhoneNumber, out ulong p)) 
            {
                isValid = false;
                lblErroe.Content = "**PhoneNumber is invalid!";
            }
            else if(Address.Contains("Toronto")) 
            {
                isValid = true;
                lblErroe.Content = "**Toronto is invalid!";
            }
            else if (Department < 0)
            {
                isValid = false;
                lblErroe.Content = "**Please select a Department!";
            }
            else if (!decimal.TryParse(BaseSalary,out decimal b) || b > 4000)
            {
                isValid = false;
                lblErroe.Content = "**Salary is incorrect!";
            }
            else
            {
                lblErroe.Content = "";
            }

            return isValid;
        }

        private void tbPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string PhoneNumber = tbPhoneNumber.Text.Trim().ToLower();
              if (!UInt64.TryParse(PhoneNumber, out ulong p))
            {
                lblErroe.Content = "**PhoneNumber is invalid!";
            }
              else
            {
                lblErroe.Content = "";
            }
        }
    }
}
