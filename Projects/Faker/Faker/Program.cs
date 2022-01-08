using System;
using Faker;
using Faker.Resources;
using Newtonsoft.Json;

namespace FakerDemo
{    
    internal class Program
    {
        class User
        {
            public string FullName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        static void Main(string[] args)
        {
            string json = JsonConvert.SerializeObject(CreateUser());
            Console.WriteLine(json);
        }

        private static User CreateUser()
        {
            User user = new User();
            user.FullName = Faker.Name.FullName();
            // Check if FullName contains Prof, Dr. Mr. Mrs. or Miss If so remove those.
            if (user.FullName.Contains("Prof.") || user.FullName.Contains("Dr.") || user.FullName.Contains("Mr.") || user.FullName.Contains("Mrs.") || user.FullName.Contains("Miss") || user.FullName.Contains("Ms"))
            {
                user.FirstName = user.FullName.Split(' ')[1];
                // If FullName string contains more then 2 strings concatinate LastName
                if (user.FullName.Length > 3)
                {
                    String message = String.Format("FullName {0} contains more than 1 LastName {1}.", user.FullName, user.FullName.Split(" ").Length);
                    int i = (user.FullName.Split(" ").Length);
                    user.LastName = string.Concat(user.FullName.Split(' ')[2..i]);
                }
                else
                {
                    user.LastName = user.FullName.Split(' ')[2];
                }
                
            }
            else
            {
                user.FirstName = user.FullName.Split(' ')[0];
                if (user.FullName.Length > 2)
                {
                    int i = (user.FullName.Split(" ").Length);
                    user.LastName = string.Concat(user.FullName.Split(' ')[1..i]);
                }
                else
                {
                    user.LastName = user.FullName.Split(' ')[1];
                }
                
            };
            
            return user;
        }
    }

    
}
