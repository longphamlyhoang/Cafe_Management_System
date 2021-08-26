
using System;

namespace Cafe_Management_System
{
    class Table
    {
        public int id {get;set;}
        public bool status {get; set;}
        public string name {get;set;}
        public double price {get;set;}
        public void ViewInfo()
        {
            Console.WriteLine($"idTable: {id}\t\tnamedish: {name}\t\tnumberdish: {price}");
        }
    }
    
}