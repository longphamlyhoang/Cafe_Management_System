using System;
using System.Collections.Generic;
namespace Cafe_Management_System
{
    class BuildMenu1
    {
        const int min = 1;
        const int max = 3;
        const int Login = 1;
        const int Register = 2;
        const int Exit = 3;
        public static void BuildMenu(out int option)
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
                BuildMenu(out selected);
                Console.Clear();
                switch (selected)
                {
                    case Login:
                        {
                            bool check = User.Login(user);
                            if (check)
                            {
                                Cafe cafe = new Cafe();
                                cafe.Process2();
                                break;
                            }
                            break;
                        }
                    case Register:
                        {
                            User.Register(user);
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