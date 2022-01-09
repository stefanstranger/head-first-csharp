using System;
using System.Linq;
using Faker;
using Faker.Resources;
using Newtonsoft.Json;

#nullable enable

namespace FakerDemo
{    
    internal class Program
    {
        
        class User
        {
            public string FullName { get; set; }
            public string FirstName { get; set; }
            public string? LastName { get; set; }
        }        

        static void Main(string[] args)
        {

            string json = JsonConvert.SerializeObject(CreateUser());

            if (args.Length == 0)
            {
                Console.WriteLine(json);
                return;
            }
            var command = args[0];                    

            switch (command)
            {
                case "json":
                    Console.WriteLine(json);
                    break;
                case "csv":
                    dynamic table = JsonConvert.DeserializeObject(json);
                    Console.WriteLine($"FullName;FirstName;LastName");
                    Console.WriteLine($"{table.FullName};{table.FirstName};{table.LastName}");
                    break;
                default:
                    Console.WriteLine(json);
                    break;
            }
        }

        private static object CreateUser()      {
            var fullNameInput = Faker.Name.FullName();

            var titles = new[]
            {
                "Prof",
                "Dr",
                "Mr",
                "Mrs",
                "Miss",
                "Ms",
            };

            var index = 0;
            foreach (var title in titles.OrderByDescending(x => x.Length))
            {
                if (!fullNameInput.StartsWith(title))
                {
                    continue;
                }

                switch (fullNameInput[title.Length])
                {
                    case ' ':
                        index = title.Length + 1;
                        break;
                    case '.':
                        index = title.Length + 2;
                        break;
                    default:
                        continue;
                }

                break;
            }

            var names = fullNameInput[index..].Split(' ');

            var user = new User
            {
                FullName = fullNameInput,
                FirstName = names.First(),
                LastName = string.Join(' ', names.Skip(1))
            };
            return user;
        }
    }    
}
