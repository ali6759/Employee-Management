using DataAccess.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfEmployeeManagement
{
    /// <summary>
    /// Interaction logic for SearchEmployee.xaml
    /// </summary>
    public partial class SearchEmployee : Window
    {
        public SearchEmployee()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5121/api/");
                var responseTask = client.GetAsync($"Employees/{txtEmployeeName.Text}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Employee>();
                    readTask.Wait();

                    var employee = readTask.Result;
                    if (employee != null)
                    {
                        lblEmployee.Content = employee.GetBasicInfo();
                    }
                    else
                    {
                        lblEmployee.Content = "Not Found";
                    }
                }
            }
        }
    }
}
