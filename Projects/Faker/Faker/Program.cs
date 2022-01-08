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
            if (user.FullName.Contains("Prof.") || user.FullName.Contains("Dr.") || user.FullName.Contains("Mr.") || user.FullName.Contains("Mrs.") || user.FullName.Contains("Miss"))
            {
                Console.WriteLine("Containing too much info!");
                String FullName = user.FullName.Replace("Prof.", "");
                Console.Write(FullName);
            }
            user.FirstName = user.FullName.Split(' ')[0];
            user.LastName = user.FullName.Split(' ')[1];
            return user;
        }
    }

    
}
