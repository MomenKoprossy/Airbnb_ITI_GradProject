using App.Repository.ApiClient;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
     public class UserRepository
    {
        private readonly IWebApiExecuter webApiExecuter;

         public UserRepository (IWebApiExecuter webApiExecuter) //implementing the dependency injection 
        {
            this.webApiExecuter = webApiExecuter;
        }
        public async Task<IEnumerable<User>> Get()
        {
            return await webApiExecuter.InvokeGet<IEnumerable<User>>("api/users");
        }
    }
}
