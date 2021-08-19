using System;
using System.Collections.Generic;
namespace Cafe_Management_System
{
    class BuildMenu1
    {
        const int min = 1;
        const int max = 3;
        const int dangnhap = 1;
        const int dangky = 2;
        const int Exit = 3;
        public static void Buildmenu(out int option)
        {
            do
            {
                Console.WriteLine("-----------Menu-----------");
                Console.WriteLine("1. Đăng nhập ");
                Console.WriteLine("2. Đăng kí");
                Console.WriteLine("3. Exit");
                Console.WriteLine("----------------------------");
                Console.Write($"Please choice a number ({min},{max}): ");
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    option = 0;
                }
            }
            while (option < min || option > max);
        }
        public static void Process1()
        {
            var user = HelperUser<List<User>>.ReadFile("User.json");
            var selected = 0;
            do
            {
                Buildmenu(out selected);
                Console.Clear();
                switch (selected)
                {
                    case dangnhap:
                        {
                            bool check = User.DangNhap(user);
                            if (check)
                            {
                                Cafe cafe = new Cafe();
                                cafe.Process2();
                                break;
                            }
                            break;
                        }
                    case dangky:
                        {
                            User.DangKy(user);
                            Cafe cafe = new Cafe();
                            cafe.Process2();
                            break;
                        }

                    case Exit:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            while (selected != Exit);
        }
    }
}