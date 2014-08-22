using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Database;

namespace CoreService
{
    public class UsersService : IUsersService
    {
        private readonly GeekEntities _database;
        public UsersService()
        {
            _database=new GeekEntities();
        }
        ~UsersService()
        {
            //закрываем соединение с базой
            _database.Dispose();
        }
    }
}
