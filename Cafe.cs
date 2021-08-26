using System;
using System.Collections.Generic;
using Cafe_Management_System.Ultilities;
namespace Cafe_Management_System
{
    class Cafe
    {
        private const int min = 1;
        private const int max = 6;
        public static void BuildMenu2(out int selected)
        {

            do
            {
                Console.WriteLine("=====MENU=====");
                Console.WriteLine("1.Đặt bàn");
                Console.WriteLine("2.Gọi đồ ăn");
                Console.WriteLine("3.show hóa đơn");
                Console.WriteLine("4.show các bàn");
                Console.WriteLine("5.Tính tiền");
                Console.WriteLine("6.Exit");
                Console.WriteLine("=================");
                Console.Write("Choose a function: ");
                int.TryParse(Console.ReadLine(), out selected);
            } while (selected < min || selected > max);
        }
        public void Process2()
        {
            Helper helper = new Helper();
            List<Dish> listDish = new List<Dish>();
            List<Order> listOrder = new List<Order>();
            List<Table> ListTable = new List<Table>();
            DateTime timeOder = DateTime.Now;
            int selected = 0;
            do
            {
                BuildMenu2(out selected);
                Console.Clear();
                switch (selected)
                {
                    case 1:
                        {
                            Console.WriteLine("Bạn có đặt bàn ?");
                            string YesNo = Console.ReadLine();
                            timeOder = DateTime.Now;
                            if (YesNo == "Có" || YesNo == "có")
                            {
                                Console.WriteLine("Thời gian đặt bàn: ");
                                timeOder = DateTime.Parse(Console.ReadLine());
                            }

                            // Order
                            Console.WriteLine("Nhập id bàn:");
                            int idTable = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Nhập món ăn: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("Số lượng món ăn: ");
                            int number = Int32.Parse(Console.ReadLine());

                            Order order = new Order();
                            order = helper.AddOrder(idTable, name, number);

                            listOrder.Add(order);
                            break;

                        }
                    case 2:
                        {
                            Console.WriteLine("Nhập id bàn: ");
                            int idTable = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Nhập món ăn: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("Nhập số lượng món ăn: ");
                            int number = Int32.Parse(Console.ReadLine());

                            bool check = false;

                            // check ton tai id table
                            foreach (var or in listOrder)
                            {
                                if (idTable == or.IdTable)
                                {

                                    foreach (var dis in or.Dishs)
                                    {
                                        if (name == dis.name)
                                        {
                                            dis.number += number;
                                            check = true; ;
                                        }
                                    }

                                    if (check == false)
                                    {
                                        helper.UpDateOrder(or, name, number);
                                    }
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            helper.Print(listOrder);
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            Order order = new Order();
                            Console.WriteLine("Nhập id bàn: ");
                            int idTable = Int32.Parse(Console.ReadLine());

                            foreach (var orderBill in listOrder)
                            {
                                if (idTable == orderBill.IdTable)
                                {
                                    order = orderBill;
                                }
                            }
                            helper.BillOrder(order, timeOder);
                            break;
                        }
                    case 6:
                        {
                            Cafe_Management_System.BuildMenu1.BuildMenu(out selected);
                            BuildMenu1.Process1();
                            break;
                        }
                    default:
                        break;
                }
            } while (selected != max);
        }
    }
}