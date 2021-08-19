using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
namespace Cafe_Management_System
{
    class Order
    {
        public int IdTable {get;set;}
        public bool Status {get;set;}
         public List<Dish> Dishs { get; set; }

        public double Total => Sum();
        public double Sum() // tính tổng
        {
            double total = 0;
            foreach (Dish dish in Dishs)
            {
                total += dish.price * dish.number;
            }
            return total;
        }  
    }
}