using System;
using System.Collections.Generic;
using System.Linq;
using ExpensesAPI.DataManagers;
using ExpensesAPI.Models;

namespace ExpensesAPI.Managers
{
    public abstract class UserManager
    {
        public static List<User> GetUsers()
        {
            return UserDataManager.GetUsers();
        }

        public static User GetUserByID(int userId)
        {
            return GetUsers()
                   .FirstOrDefault(item => item.ID == userId);
        }

        public static long InsertUser(User user)
        {
            return UserDataManager.InsertUser(user);
        }

        public static long UpdataUser(User user)
        {
            return UserDataManager.UpdateUser(user);
        }
    }
}

