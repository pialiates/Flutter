using SignalRServer.Models;

using System;
using System.Collections.Generic;

namespace SignalRServer.DataProviders
{
    public class StaticDatas
    {
        public static List<User> Users = new List<User>()
        {
            new User(){Id = Guid.NewGuid(), Username = "deneme", Password = "123"},
        };
    }
}
