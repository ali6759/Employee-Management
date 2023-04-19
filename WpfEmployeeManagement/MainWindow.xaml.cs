using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Models;

namespace WpfEmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeDataAccess EmployeeDataAccess = new EmployeeDataAccess();

        ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();

        public  Employee currentEmployee { get; set; } = new Employee();
        

        public MainWindow()
        {
            InitializeComponent();
            fillData();
            EmployeesGrid.ItemsSource = Employees;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);

        }

        private void fillData()
        {

            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5121/api/");
                var responseTask = client.GetAsync("Employees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Employee[]>();
                    readTask.Wait();

                    var employees = readTask.Result;
                    Employees = new ObservableCollection<Employee>();
                    foreach (var employee in employees)
                    {
                        Employees.Add(employee);
                    }
                }
            }

            //Employees = EmployeeDataAccess.Employees;
        }
             

        private void btnEmployes_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchEmployee search = new SearchEmployee();
            search.ShowDialog();
        }

        private void EmployeesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(EmployeesGrid.SelectedIndex>= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                EmployeeLable.Content = currentEmployee.GetBasicInfo();
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployee addwindow = new AddEditEmployee(EmployeeDataAccess);
            addwindow.ShowDialog();
            this.fillData();
            EmployeesGrid.ItemsSource = Employees;
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
               currentEmployee= EmployeesGrid.SelectedItem as Employee;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5121/api/");
                    var postTask = client.DeleteAsync($"Employees/{currentEmployee.Id}");
                    postTask.Wait();

                    var result = postTask.Result;
                }
                //EmployeeDataAccess.RemoveEmployee(currentEmployee.Id);
                EmployeeLable.Content = "---";
                this.fillData();
                EmployeesGrid.ItemsSource = Employees;
            }
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesGrid.SelectedItem as Employee;
                AddEditEmployee addwindow = new AddEditEmployee(EmployeeDataAccess,currentEmployee);
                addwindow.ShowDialog();
                this.fillData();
                EmployeesGrid.ItemsSource = Employees;
            }
        }
    }
}
