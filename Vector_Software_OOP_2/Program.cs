using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Vector_Software_OOP_2
{
    public enum UserStatus
    {
        Online,
        Offline,
        Away
    }
    public class User
    {
        public string Username;
        public UserStatus Status;
        public int LastActivity;
        public bool IsExistConnection;
        public User(string username, bool isExistConnection, int lastActivity)
        {
            Username = username;
            IsExistConnection = isExistConnection;
            LastActivity = lastActivity;
        }

        public string GetName()
        {
            return Username;
        }
        public UserStatus GetUserStatus()
        {
            if (IsExistConnection == true)
            {
                if (LastActivity > 10)
                {
                    return UserStatus.Away;
                }
                return UserStatus.Online;
            }
            return UserStatus.Offline;
        }
    }

    class Program
    {
        public static Dictionary<UserStatus, IEnumerable<string>> UserActivity(User[] users)
        {
            Dictionary<UserStatus, IEnumerable<string>> result = new Dictionary<UserStatus, IEnumerable<string>>();
            for (int i = 0; i < users.Length; i++)
            {
                if (result.ContainsKey(users[i].GetUserStatus()))
                    result[users[i].GetUserStatus()] = result[users[i].GetUserStatus()].Concat<string>(new[] {users[i].GetName()});
                else
                {
                    result[users[i].GetUserStatus()] = new [] {users[i].GetName()};
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            User[] users = new User[]
            {
             new User("David", true, 9),
             new User("Luc", false, 2),
             new User("Bob", true, 14),
             new User("Mark", true, 2)
            };

            Dictionary<UserStatus, IEnumerable<string>> res = UserActivity(users);
            foreach (var item in res.Keys)
            {
                Console.WriteLine(item);
                Console.WriteLine(string.Join(", ",res[item]));
            }

        }
    }
}
