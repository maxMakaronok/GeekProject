using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace ServiceModels.Extensions
{
    public static class  UserExtensions
    {

    public static UserInfo ToUserInfo(this User usr)
    {
        return new UserInfo()
                   {
                       UserId = usr.UserId,
                       FirstName = usr.FirstName,
                       LastName = usr.LastName,
                       FullName = usr.FullName,
                       Login = usr.Login,
                       Email = usr.Email,
                       IsBLocked = usr.IsBLocked,
                       BlockDate = usr.BlockDate,
                       BlockReason = usr.BlockReason,
                       ErrorPinCount = usr.ErrorPinCount,
                       RegistrationDate = usr.RegistrationDate,
                       LastLoginDate = usr.LastLoginDate
                   };
    }

    }
}
