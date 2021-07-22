using App.Repository;
using App.Repository.ApiClient;
using System.Threading.Tasks;
using System;
using System.Net.Http;

HttpClient httpClient = new();
IWebApiExecuter apiExecuter = new WebApiExecuter("https://localhost:44351/", httpClient);
await GetUsers();

async Task GetUsers()
{
    UserRepository repository = new(apiExecuter);
    var users = await repository.Get();
    foreach(var user in users)
    {
        Console.WriteLine($"Users: {user.Fname}");
    }
}