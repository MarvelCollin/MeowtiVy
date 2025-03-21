using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeowtiVy.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}