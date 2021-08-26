using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cafe_Management_System.Ultilities
{
    class Helper
    {
        public List<Dish> ListDish = new List<Dish>();
        public List<Table> ListTable = new List<Table>();
        public Order Order = new Order();

        public Helper()
        {
            string data = "";
            using (StreamReader sr = File.OpenText(Path.Combine(Common.path, Common.fileName)))
            {
                data = sr.ReadToEnd();

            }
            var result = JsonConvert.DeserializeObject<Result>(data);

            foreach (Dish dish in result.Dishs)
            {
                ListDish.Add(new Dish()
                {
                    name = dish.name,
                    price = dish.price
                });
            }

            foreach (Table table in result.Tables)
            {
                ListTable.Add(new Table()
                {
                    id = table.id,
                    status = table.status
                });
            }
        }

        public Order AddOrder(int idTable, string namedish, int numberdish)
        {
            List<Dish> listDistOrder = new List<Dish>();
            // Lay gia tien tu mon an
            double price = 0;
            foreach (var dish in ListDish)
            {
                if (namedish == dish.name)
                {
                    price = dish.price;
                }
            }

            Dish dishRes = new Dish();
            dishRes.name = namedish;
            dishRes.price = price;
            dishRes.number = numberdish;

            listDistOrder.Add(dishRes);

            Order order = new Order();

            order.IdTable = idTable;
            order.Status = true;
            order.Dishs = listDistOrder;

            return order;
        }
        public void BillOrder(Order order, DateTime timeOder)
        {
            Response response = new Response();
            response.TimeStart = timeOder;
            response.TimeEnd = DateTime.Now;

            response.order = order;

            using (StreamWriter sw = File.CreateText(Path.Combine(Common.path, "Table number _" + order.IdTable + ".json")))
            {
                sw.WriteLine(JsonConvert.SerializeObject(response));
            }
        }
        public Order UpDateOrder(Order order, string name, int number)
        {
            double price = 0;
            foreach (var dish in ListDish)
            {
                if (name == dish.name)
                {
                    price = dish.price;
                }
            }

            Dish dis = new Dish();
            dis.name = name;
            dis.number = number;
            dis.price = price;

            order.Dishs.Add(dis);

            return order;
        }

        public void PrintBuild()
        {
            List<Table> listTable = ListTable;
            foreach (var table in listTable)
            {
                table.ViewInfo();
            }

        }

        public void Print(List<Order> listOrder)
        {
            List<Table> listTable = ListTable;

            foreach (var order in listOrder)
            {
                foreach (var table in listTable)
                {
                    if (order.IdTable == table.id)
                    {
                        table.status = order.Status;
                    }
                }
            }
            ResponseTable responseTable = new ResponseTable();
            responseTable.listTable = listTable;

            using (StreamWriter sw = File.CreateText(Path.Combine(Common.path, "Status_Tables.json")))
            {
                sw.WriteLine(JsonConvert.SerializeObject(responseTable));
            }
        }
    }
}