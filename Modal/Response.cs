using System;
using System.Collections.Generic;
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