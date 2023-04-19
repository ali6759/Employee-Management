using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UserDataAccess
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + "DemoDBUser.csv";
        public ObservableCollection<User> users { get; set; } = new ObservableCollection<User>();
        public UserDataAccess()
        {
            ReadUsers();
        }
        private void ReadUsers()
        {
            using (var reader = new StreamReader(path))
            {
                users.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    User us = new User()
                    {
                        Username = values[0],
                        Password = values[1]
                    };

                    users.Add(us);
                }
            }
        }

        public User Login(User user)
        {
            User us = users.FirstOrDefault(c => c.Username == user.Username && c.Password == user.Password);
            return us;
        }
    }
}
