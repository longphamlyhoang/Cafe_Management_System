using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Cafe_Management_System
{
    class User
    {
        private string username;
        private string matKhau;
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return matKhau;
            }
            set
            {
                matKhau = value;
            }
        }
        public static bool Checkusername(string name)
        {
            return Regex.IsMatch(name, "^[a-zA-Z0-9_]{0,9}$");
        }
        public static bool CheckPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
        }
        public static void Register(List<User> user)
        {
            Console.Write("Tên đăng kí: ");
            string name = Console.ReadLine();
            while (Checkusername(name) == false)
            {
                Console.WriteLine("Tên đăng nhập không đúng!");
                Console.Write("Đăng kí lại: ");
                name = Console.ReadLine();
            }
            while (IsNameExist(user, name))
            {
                Console.WriteLine("Tên đăng kí đã có người đăng kí");
                Console.Write("Đăng kí lại: ");
                name = Console.ReadLine();
            }

            Console.Write("Mật khẩu: ");
            string matkhau = Console.ReadLine();
            while (CheckPassword(matkhau) == false)
            {
                Console.WriteLine("Mật khẩu không hợp lệ!");
                Console.Write("Mật khẩu: ");
                matkhau = Console.ReadLine();
            }
            Console.Write("Nhập mật khẩu lại: ");
            string reMatkhau = Console.ReadLine();
            while (matkhau != reMatkhau)
            {
                Console.WriteLine("Mật khẩu không khớp!");
                Console.Write("Nhập lại mật khẩu: ");
                reMatkhau = Console.ReadLine();
            }
            User user1 = new User();
            user1.MatKhau = matkhau;
            user1.UserName = name;
            user.Add(user1);
            HelperUser<User>.WriteFile("user.json", user);
        }
        public static bool IsNameExist(List<User> user, string name)
        {
            foreach (var item in user)
            {
                if (item.username.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IspasswordExist(List<User> user, string password)
        {
            foreach (var item in user)
            {
                if (item.matKhau.Contains(password))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsExistvalue(List<User> user)
        {
            foreach (var item in user)
            {
                if (item != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Login(List<User> user)
        {
            bool Islogin = false;
            bool check = false;
            if (IsExistvalue(user))
            {
                do
                {
                    Console.Write("Nhập tên đăng nhập: ");
                    string name = Console.ReadLine();
                    Console.Write("Nhập mật khẩu: ");
                    string password = Console.ReadLine();
                    bool isNameExist = IsNameExist(user, name);
                    bool ispasswordExist = IspasswordExist(user, password);
                    if (isNameExist)
                    {
                        if (ispasswordExist)
                        {
                            Console.WriteLine("Đăng phập thành công");
                            Islogin = true;
                            check = true;
                        }
                        else
                        {
                            Console.WriteLine("Sai mật khẩu");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tên đăng phập sai");
                    }
                }
                while (check == false);
            }
            else
            {
                Console.WriteLine("chưa có ai đăng phập");
            }
            return Islogin;
        }
    }
}