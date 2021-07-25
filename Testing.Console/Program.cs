using App.Repository;
using App.Repository.ApiClient;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Data.Model;

HttpClient httpClient = new();
IWebApiExecuter apiExecuter = new WebApiExecuter("https://localhost:44351", httpClient);

var user = await GetUser(8);
Console.WriteLine("Create a user");
await DeleteUser(9);
await GetUsers();

async Task GetUsers()
{
    UserRepository repository = new(apiExecuter);
    var users = await repository.GetAsync();
    foreach (var user in users)
    {
        Console.WriteLine($"Users: {user.Fname}");
    }
}

async Task<User> GetUser(int id)
{
    UserRepository repository = new(apiExecuter);
    
    var user = await repository.GetByIdAsync(id);
    Console.WriteLine(user.Fname);
    return user;

}


async Task<int> CreateUser()
{
    Console.WriteLine("Test1");
    var user = new User { Fname = "user2" ,Lname = "user2" ,
        Phone =111,Email= "user@a.a" , Verified = true , Image="asas" , Gender= "male" , Country= "Egypt",
    City="alex" , Street = "asd"};
    Console.WriteLine("Test2");
    UserRepository repository = new(apiExecuter);
     return await repository.CreateAsync(user);
}
async Task UpdateUser(User user)
{
    UserRepository repository = new(apiExecuter);
    user.Fname += "updated";
    await repository.UpdateAsync(user);

}

async Task DeleteUser(int id)
{
    UserRepository repository = new(apiExecuter);
    await repository.DeleteAsync(id);

}