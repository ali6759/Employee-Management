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
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }        

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtPass.Text!="" && txtUser.Text!="")
            {
                User user = new User()
                {
                    Password = txtPass.Text,
                    Username = txtUser.Text
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5121/api/");
                    var responseTask = client.PostAsJsonAsync($"Users", user);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        var readTask = result.Content.ReadAsAsync<User>();
                        readTask.Wait();

                        var us = readTask.Result;
                        if (us!=null)
                        {
                            MainWindow main = new MainWindow();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            lblUser.Content = "Invalid Username or Password";
                        }

                    }
                }
            }
            else
            {
                lblUser.Content = "Fill in the blank inputs.";
            }
            
        }
    }
}
