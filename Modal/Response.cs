using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
namespace Cafe_Management_System
{
    class Response
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public List<Order> listOrderRes { get; set; }
        public Order order { get; set; }
        public List<Table> listTable { get; set; }
    }
    class ResponseTable
    {
        public List<Table> listTable { get; set; }
    }
}