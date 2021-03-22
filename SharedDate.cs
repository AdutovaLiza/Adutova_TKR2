using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adutova_TKR2.Models;


namespace Adutova_TKR2
{
    public static class SharedDate
    {
        public static List<User> Users { get; } = new List<User>
        {
            new User(){ Login = "user", Password = "user" },
            new User(){ Login = "admin", Password = "admin" },
        };
    }
}
