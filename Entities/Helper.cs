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

        public Order AddOrder(int idTable, string name, int number)
        {
            List<Dish> listDistOrder = new List<Dish>();
            // Lay gia tien tu mon an
            double price = 0;
            foreach (var dish in ListDish)
            {
                if (name == dish.name)
                {
                    price = dish.price;
                }
            }

            Dish dishRes = new Dish();
            dishRes.name = name;
            dishRes.price = price;
            dishRes.number = number;

            listDistOrder.Add(dishRes);

            Order or = new Order();

            or.IdTable = idTable;
            or.Status = true;
            or.Dishs = listDistOrder;

            return or;
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
        public Order UpDateOrder(Order or, string name, int number)
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

            or.Dishs.Add(dis);

            return or;
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