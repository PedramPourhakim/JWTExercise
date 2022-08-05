using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users 
            = new List<UserModel>()
        {
            new UserModel()
            {
                UserName="EnemyOfLaziness",EmailAddress="Shemuel1226@gmail.com",
                Password="1",GivenName="Pedram",Surname="Pourhakim",Role="Administrator"
            },
            new UserModel()
            {
                    UserName="Elon",EmailAddress="pedrampourhakim1999@gmail.com",
                Password="12",GivenName="Elon",Surname="Mask",Role="Seller"
            }
        };
    }
}
