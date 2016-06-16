using System.IO;
using System.Text;

namespace xCarpaccio.client
{
    using Nancy;
    using System;
    using Nancy.ModelBinding;

    public class IndexModule : NancyModule
    {
        public CountriesReduction Cr = new CountriesReduction();
        public Reduction Reduc = new Reduction();
        public IndexModule()
        {
            
            Get["/"] = _ => "It works !!! You need to register your server on main server.";

            Post["/order"] = _ =>
            {
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Console.WriteLine("Order received: {0}", reader.ReadToEnd());
                }

                var order = this.Bind<Order>();
                Bill bill = null;
                //TODO: do something with order and return a bill if possible
                // If you manage to get the result, return a Bill object (JSON serialization is done automagically)
                // Else return a HTTP 404 error : return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                //CalculPrix(order, bill);
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                return bill;
            };

            Post["/feedback"] = _ =>
            {
                var feedback = this.Bind<Feedback>();
                Console.Write("Type: {0}: ", feedback.Type);
                Console.WriteLine(feedback.Content);
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }

        public decimal CalculPrix(Order order, Bill total)
        {
            total.Total = 0;
            for (int i = 0; i < order.Prices.Length; i++)
            {
                total.Total += order.Prices[i] * order.Quantities[i];
                total.Total = total.Total * (1 + (decimal)Cr.ListReduc[order.Country]);

                if (total.Total >= 50000)
                {
                    total.Total = total.Total - (total.Total*(1 + (decimal)Reduc.ListReducTotal[50000]));
                }
                else if (total.Total <= 50000 && total.Total >= 10000)
                {
                    total.Total = total.Total - (total.Total * (1 + (decimal)Reduc.ListReducTotal[10000]));
                }
                else if (total.Total <= 10000 && total.Total >= 7000)
                {
                    total.Total = total.Total - (total.Total * (1 + (decimal)Reduc.ListReducTotal[7000]));
                }
                else if (total.Total <= 7000 && total.Total >= 5000)
                {
                    total.Total = total.Total - (total.Total * (1 + (decimal)Reduc.ListReducTotal[5000]));
                }
                else if (total.Total <= 5000 && total.Total >= 1000)
                {
                    total.Total = total.Total - (total.Total * (1 + (decimal)Reduc.ListReducTotal[1000]));
                }
            }

            return total.Total;
        }
    }
}