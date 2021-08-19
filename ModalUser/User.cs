using System;
using System.Collections.Generic;
using System.Text;
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
            return Regex.IsMatch(name, "^[a-zA-Z0-9_]{6,16}$");
        }
        public static bool CheckPassword(string mk)
        {
            return Regex.IsMatch(mk, @"((?=.*\d)(?=.*[a-z]).*[A-Z])(?=.*[!@#$%^&]).{6,20}");
        }
        public static void DangKy(List<User> user)
        {
            Console.WriteLine("hay dien thong tin dang ky!");
            Console.Write("Ten dang nhap: ");
            string name = Console.ReadLine();
            while (Checkusername(name) == false)
            {
                Console.WriteLine("Ten dang nhap khong hop le. Vui long chon ten khac ");
                Console.WriteLine("Ten dang nhap ko duoc dung ky tu dac biet va khoang trang ");
                Console.Write("Ten dang nhap: ");
                name = Console.ReadLine();
            }
            while (IsNameExist(user, name))
            {
                Console.WriteLine("Ten dang nhap da ton tai. Vui long chon ten khac ");
                Console.Write("Ten dang nhap: ");
                name = Console.ReadLine();
            }

            Console.WriteLine("Hay nhap mat khau tren 6 ky tu.Bao gom chu Hoa, thuong, so va ky tu dac biet");
            Console.Write("Mat khau: ");
            string matkhau = Console.ReadLine();
            while (CheckPassword(matkhau) == false)
            {
                Console.WriteLine("Mat khau chua hop le. Vui long nhap lai mat khau");
                Console.WriteLine("Hay nhap mat khau tren 6 ky tu.Bao gom chu Hoa, thuong, so va ky tu dac biet");
                Console.Write("Mat khau: ");
                matkhau = Console.ReadLine();
            }
            Console.Write("Nhap lai mat khau: ");
            string reMatkhau = Console.ReadLine();
            while (matkhau != reMatkhau)
            {
                Console.WriteLine("Mat khau khong trung khop!");
                Console.Write("Vui long nhap lai mat khau: ");
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
        public static bool IsMkExist(List<User> user, string matkhau)
        {
            foreach (var item in user)
            {
                if (item.matKhau.Contains(matkhau))
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
        public static bool DangNhap(List<User> user)
        {
            bool IsDangnhap = false;
            bool check = false;
            if (IsExistvalue(user))
            {
                do
                {
                    Console.Write("Nhap ten dang nhap:");
                    string name = Console.ReadLine();
                    Console.Write("Nhap mat khau:");
                    string mk = Console.ReadLine();
                    bool isNameExist = IsNameExist(user, name);
                    bool isMkExist = IsMkExist(user, mk);
                    if (isNameExist)
                    {
                        if (isMkExist)
                        {
                            Console.WriteLine("Dang nhap thanh cong");
                            IsDangnhap = true;
                            check = true;
                        }
                        else
                        {
                            Console.WriteLine("Sai mat khau!! Vui long dang nhap lai:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ten dang nhap khong ton tai!! Vui long dang nhap lai");
                    }
                }
                while (check == false);
            }
            else
            {
                Console.WriteLine("Chua co thanh vien!!!");
            }
            return IsDangnhap;
        }
    }
}