using System;
using System.Linq;
using System.Text.Json;

for (var i = 0; i < 25; i++)
{
    var user = CreateUser();

    var userString = user.ToString();

    // or, if you want JSON:
    // var userString = JsonSerializer.Serialize(user, new JsonSerializerOptions {WriteIndented = true})

    Console.WriteLine(userString);
}

User CreateUser()
{
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


record User
{
    public string FullName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}