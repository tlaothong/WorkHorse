using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeUtcMap
{
    class Program
    {
        static void Main(string[] args)
        {
            // I haven't found any settings in the Model Designer that could be use to set the DateTime's Kind.

            // So I just query some entities to see the default DateTimeKind from the database.
            // It's all DateTimeKind.Unspecified
            ListOrdersToSeeDateTimeKind();
        }

        private static void ListOrdersToSeeDateTimeKind()
        {
            using (NorthwindEntities dctx = new NorthwindEntities())
            {
                foreach (var item in dctx.Orders.Take(9))
                {
                    Console.WriteLine("Order: {0}/{1}  Required: {2}/{3}  Shipped: {4}/{5}",
                        item.OrderDate, item.OrderDate.Value.Kind, item.RequiredDate, item.RequiredDate.Value.Kind, item.ShippedDate.Value, item.ShippedDate.Value);
                }
            }
        }
    }
}
